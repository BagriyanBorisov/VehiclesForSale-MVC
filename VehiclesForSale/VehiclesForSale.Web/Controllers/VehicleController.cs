using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace VehiclesForSale.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts.Vehicle;
    using ViewModels.Vehicle;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc.Rendering;

    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IModelService modelService;

        public VehicleController(IVehicleService vehicleService, IModelService modelService)
        {
            this.vehicleService = vehicleService;
            this.modelService = modelService;
        }

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

        private string? GetUserId()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}

