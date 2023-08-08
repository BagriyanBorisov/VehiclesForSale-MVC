namespace VehiclesForSale.Core.Contracts.Vehicle
{
    using Web.ViewModels.Vehicle;


    public interface ITransmissionTypeService
    {
        public Task<IEnumerable<TransmissionTypeFormVehicleViewModel>> GetAllAsync();
        public Task<bool> CheckByNameExist(string name);
        public Task AddAsync(string name);
        public Task DeleteAsync(string Id);
    }
}
