namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using Web.ViewModels.Vehicle;


    public interface ITransmissionTypeService
    {
        public Task<IEnumerable<TransmissionTypeFormVehicleViewModel>> GetAllAsync();
    }
}
