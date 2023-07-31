namespace VehiclesForSale.Core.Contracts.Extra
{
    using Web.ViewModels.Vehicle;

    public interface IExtraService
    {
        public Task<ExtraFormViewModel> GetAddExtraAsync(string id);
        public Task AddExtraAsync(ExtraFormViewModel extraVm, string userId, string extraId);
    }
}
