﻿namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using Web.ViewModels.Vehicle.Details;
    using Web.ViewModels.Vehicle.Index;
    using Web.ViewModels.Vehicle;

    public interface IVehicleService
    {
        public Task<VehicleFormViewModel> GetForAddVehicleAsync();
        public Task<VehicleFormViewModel> GetForEditVehicleAsync(string vehicleId, string userId);
        public Task<DetailsViewModel> GetForDetailsVehicleAsync(string? userId,string id);
        public Task<VehicleFormViewModel> GetById(string id);
        public Task<IEnumerable<ModelFormVehicleViewModel>> GetModels(string id);
        public Task<ICollection<VehicleIndexViewModel>> GetAllVehiclesAsync();
        public Task<ICollection<VehicleIndexViewModel>> GetUserVehiclesAsync(string userId);
        public Task<ICollection<VehicleIndexViewModel>> GetWatchListAsync(string userId);
        public Task DeleteVehicleAsync(string vehicleId,string userId);

        public Task AddVehicleAsync(VehicleFormViewModel vehicleVm,string userId);
        public Task EditVehicleAsync(VehicleFormViewModel vehicleVm,string userId);
        public Task AddVehicleToWatchListAsync(string userId, string vehicleId);
        public Task DeleteVehicleFromWatchListAsync(string userId, string vehicleId);
    }
}
