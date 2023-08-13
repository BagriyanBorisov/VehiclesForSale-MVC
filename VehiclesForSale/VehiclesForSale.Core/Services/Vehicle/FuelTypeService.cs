namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Contracts.Vehicle;
    using Data.Models.VehicleModel;
    using Web.ViewModels.Vehicle;

    public class FuelTypeService : IFuelTypeService
    {
        private readonly VehiclesDbContext context;

        public FuelTypeService(VehiclesDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(string name)
        {
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            {
                var entityToAdd = new FuelType()
                {
                    Name = name,
                };

                await context.FuelTypes.AddAsync(entityToAdd);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException("Cannot be null or empty - Fuel name");
            }
        }

        public async Task DeleteAsync(string Id)
        {
            var entityToDel = await context.FuelTypes.Where(m => m.Id.ToString() == Id).FirstOrDefaultAsync();
            if (entityToDel == null)
            {
                throw new NullReferenceException("This Fuel type does not exist!");
            }
            context.FuelTypes.Remove(entityToDel);
            await context.SaveChangesAsync();

        }

        public async Task<bool> CheckByNameExist(string name)
        {
            return await context.FuelTypes.Where(m => m.Name.ToLower() == name.ToLower()).AnyAsync();
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
