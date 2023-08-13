namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Contracts.Vehicle;
    using Data.Models.VehicleModel;
    using Web.ViewModels.Vehicle;

    public class TransmissionTypeService : ITransmissionTypeService
    {
        private readonly VehiclesDbContext context;

        public TransmissionTypeService(VehiclesDbContext _context)
        {
            context = _context;
        }
        public async Task AddAsync(string name)
        {
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            {
                var entityToAdd = new TransmissionType()
                {
                    Name = name,
                };

                await context.TransmissionTypes.AddAsync(entityToAdd);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException("Transmission name is null or empty!");
            }
        }

        public async Task DeleteAsync(string Id)
        {
            var entityToDel = await context.TransmissionTypes.Where(m => m.Id.ToString() == Id).FirstOrDefaultAsync();
            if (entityToDel == null)
            {
                throw new NullReferenceException("This Fuel type does not exist!");
            }
            context.TransmissionTypes.Remove(entityToDel);
            await context.SaveChangesAsync();

        }

        public async Task<bool> CheckByNameExist(string name)
        {
            return await context.TransmissionTypes.Where(m => m.Name.ToLower() == name.ToLower()).AnyAsync();
        }

        public async Task<IEnumerable<TransmissionTypeFormVehicleViewModel>> GetAllAsync()
        {
            var models =
                await context.TransmissionTypes
                    .Select(e => new TransmissionTypeFormVehicleViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name
                    }).ToListAsync();

            return models;
        }
    }
}
