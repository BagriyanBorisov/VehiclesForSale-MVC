namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using VehiclesForSale.Web.ViewModels.Vehicle;

    public interface IMakeService
    {
        public Task<IEnumerable<MakeFormVehicleViewModel>> GetAllAsync();
        public Task AddMakeAsync(string makeName);
        public Task<bool> CheckByNameExist(string makeName);
        public Task DeleteMakeAsync(string makeId);
    }
}
