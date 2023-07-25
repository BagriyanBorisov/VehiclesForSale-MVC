namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using Web.ViewModels.Vehicle;

    public interface IVehicleService
    {
        public Task<VehicleFormViewModel> GetForAddVehicleAsync();
    }
}
