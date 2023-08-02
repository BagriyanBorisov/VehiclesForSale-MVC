using VehiclesForSale.Web.ViewModels.Vehicle.Details;
using VehiclesForSale.Web.ViewModels.Vehicle.Index;

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

        public IActionResult Details(string id)
        {
            DetailsVehicleViewModel viewModel = new DetailsVehicleViewModel()
            {
                Id=id,
                CategoryType = "Sedan",
                Color = "Gray",
                ComfortExtras = new List<string>(){"Heated Seats","Heated Steering Wheel"},
                OtherExtras = new List<string>(){"4x4","LPG"},
                InteriorExtras = new List<string>(){ "Infotainment System", "Key-less Entry and Push-button Start." },
                ExteriorExtras = new List<string>(){ "Automatically folding mirrors.", "LED headlights." },
                SafetyExtras = new List<string>(){"ABS","SOS Call"},
                Price = "10000",
                Title = "Mercedes E Klasse 280 CDI",
                CubicCapacity = "3224",
                HorsePower = "177",
                Year = "2005",
                Month = "January",
                Location = "Pleven - Bulgaria",
                Make = "Mercedes-Benz",
                Model = "W211",
                Mileage = "320000",
                Transmission = "Automatic",
                FuelType = "Diesel",
                Images = new List<string>()
                {
                    "/Uploads/a11b0590-58ca-45cb-9112-a37ec0c74220_Merc1.jpg",
                    "/Uploads/a11b0590-58ca-45cb-9112-a37ec0c74220_Merc2.jpg",
                    "/Uploads/a11b0590-58ca-45cb-9112-a37ec0c74220_Merc3.jpg"
                },
                Description = "This is Avantgarde coupe with all his classy looks.",
                MainImage = "/Uploads/a11b0590-58ca-45cb-9112-a37ec0c74220_MainImage_Merc1.jpg"
            };

            return View(viewModel);

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
    }
}

