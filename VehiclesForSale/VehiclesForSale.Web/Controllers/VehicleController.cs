namespace VehiclesForSale.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Core.Contracts.Vehicle;
    using ViewModels.Vehicle;
    
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var vehicleVm = await vehicleService.GetForAddVehicleAsync();
         
            return View(vehicleVm);
        }
    }
}
