using VehiclesForSale.Web.ViewModels.Vehicle.Index;

namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using Web.ViewModels.Vehicle;

    public interface IVehicleService
    {
        public Task<VehicleFormViewModel> GetForAddVehicleAsync();
        public Task<VehicleFormViewModel> GetById(string id);
        public Task<IEnumerable<ModelFormVehicleViewModel>> GetModels(string id);
        public Task<ICollection<VehicleIndexViewModel>> GetAllVehiclesAsync();
        public Task<ICollection<VehicleIndexViewModel>> GetUserVehiclesAsync(string userId);
        public Task DeleteVehicleAsync(string vehicleId,string userId);

        public Task AddVehicleAsync(VehicleFormViewModel vehicleVm,string userId);
    }
}
