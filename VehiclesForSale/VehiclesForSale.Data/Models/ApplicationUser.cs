using Microsoft.AspNetCore.Identity;
using VehiclesForSale.Data.Models.VehicleModel;

namespace VehiclesForSale.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.VehiclesCollectionForSale = new HashSet<Vehicle>();
            this.FavoriteVehicleApplicationUsers = new HashSet<FavoriteVehicleApplicationUser>();
            this.Messages = new HashSet<Message>();
        }

        public DateTime RegistrationDate { get; set; }
        public ICollection<Vehicle> VehiclesCollectionForSale { get; set; }
        public ICollection<FavoriteVehicleApplicationUser> FavoriteVehicleApplicationUsers { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<Notification> SentNotifications { get; set; } = new List<Notification>();
        public ICollection<Notification> ReceivedNotifications { get; set; } = new List<Notification>();
    }
}
