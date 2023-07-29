using VehiclesForSale.Web.ViewModels.Vehicle;

namespace VehiclesForSale.Core.Contracts.Image
{
    public interface IImageService
    {
        public Task<ImageFormViewModel> GetImageWithVehicle(string vehicleId);
        public Task CreateImages(string id, ImageFormViewModel imageVm);
        public Task<string> GetPathById(string id);
    }
}
