namespace VehiclesForSale.Core.Contracts.Extra
{
    using Web.ViewModels.Vehicle;

    public interface IExtraService
    {
        public Task<bool> CheckOwner(string vehicleId, string userId);
        public Task<ExtraFormViewModel> GetAddExtraAsync(string id);
        public Task<ExtraFormViewModel> GetEditExtraAsync(string id);
        public Task AddExtraAsync(ExtraFormViewModel extraVm, string userId, string extraId);
        public Task EditExtraAsync(ExtraFormViewModel extraVm, string userId, string extraId);

        public Task<IEnumerable<InteriorExtraFormViewModel>> GetInteriorExtrasAsync();
        public Task<IEnumerable<ExteriorExtraFormViewModel>> GetExteriorExtrasAsync();
        public Task<IEnumerable<SafetyExtraFormViewModel>> GetSafetyExtrasAsync();
        public Task<IEnumerable<ComfortExtraFormViewModel>> GetComfortExtrasAsync();
        public Task<IEnumerable<OtherExtraFormViewModel>> GetOtherExtrasAsync();

        public Task<bool> CheckInteriorByNameExist(string name);
        public Task<bool> CheckExteriorByNameExist(string name);
        public Task<bool> CheckSafetyByNameExist(string name);
        public Task<bool> CheckComfortByNameExist(string name);
        public Task<bool> CheckOtherByNameExist(string name);

        public Task AddInteriorAsync(string name);
        public Task AddExteriorAsync(string name);
        public Task AddSafetyAsync(string name);
        public Task AddComfortAsync(string name);
        public Task AddOtherAsync(string name);

        public Task DeleteInteriorAsync(string Id);
        public Task DeleteExteriorAsync(string Id);
        public Task DeleteSafetyAsync(string Id);
        public Task DeleteComfortAsync(string Id);
        public Task DeleteOtherAsync(string Id);
    }
}
