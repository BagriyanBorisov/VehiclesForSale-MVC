using Microsoft.AspNetCore.Http;

namespace VehiclesForSale.Web.ViewModels.Vehicle
{
    public class ImageFormViewModel
    {
        public List<IFormFile> Images { get; set; } = null!;

        public VehicleFormViewModel Vehicle { get; set; } = null!;
    }
}
