using VehiclesForSale.Data.Models;

namespace VehiclesForSale.Web.ViewModels
{
    public class ChatViewModel
    {
        public ChatViewModel() 
        {
            this.Message = new List<Message>();
        }

        public string SenderId { get; set; } = null!;

        public string ReceiverId { get; set; } = null!;

        public string SenderName { get; set; } = null!;

        public string ReceiverName { get; set; } = null!;

        public List<Message> Message { get; set; }
        

    }
}
