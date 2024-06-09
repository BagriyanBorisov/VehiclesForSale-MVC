using VehiclesForSale.Data.Models;

namespace VehiclesForSale.Core.Contracts.Chat
{
    public interface IChatService
    {
        Task<List<Message>> GetMessages(string senderId, string receiverId);
    }
}
