﻿namespace VehiclesForSale.Web.Controllers
{
    using Core.Contracts.Vehicle;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using ViewModels.Vehicle;
    using ViewModels.Vehicle.Index;
    using ViewModels.Vehicle.Search;

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
            var vehicleVm = await vehicleService.GetForSearchAsync();
           

            return View(vehicleVm);
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Search(VehicleSearchViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            string makeId = vm.MakeId.ToString();
            string modelId = vm.ModelId.ToString();
            string transmissionId = vm.TransmissionTypeId.ToString();
            string yearTo = vm.SelectedYearTo.ToString();
            string yearFrom = vm.SelectedYearFrom.ToString();
            string priceTo = vm.PriceTo.ToString();
            string priceFrom = vm.PriceFrom.ToString();
            string body = vm.CategoryTypeId.ToString();
            string color = vm.ColorId.ToString();
            string mileageTo = vm.MileageTo.ToString();
            string cubicCapacityTo = vm.CubicCapacityTo.ToString();
            string horsePowerTo = vm.HorsePowerTo.ToString();
            string fuelType = vm.FuelTypeId.ToString();

            return RedirectToAction("Filtered", "Vehicle", new
            {
                MakeId = makeId,
                ModelId = modelId,
                TransmissionTypeId = transmissionId,
                SelectedYearTo = yearTo,
                SelectedYearFrom = yearFrom,
                PriceTo = priceTo,
                PriceFrom = priceFrom,
                CategoryTypeId = body,
                ColorId = color,
                MileageTo = mileageTo,
                CubicCapacityTo = cubicCapacityTo,
                HorsePowerTo = horsePowerTo,
                FuelTypeId = fuelType
            });
        }

        
        [AllowAnonymous]
        public async Task<IActionResult> Filtered(
            string MakeId, string ModelId, string TransmissionTypeId,
            string SelectedYearTo, string SelectedYearFrom,
            string PriceTo, string PriceFrom, string CategoryTypeId,
            string ColorId, string MileageTo, string CubicCapacityTo,
            string HorsePowerTo, string FuelTypeId)
        {

            var filteredVehicles = await vehicleService.GetFilteredAsync(
              MakeId, ModelId, TransmissionTypeId,
              SelectedYearTo, SelectedYearFrom,
              PriceTo, PriceFrom, CategoryTypeId,
              ColorId, MileageTo, CubicCapacityTo,
              HorsePowerTo, FuelTypeId);

            var vehicleCollection = new VehicleCollectionViewModel()
            {
                Vehicles = filteredVehicles
            };

            return View("Filtered",vehicleCollection);
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

