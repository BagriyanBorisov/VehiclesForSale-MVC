namespace VehiclesForSale.Web.Controllers
{
    using Core.Contracts.Vehicle;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using ViewModels.Vehicle;
    using ViewModels.Vehicle.Index;

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
            var vehicleCollection = new VehicleCollectionViewModel()
            {
                Vehicles = await vehicleService.GetAllVehiclesAsync()
            };
            return View(vehicleCollection);
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

        [HttpPost]
        public async Task<IActionResult> Edit(VehicleFormViewModel vehicleVm)
        {
            if (!ModelState.IsValid)
            {
                return View(vehicleVm);
            }

            string? userId = GetUserId();
            await vehicleService.EditVehicleAsync(vehicleVm, userId!);


            var vehicleId = vehicleVm.Id.ToString();
            return RedirectToAction("Edit", "Image", new { id = vehicleId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            string? userId = GetUserId();
            var vehicleVm = await vehicleService.GetForEditVehicleAsync(id, userId!);
            return View(vehicleVm);
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


        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            var userId = GetUserId();
            var detailsVm = await vehicleService.GetForDetailsVehicleAsync(userId, id);

            return View(detailsVm);

        }

        [HttpPost]
        public async Task<IEnumerable<ModelFormVehicleViewModel>> GetModelValues(string id)
        {

            var modelsForMake = await vehicleService.GetModels(id);
            return modelsForMake;
        }

        private string? GetUserId()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }


        public async Task<IActionResult> AddToWatchList(string vehicleId)
        {
            string? userId = GetUserId();
            await vehicleService.AddVehicleToWatchListAsync(userId!, vehicleId);
            return RedirectToAction("Details", "Vehicle", new { id = vehicleId });
        }

        public async Task<IActionResult> DeleteFromWatchList(string vehicleId)
        {
            string? userId = GetUserId();
            await vehicleService.DeleteVehicleFromWatchListAsync(userId!, vehicleId);
            return RedirectToAction("Details", "Vehicle", new { id = vehicleId });
        }

        [HttpGet]
        public async Task<IActionResult> WatchList()
        {
            string? userId = GetUserId();
            var models = await vehicleService.GetWatchListAsync(userId!);
            return View(models);
        }
    }
}

