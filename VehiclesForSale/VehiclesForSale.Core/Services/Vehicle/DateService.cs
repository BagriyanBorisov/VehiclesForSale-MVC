namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;
    
    using Data;
    using Contracts.Vehicle;
    using Data.Models.VehicleModel;
    using Data.Models.VehicleModel.Enums;

    public class DateService : IDateService
    {
        private readonly VehiclesDbContext context;

        public DateService(VehiclesDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(int name)
        {
            var entities = new List<Date>();
            for (int month = 1; month <= 12; month++)
            {
                entities.Add(new Date { Year = name, Month = (Month)month });
            }
            await context.Dates.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var entityToDel = await context.Dates.Where(m => m.Year.ToString() == Id).ToListAsync();
            if (entityToDel == null)
            {
                throw new NullReferenceException("This Year does not exist!");
            }

            context.Dates.RemoveRange(entityToDel);
            await context.SaveChangesAsync();

        }

        public async Task<bool> CheckByNameExist(int name)
        {
            return await context.Dates.Where(m => m.Year == name).AnyAsync();
        }

        public async Task<IEnumerable<int>> GetAllAsync()
        {
            return await context.Dates
                .Select(date => date.Year)
                .Distinct()
                .OrderByDescending(d => d).ToArrayAsync();

        }
    }

}