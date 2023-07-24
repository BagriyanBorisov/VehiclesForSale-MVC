namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;
    using VehiclesForSale.Web.ViewModels.Vehicle;
    using Contracts.Vehicle;
    using Data;
    public class MakeService :  IMakeService
    {
        private readonly VehiclesDbContext context;

        public MakeService(VehiclesDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<MakeFormVehicleViewModel>> GetAllAsync()
        {
            var models =
                await context.Makes
                    .Select(e => new MakeFormVehicleViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name
                    }).ToListAsync();

            return models;
        }
    }
}
