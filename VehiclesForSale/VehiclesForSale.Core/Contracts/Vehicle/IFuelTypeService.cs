namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using VehiclesForSale.Web.ViewModels.Vehicle;

    public interface IFuelTypeService
    {
        public Task<IEnumerable<FuelTypeFormVehicleViewModel>> GetAllAsync();
    }
}
