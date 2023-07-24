namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;
    using VehiclesForSale.Web.ViewModels.Vehicle;
    using Contracts.Vehicle;
    using Data;

    public class FuelTypeService : IFuelTypeService
    {
        private readonly VehiclesDbContext context;

        public FuelTypeService(VehiclesDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<FuelTypeFormVehicleViewModel>> GetAllAsync()
        {

            var models =
                await context.FuelTypes
                    .Select(e => new FuelTypeFormVehicleViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name
                    }).ToListAsync();

            return models;
        }
    }
}
