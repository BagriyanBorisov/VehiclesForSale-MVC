namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using VehiclesForSale.Web.ViewModels.Vehicle;

    public interface IColorService
    {
        public Task<IEnumerable<ColorFormVehicleViewModel>> GetAllAsync();
    }
}
