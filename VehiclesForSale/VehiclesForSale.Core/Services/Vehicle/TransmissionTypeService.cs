using VehiclesForSale.Core.Contracts.Vehicle;
using VehiclesForSale.Web.ViewModels.Vehicle;

namespace VehiclesForSale.Core.Services.Vehicle
{
    public class TransmissionTypeService : ITransmissionTypeService
    {
        private readonly VehicleDbContext context;

        public TransmissionTypeService()
        {
            
        }

        public Task<IEnumerable<TransmissionTypeFormVehicleViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
