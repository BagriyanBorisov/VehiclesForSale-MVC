using Microsoft.AspNetCore.Http;

namespace VehiclesForSale.Web.ViewModels.Vehicle
{
    public class ImageFormViewModel
    {
        public List<IFormFile> Images { get; set; } = null!;

        public string VehicleId { get; set; } = null!;

        public string VehicleName { get; set; } = null!;
    }
}
