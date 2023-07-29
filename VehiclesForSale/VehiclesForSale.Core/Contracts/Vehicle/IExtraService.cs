namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using Web.ViewModels.Vehicle;

    public interface IExtraService
    {
        public Task<ExtraFormViewModel> GetAllExtras();
    }
}
