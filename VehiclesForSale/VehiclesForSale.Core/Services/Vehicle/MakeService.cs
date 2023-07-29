namespace VehiclesForSale.Core.Services.Vehicle
{
    using Microsoft.EntityFrameworkCore;
    using VehiclesForSale.Web.ViewModels.Vehicle;
    using Contracts.Vehicle;
    using Data;
    public class MakeService :  IMakeService
    {
        private readonly VehiclesDbContext context;
        private readonly IModelService modelService;

        public MakeService(VehiclesDbContext context, IModelService modelService)
        {
            this.context = context;
            this.modelService = modelService;
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
