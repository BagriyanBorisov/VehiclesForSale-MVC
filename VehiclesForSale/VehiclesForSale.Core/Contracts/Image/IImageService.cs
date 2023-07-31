namespace VehiclesForSale.Core.Contracts.Image
{
    using VehiclesForSale.Web.ViewModels.Vehicle;
    using Image = Data.Models.VehicleModel.Image;

    public interface IImageService
    {
        public ImageFormViewModel GetImageWithVehicle(string vehicleId);
        public Task CreateImages(string id, ImageFormViewModel imageVm);
        public Task DeleteImage(ICollection<Image> imagesCollection, string vehicleId);
        public Task<string> GetPathById(string id);
    }
}
