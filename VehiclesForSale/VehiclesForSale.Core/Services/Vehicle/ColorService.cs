namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;
    using VehiclesForSale.Web.ViewModels.Vehicle;
    using Contracts.Vehicle;
    using Data;
    public class ColorService : IColorService
    {
        private readonly VehiclesDbContext context;

        public ColorService(VehiclesDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<ColorFormVehicleViewModel>> GetAllAsync()
        {
            var models =
                await context.Colors
                    .Select(e => new ColorFormVehicleViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name
                    }).ToListAsync();

            return models;
        }
    }
}
