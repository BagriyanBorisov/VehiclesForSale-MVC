namespace VehiclesForSale.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts.Vehicle;
    using ViewModels.Vehicle;
    using System.Security.Claims;
    

    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var models = await vehicleService.GetAllVehiclesAsync();
            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var vehicleVm = await vehicleService.GetForAddVehicleAsync();

            return View(vehicleVm);
        }


        [HttpPost]
        public async Task<IActionResult> Add(VehicleFormViewModel vehicleVm)
        {
            
            if (!ModelState.IsValid)
            {
                return View(vehicleVm);
            }
            string? userId = GetUserId();
            await vehicleService.AddVehicleAsync(vehicleVm, userId!);

                var vehicleId = vehicleVm.Id.ToString();
                return RedirectToAction("Add", "Image", new { id = vehicleId });

        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Search()
        {
            var vehicleVm = await vehicleService.GetForAddVehicleAsync();

            return View(vehicleVm);
        }


        [HttpGet]
        public async Task<IActionResult> YourVehicles()
        {
            string? userId = GetUserId();
            var models = await vehicleService.GetUserVehiclesAsync(userId!);
            return View(models);
        }

       
        public async Task<IActionResult> Delete(string id)
        {
            string? userId = GetUserId();
            await vehicleService.DeleteVehicleAsync(id, userId!);

            return RedirectToAction("YourVehicles", "Vehicle");

        }

        private string? GetUserId()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}

