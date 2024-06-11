using VehiclesForSale.Data.Models;

namespace VehiclesForSale.Web.ViewModels
{
    public class NotificationViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }


        public string SenderId { get; set; }

        public string SenderName { get; set; }

        public string ReceiverId { get; set; }

        public ApplicationUser Receiver { get; set; }
        public string ReturnUrl { get; set; }

        public bool isRead { get; set; } 
    }
}
