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
        }

        public ICollection<Vehicle> VehiclesCollectionForSale { get; set; }
        public ICollection<FavoriteVehicleApplicationUser> FavoriteVehicleApplicationUsers { get; set; }
    }
}
