using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace VehiclesForSale.Data.Models
{
    public class Message 
    {
        public Message()
        {
            this.CreatedOn = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string SenderId { get; set; }

        public ApplicationUser Sender { get; set; }

        public string ReceiverId { get; set; }

        [NotMapped]
        public ApplicationUser Receiver { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
