using VehiclesForSale.Web.ViewModels.Vehicle.Index;

namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using Web.ViewModels.Vehicle;

    public interface IVehicleService
    {
        public Task<VehicleFormViewModel> GetForAddVehicleAsync();
        public Task<ICollection<VehicleIndexViewModel>> GetAllVehiclesAsync();

        public Task AddVehicleAsync(VehicleFormViewModel vehicleVm,string userId);
    }
}
