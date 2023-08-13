namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Contracts.Vehicle;
    using Data.Models.VehicleModel;
    using Web.ViewModels.Vehicle;

    public class ColorService : IColorService
    {
        private readonly VehiclesDbContext context;

        public ColorService(VehiclesDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(string name)
        {
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            {
                var entityToAdd = new Color()
                {
                    Name = name,
                };

                await context.Colors.AddAsync(entityToAdd);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException("Color is null or empty!");
            }
        }
        public async Task DeleteAsync(string Id)
        {
            var entityToDel = await context.Colors.Where(m => m.Id.ToString() == Id).FirstOrDefaultAsync();
            if (entityToDel == null)
            {
                throw new NullReferenceException("This Fuel type does not exist!");
            }
            context.Colors.Remove(entityToDel);
            await context.SaveChangesAsync();

        }

        public async Task<bool> CheckByNameExist(string name)
        {
            return await context.Colors.Where(m => m.Name.ToLower() == name.ToLower()).AnyAsync();
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
