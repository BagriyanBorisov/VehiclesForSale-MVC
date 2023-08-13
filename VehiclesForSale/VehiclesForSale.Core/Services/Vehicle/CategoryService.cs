namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Contracts.Vehicle;
    using Data.Models.VehicleModel;
    using Web.ViewModels.Vehicle;

    public class CategoryService : ICategoryService
    {
        private readonly VehiclesDbContext context;

        public CategoryService(VehiclesDbContext _context)
        {
            context = _context;
        }

        public async Task AddAsync(string name)
        {
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            {
                var catToAdd = new CategoryType()
                {
                    Name = name,
                };

                await context.CategoryTypes.AddAsync(catToAdd);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException("Category name is null or empty!");
            }
        }

        public async Task<bool> CheckByNameExist(string name)
        {
            return await context.CategoryTypes.Where(m => m.Name.ToLower() == name.ToLower()).AnyAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var entityToDel = await context.CategoryTypes.Where(m => m.Id.ToString() == Id).FirstOrDefaultAsync();
            if (entityToDel == null)
            {
                throw new NullReferenceException("This Category does not exist!");
            }
            context.CategoryTypes.Remove(entityToDel);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<CategoryFormVehicleViewModel>> GetAllAsync()
        {
            var models =
                await context.CategoryTypes
                    .Select(e => new CategoryFormVehicleViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name
                    }).ToListAsync();

            return models;
        }


    }
}
