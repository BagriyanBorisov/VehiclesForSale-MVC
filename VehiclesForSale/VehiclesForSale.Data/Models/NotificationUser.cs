namespace VehiclesForSale.Data.Models
{
    public class NotificationUser
    {
        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public bool IsSender { get; set; }  // To differentiate between senders and receivers
    }
}
