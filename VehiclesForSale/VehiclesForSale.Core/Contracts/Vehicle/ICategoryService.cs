namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using VehiclesForSale.Web.ViewModels.Vehicle;

    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryFormVehicleViewModel>> GetAllAsync();
    }
}
