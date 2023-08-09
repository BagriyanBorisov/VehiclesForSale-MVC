namespace VehiclesForSale.Core.Contracts.Vehicle
{
    public interface IDateService
    {
        public Task<IEnumerable<int>> GetAllAsync();
        public Task<bool> CheckByNameExist(int name);
        public Task AddAsync(int name);
        public Task DeleteAsync(string Id);
    }
}
