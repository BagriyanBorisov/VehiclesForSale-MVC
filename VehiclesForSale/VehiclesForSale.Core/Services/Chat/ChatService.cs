using Microsoft.EntityFrameworkCore;
using VehiclesForSale.Core.Contracts.Chat;
using VehiclesForSale.Data;
using VehiclesForSale.Data.Models;
using VehiclesForSale.Web.ViewModels;

namespace VehiclesForSale.Core.Services.Chat
{
    public class ChatService : IChatService
    {
        private VehiclesDbContext context;

        public ChatService(VehiclesDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Message>> GetMessages(string senderId, string receiverId)
        {
           var senderMessages = await this.context.Messages
                .Where(x => x.SenderId == senderId && x.ReceiverId == receiverId)
                .OrderByDescending(x => x.CreatedOn)      
                .ToListAsync();
            var receiverMessages = await this.context.Messages
                .Where(x => x.SenderId == receiverId && x.ReceiverId == senderId)
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();

            var messages = senderMessages.Concat(receiverMessages).OrderByDescending(x => x.CreatedOn).ToList();

            return messages;
        }

        public async Task<List<NotificationViewModel>> GetNotifications(string receiverId)
        {
           
            var user = await this.context.Users
                .Include(x => x.ReceivedNotifications)
                .ThenInclude(x => x.Sender)
                .FirstOrDefaultAsync(x => x.Id == receiverId);

            var distinctedNotifications = user.ReceivedNotifications.DistinctBy(x => x.SenderId).ToList();


            var notifications = distinctedNotifications
                .Select(x => new NotificationViewModel
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    ReceiverId = x.ReceiverId,
                    Receiver = x.Receiver,
                    isRead = x.isRead,
                    SenderId = x.SenderId,
                    SenderName = x.Sender.UserName


                })
                .ToList();

            return notifications;
        }

        public async Task<int> GetUnreadNotificationsCountAsync(string userId)
        {
            var user = await context.Users   
           .Where(n => n.Id == userId)
           .Include(x => x.ReceivedNotifications.Where(x => x.isRead == false))
           .FirstOrDefaultAsync();

            var distinctedNotifications = user.ReceivedNotifications.DistinctBy(x => x.SenderId).ToList();



            return distinctedNotifications.Count;

        }
    }
}
