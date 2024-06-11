using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesForSale.Data.Models
{
    public class Notification
    {
        public Notification()
        {
            this.CreatedOn = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }

        public string SenderId { get; set; }
        [ForeignKey(nameof(SenderId))]
        public ApplicationUser Sender { get; set; }

        public string ReceiverId { get; set; }
        [ForeignKey(nameof(ReceiverId))]
        public ApplicationUser Receiver { get; set; }
        public bool isRead { get; set; } = false;
    }
}
