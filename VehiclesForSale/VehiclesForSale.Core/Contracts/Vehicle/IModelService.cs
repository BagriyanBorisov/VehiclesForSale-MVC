namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using VehiclesForSale.Web.ViewModels.Vehicle;

    public interface IModelService
    {
        public Task<IEnumerable<ModelFormVehicleViewModel>> GetAllAsync(int makeId);
        public Task<IEnumerable<ModelFormVehicleViewModel>> GetForAllMakesAsync();
        public Task AddModelAsync(string modelName, int? makeId);
        public Task<bool> CheckByNameExist(string modelName, int? makeId);
        public Task DeleteModelAsync(string modelId);
    }
}
