namespace VehiclesForSale.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Vehicle;

    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            VehicleFormViewModel vehicleVm = new VehicleFormViewModel()
            {
                
                Categories = new List<CategoryFormVehicleViewModel>(),
                Makes = new List<MakeFormVehicleViewModel>(),
                Models = new List<ModelFormVehicleViewModel>(),
                FuelTypes = new List<FuelTypeFormVehicleViewModel>(),
                Colors = new List<ColorFormVehicleViewModel>(),
                TransmissionTypes = new List<TransmissionTypeFormVehicleViewModel>()
            };
            return View(vehicleVm);
        }
    }
}
