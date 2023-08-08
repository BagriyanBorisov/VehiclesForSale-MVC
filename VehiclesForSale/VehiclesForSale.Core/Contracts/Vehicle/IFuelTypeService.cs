namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using VehiclesForSale.Web.ViewModels.Vehicle;

    public interface IFuelTypeService
    {
        public Task<IEnumerable<FuelTypeFormVehicleViewModel>> GetAllAsync();
        public Task<bool> CheckByNameExist(string name);
        public Task AddAsync(string name);
        public Task DeleteAsync(string Id);
    }
}
