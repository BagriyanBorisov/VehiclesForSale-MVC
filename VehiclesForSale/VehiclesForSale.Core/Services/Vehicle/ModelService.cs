namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;
    using VehiclesForSale.Web.ViewModels.Vehicle;
    using Contracts.Vehicle;
    using Data;
    public class ModelService : IModelService
    {
        private readonly VehiclesDbContext context;

        public ModelService(VehiclesDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<ModelFormVehicleViewModel>> GetAllAsync(int makeId)
        {
            var models =
                await context.Models.Where(m => m.MakeId == makeId)
                    .Select(e => new ModelFormVehicleViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name
                    }).ToListAsync();

            return models;
        }
    }
}
