namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;
    using VehiclesForSale.Core.Contracts.Vehicle;
    using VehiclesForSale.Web.ViewModels.Vehicle;
    using Data;
    public class TransmissionTypeService : ITransmissionTypeService
    {
        private readonly VehiclesDbContext context;

        public TransmissionTypeService(VehiclesDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<TransmissionTypeFormVehicleViewModel>> GetAllAsync()
        {
            var models = 
                await context.TransmissionTypes
                    .Select(e => new TransmissionTypeFormVehicleViewModel() 
                    { 
                        Id = e.Id, 
                        Name = e.Name
                    }).ToListAsync();

            return models;
        }
    }
}
