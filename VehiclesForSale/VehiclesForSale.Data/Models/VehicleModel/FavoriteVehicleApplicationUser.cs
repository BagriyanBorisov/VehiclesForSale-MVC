using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesForSale.Data.Models.VehicleModel
{
    public class FavoriteVehicleApplicationUser
    {
        public string ApplicationUserId { get; set; } = null!;
        public Guid VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;

    }
}
