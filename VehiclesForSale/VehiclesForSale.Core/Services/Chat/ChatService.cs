using Microsoft.EntityFrameworkCore;
using VehiclesForSale.Core.Contracts.Chat;
using VehiclesForSale.Data;
using VehiclesForSale.Data.Models;

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
    }
}
