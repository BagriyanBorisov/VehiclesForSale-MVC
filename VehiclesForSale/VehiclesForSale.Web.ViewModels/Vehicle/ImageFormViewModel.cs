using Microsoft.AspNetCore.Http;

namespace VehiclesForSale.Web.ViewModels.Vehicle
{
    public class ImageFormViewModel
    {
        public ImageFormViewModel()
        {
            this.Images = new List<IFormFile>();
            this.ImagesForTable = new List<ImageViewModel>();
        }

        public List<IFormFile> Images { get; set; }

        public string VehicleId { get; set; } = null!;

        public string VehicleName { get; set; } = null!;

        public List<ImageViewModel> ImagesForTable { get; set; }
    }
}
