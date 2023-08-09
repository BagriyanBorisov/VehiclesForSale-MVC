namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;
   
    using Data;
    using Contracts.Vehicle;
    using Data.Models.VehicleModel;
    using Web.ViewModels.Vehicle;

    public class ModelService : IModelService
    {
        private readonly VehiclesDbContext context;

        public ModelService(VehiclesDbContext context)
        {
            this.context = context;
        }

        public async Task AddModelAsync(string modelName, int? makeId)
        {
            var modelToAdd = new Model()
            {
                Name = modelName,
                MakeId = Convert.ToInt32(makeId)
            };

            await context.Models.AddAsync(modelToAdd);
            await context.SaveChangesAsync();

        }

        public async Task<bool> CheckByNameExist(string modelName, int? makeId)
        {
            return await context.Models.Where(m => m.MakeId == makeId && m.Name.ToLower() == modelName.ToLower()).AnyAsync();
        }

        public async Task DeleteModelAsync(string modelId)
        {
            var modToDel = await context.Models.Where(m => m.Id.ToString() == modelId).FirstOrDefaultAsync();

            if (modToDel == null)
            {
                throw new NullReferenceException("This model does not exists");
            }

            context.Models.Remove(modToDel);
            await context.SaveChangesAsync();
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

        public async Task<IEnumerable<ModelFormVehicleViewModel>> GetForAllMakesAsync()
        {
            var models =
                await context.Models
                    .Select(e => new ModelFormVehicleViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name
                    }).ToListAsync();

            return models;
        }
    }
}
