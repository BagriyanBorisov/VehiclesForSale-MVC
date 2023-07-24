namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using VehiclesForSale.Web.ViewModels.Vehicle;

    public interface IMakeService 
    {
        public Task<IEnumerable<MakeFormVehicleViewModel>> GetAllAsync();
    }
}
