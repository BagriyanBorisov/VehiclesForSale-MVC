using VehiclesForSale.Data;

namespace VehiclesForSale.Core.Services.Vehicle
{
    using Web.ViewModels.Vehicle;
    using Contracts.Vehicle;
    public class VehicleService : IVehicleService
    {
        private readonly VehiclesDbContext context;

        private readonly ICategoryService categoryService;
        private readonly IColorService colorService;
        private readonly IFuelTypeService fuelTypeService;
        private readonly IMakeService makeService;
        private readonly IModelService modelService;
        private readonly ITransmissionTypeService transmissionService;

        public VehicleService(
            VehiclesDbContext context,
            ICategoryService categoryService,
            IColorService colorService,
            IFuelTypeService fuelTypeService,
            IMakeService makeService,
            IModelService modelService,
            ITransmissionTypeService transmissionService)
        {
            this.context = context;
            this.categoryService = categoryService;
            this.colorService = colorService;
            this.fuelTypeService = fuelTypeService;
            this.makeService = makeService;
            this.modelService = modelService;
            this.transmissionService = transmissionService;
        }

        public async Task<VehicleFormViewModel> GetForAddVehicleAsync()
        {
            var vehicleVm = new VehicleFormViewModel();
            vehicleVm.Categories = await categoryService.GetAllAsync();
            vehicleVm.Colors = await colorService.GetAllAsync();
            vehicleVm.FuelTypes = await fuelTypeService.GetAllAsync();
            vehicleVm.Makes = await makeService.GetAllAsync();
            vehicleVm.TransmissionTypes = await transmissionService.GetAllAsync();
            vehicleVm.Models = await modelService.GetAllAsync(1);

            return vehicleVm;
        }
    }
}
