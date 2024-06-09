namespace VehiclesForSale.Web.Hubs;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using VehiclesForSale.Data;
using VehiclesForSale.Data.Models;

public class ChatHub : Hub
{
    private readonly VehiclesDbContext context;
    private readonly UserManager<ApplicationUser> _userManager;
    private bool isFirstTime = true;

    public ChatHub(VehiclesDbContext context, UserManager<ApplicationUser> userManager)
    {
        this.context = context;
        this._userManager = userManager;
    }

    public async Task SendMessage(string destuser,string sendingUser, string message)
    {
        if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
        {
            return;
        }

        var sender = await this._userManager.FindByIdAsync(sendingUser);
        var receiver = await this._userManager.FindByIdAsync(destuser);

        await AddMessageToDbAsync(message, sender, receiver);

        await Clients.User(receiver.Id).SendAsync("ReceiveMessage", sender.Id,sender.UserName, message);
        await Clients.Caller.SendAsync("ReceiveMessage", sender.Id, sender.UserName, message);
    }

    public async Task LoadPreviousMessages(string destuser)
    {
        var sender = this.context.Users
            .Include(x => x.Messages)
            .SingleOrDefault(x => x.UserName == this.Context.User.Identity.Name);

        var receiver = this.context.Users
            .Include(x => x.Messages)
            .SingleOrDefault(x => x.UserName == destuser);

        await this.LoadPreviousMessagesAsync(sender, receiver);
    }

    private async Task LoadPreviousMessagesAsync(ApplicationUser sender, ApplicationUser receiver)
    {
        List<Message> messages = new List<Message>(sender.Messages.Where(x => x.ReceiverId == receiver.Id));
        messages = messages.Concat(receiver.Messages.Where(x => x.ReceiverId == sender.Id)).OrderByDescending(x => x.Id).ToList();

        foreach (var message in messages.Take(5).OrderBy(x => x.Id))
        {
            await this.Clients.User(message.SenderId).SendAsync("LoadMessage", message.Sender.UserName, message.Content);
            await this.Clients.User(message.ReceiverId).SendAsync("LoadMessage", message.Sender.UserName, message.Content);
        }
    }

    private async Task AddMessageToDbAsync(string message, ApplicationUser sender, ApplicationUser receiver)
    {
        var currentMessage = new Message() { Content = message, ReceiverId = receiver.Id };
        sender.Messages.Add(currentMessage);
        this.context.Update(sender);
        await this.context.SaveChangesAsync();
    }
}