namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using VehiclesForSale.Web.ViewModels.Vehicle;

    public interface IModelService
    {
        public Task<IEnumerable<ModelFormVehicleViewModel>> GetAllAsync(int makeId);
    }
}
