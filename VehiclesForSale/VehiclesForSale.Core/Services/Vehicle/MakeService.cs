namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;
   
    using Data;
    using Contracts.Vehicle;
    using Data.Models.VehicleModel; 
    using Web.ViewModels.Vehicle;
    public class MakeService : IMakeService
    {
        private readonly VehiclesDbContext context;


        public MakeService(VehiclesDbContext context)
        {
            this.context = context;

        }

        public async Task AddMakeAsync(string makeName)
        {
            if (!string.IsNullOrEmpty(makeName) || !string.IsNullOrWhiteSpace(makeName))
            {
                var makeToAdd = new Make()
                {
                    Name = makeName,
                };

                await context.Makes.AddAsync(makeToAdd);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> CheckByNameExist(string makeName)
        {
            return await context.Makes.Where(m => m.Name.ToLower() == makeName.ToLower()).AnyAsync();
        }

        public async Task DeleteMakeAsync(string makeId)
        {
            var makeToDel = await context.Makes.Where(m => m.Id.ToString() == makeId).FirstOrDefaultAsync();
            if (makeToDel == null)
            {
                throw new NullReferenceException("This make does not exist!");
            }
            var modelsToDel = await context.Models.Where(m => m.MakeId.ToString() == makeId).ToListAsync();

            context.Models.RemoveRange(modelsToDel);
            context.Makes.Remove(makeToDel);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MakeFormVehicleViewModel>> GetAllAsync()
        {
            var makes =
                await context.Makes
                    .Select(e => new MakeFormVehicleViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name
                    }).ToListAsync();
            return makes;
        }
    }
}
