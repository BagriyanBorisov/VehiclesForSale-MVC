namespace VehiclesForSale.Web.Hubs;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using VehiclesForSale.Core.Contracts.Chat;
using VehiclesForSale.Data;
using VehiclesForSale.Data.Models;

public class ChatHub : Hub
{
    private readonly VehiclesDbContext context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IChatService chatService;
    private bool isFirstTime = true;

    public ChatHub(VehiclesDbContext context, UserManager<ApplicationUser> userManager, IChatService chatService)
    {
        this.context = context;
        this._userManager = userManager;
        this.chatService = chatService;
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
        await Clients.User(receiver.Id).SendAsync("ReceiveNotification", sender.UserName, sender.Id, message);

        await AddNotificationToDbAsync(sender, receiver);
        var result = await chatService.GetNotifications(receiver.Id);

    }

    

    private async Task AddMessageToDbAsync(string message, ApplicationUser sender, ApplicationUser receiver)
    {
        var currentMessage = new Message() { Content = message, ReceiverId = receiver.Id };
        sender.Messages.Add(currentMessage);
        this.context.Update(sender);
        await this.context.SaveChangesAsync();
    }

    private async Task AddNotificationToDbAsync(ApplicationUser sender, ApplicationUser receiver)
    {

     

        var currentNotification = new Notification() {SenderId = sender.Id,  ReceiverId = receiver.Id};
        receiver.ReceivedNotifications.Add(currentNotification);
        sender.SentNotifications.Add(currentNotification);
        this.context.Update(receiver);
        await this.context.SaveChangesAsync();
    }
}