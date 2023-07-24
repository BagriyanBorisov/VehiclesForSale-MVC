namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;
    using VehiclesForSale.Web.ViewModels.Vehicle;
    using Contracts.Vehicle;
    using Data;

    public class CategoryService : ICategoryService
    {
        private readonly VehiclesDbContext context;

        public CategoryService(VehiclesDbContext _context)
        {
            context = _context;
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
