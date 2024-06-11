using VehiclesForSale.Data.Models;
using VehiclesForSale.Web.ViewModels;

namespace VehiclesForSale.Core.Contracts.Chat
{
    public interface IChatService
    {
        Task<List<Message>> GetMessages(string senderId, string receiverId);
        Task<List<NotificationViewModel>> GetNotifications(string receiverId);
        Task<int> GetUnreadNotificationsCountAsync(string userId);
    }
}
