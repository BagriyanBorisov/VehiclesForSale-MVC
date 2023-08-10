namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using VehiclesForSale.Web.ViewModels.Vehicle.Search;
    using Web.ViewModels.Vehicle;
    using Web.ViewModels.Vehicle.Details;
    using Web.ViewModels.Vehicle.Index;

    public interface IVehicleService
    {
        public Task<VehicleFormViewModel> GetForAddVehicleAsync();
        public Task<VehicleFormViewModel> GetForEditVehicleAsync(string vehicleId, string userId);
        public Task<DetailsViewModel> GetForDetailsVehicleAsync(string? userId, string id);
        public Task<VehicleFormViewModel> GetById(string id);
        public Task<IEnumerable<ModelFormVehicleViewModel>> GetModels(string id);
        public Task<ICollection<VehicleIndexViewModel>> GetAllVehiclesAsync();
        public Task<ICollection<VehicleIndexViewModel>> GetUserVehiclesAsync(string userId);
        public Task<ICollection<VehicleIndexViewModel>> GetWatchListAsync(string userId);
        public Task DeleteVehicleAsync(string vehicleId, string userId);

        public Task AddVehicleAsync(VehicleFormViewModel vehicleVm, string userId);
        public Task EditVehicleAsync(VehicleFormViewModel vehicleVm, string userId);
        public Task AddVehicleToWatchListAsync(string userId, string vehicleId);
        public Task DeleteVehicleFromWatchListAsync(string userId, string vehicleId);

        public Task<VehicleSearchViewModel> GetForSearchAsync();

        public Task<ICollection<VehicleIndexViewModel>> GetFilteredAsync(
             string MakeId, string ModelId, string TransmissionTypeId,
            string SelectedYearTo, string SelectedYearFrom,
            string PriceTo, string PriceFrom, string CategoryTypeId,
            string ColorId, string MileageTo, string CubicCapacityTo,
            string HorsePowerTo, string FuelTypeId);
    }
}
