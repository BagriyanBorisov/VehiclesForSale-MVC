using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VehiclesForSale.Core.Contracts.Chat;
using VehiclesForSale.Data.Models;
using VehiclesForSale.Web.ViewModels;

namespace VehiclesForSale.Web.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IChatService chatService;

        public ChatController(UserManager<ApplicationUser> userManager, IChatService chat)
        {
            _userManager = userManager;
            this.chatService = chat;
        }

        [Authorize]
        public async Task<IActionResult> Index(string receivingUserId)
        {
            var sender = await this._userManager.GetUserAsync(this.User);
            var receivingUser = await this._userManager.FindByIdAsync(receivingUserId);
            if (receivingUser == null || sender.Id == receivingUserId)
            {
                return BadRequest("Invalid chat request.");
            }
            
            var chatViewModel = new ChatViewModel
            {
                SenderId = sender.Id,
                ReceiverId = receivingUserId,
                SenderName = sender.UserName,
                ReceiverName = receivingUser.UserName,
                Message = new List<Message>()
            };

            chatViewModel.Message = await this.chatService.GetMessages(sender.Id, receivingUserId);

            return this.View(chatViewModel);
        }
    }
}

