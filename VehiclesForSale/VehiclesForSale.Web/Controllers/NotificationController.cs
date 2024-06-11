using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiclesForSale.Core.Contracts.Chat;
using VehiclesForSale.Data.Models;

namespace VehiclesForSale.Web.Controllers
{
    [Authorize]
    [Route("notifications")]
    public class NotificationsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IChatService chatService;

        public NotificationsController(UserManager<ApplicationUser> userManager, IChatService chat)
        {
            _userManager = userManager;
            this.chatService = chat;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetNotifications()
        {
            var user = await _userManager.GetUserAsync(User);
            var notifications = await this.chatService.GetNotifications(user.Id);

            // Simplify the JSON response
            var result = notifications.Select(n => new {
                senderId = n.SenderId,
                timestamp = n.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss"),
                chatUrl = "/Chat/Index?receivingUserId=" + n.SenderId
            });
            return Ok(result);
        }
    }
}
