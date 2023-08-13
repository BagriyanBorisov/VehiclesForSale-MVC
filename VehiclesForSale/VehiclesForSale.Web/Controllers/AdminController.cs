using VehiclesForSale.Core.Contracts.Admin;

namespace VehiclesForSale.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Core.Contracts.Extra;
    using Core.Contracts.Vehicle;
    using ViewModels.AdminPanel;
    using static Common.GeneralConstants;
    using ViewModels;

    [Route("Admin")]
    [Authorize(Roles = AdminRoleName)]
    public class AdminController : Controller
    {
        private readonly IModelService modelService;
        private readonly IMakeService makeService;
        private readonly ITransmissionTypeService transmissionTypeService;
        private readonly IFuelTypeService fuelTypeService;
        private readonly IColorService colorService;
        private readonly ICategoryService categoryService;
        private readonly IDateService dateService;
        private readonly IExtraService extraService;
        private readonly IAdminService adminService;

        public AdminController(
            IModelService modelService,
            IMakeService makeService,
            ITransmissionTypeService transmissionTypeService,
            IFuelTypeService fuelTypeService,
            IColorService colorService,
            ICategoryService categoryService,
            IDateService dateService,
            IExtraService extraService,
            IAdminService adminService)
        {
            this.makeService = makeService;
            this.modelService = modelService;
            this.transmissionTypeService = transmissionTypeService;
            this.fuelTypeService = fuelTypeService;
            this.colorService = colorService;
            this.categoryService = categoryService;
            this.dateService = dateService;
            this.extraService = extraService;
            this.adminService = adminService;

        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (User?.IsInRole(AdminRoleName) ?? false)
            {
                return View();
            }
            return RedirectToAction("Index", "Vehicle");
        }

        [HttpGet]
        [Route("Users")]
        public async Task<IActionResult> Users(int? pageNumber)
        {
            int pageSize = 10;
            if (User?.IsInRole(AdminRoleName) ?? false)
            {
                var users = await adminService.GetUsersAsync();
                return View(PaginatedList<AdminPanelUserViewModel>.Create(users, pageNumber ?? 1, pageSize));
            }
            return RedirectToAction("Index", "Vehicle");
        }

        [HttpGet]
        [Route("MakesAndModels")]
        public async Task<IActionResult> MakesAndModels(string? errorMsg)
        {
            var vm = new MakesAndModelsViewModel()
            {
                Makes = await makeService.GetAllAsync(),
                Models = await modelService.GetForAllMakesAsync()
            };
            ViewBag.ErrorMessage = errorMsg;
            return View(vm);
        }

        [HttpGet]
        [Route("TypesCrud")]
        public async Task<IActionResult> TypesCrud(string? errorMsg)
        {
            var vm = new TypesViewModel()
            {
                TransmissionTypes = await transmissionTypeService.GetAllAsync(),
                Categories = await categoryService.GetAllAsync(),
                Colors = await colorService.GetAllAsync(),
                FuelTypes = await fuelTypeService.GetAllAsync(),
                Years = await dateService.GetAllAsync(),
            };
            ViewBag.ErrorMessage = errorMsg;
            return View(vm);
        }

        [HttpGet]
        [Route("ExtrasCrud")]
        public async Task<IActionResult> ExtrasCrud(string? errorMsg)
        {
            var vm = new ExtrasCrudViewModel()
            {
                InteriorExtras = await extraService.GetInteriorExtrasAsync(),
                ExteriorExtras = await extraService.GetExteriorExtrasAsync(),
                SafetyExtras = await extraService.GetSafetyExtrasAsync(),
                ComfortExtras = await extraService.GetComfortExtrasAsync(),
                OtherExtras = await extraService.GetOtherExtrasAsync()
            };
            ViewBag.ErrorMessage = errorMsg;
            return View(vm);
        }

        [HttpPost]
        [Route("AddInterior")]
        public async Task<IActionResult> AddInterior(ExtrasCrudViewModel vm)
        {
            if (vm.InteriorNew == null)
            {
                return RedirectToAction("ExtrasCrud", "Admin", new { errorMsg = "The interior extra cannot be null or empty!" });
            }
            else if (await extraService.CheckInteriorByNameExist(vm.InteriorNew!))
            {
                return RedirectToAction("ExtrasCrud", "Admin", new { errorMsg = "This interior extra already exists!" });
            }

            await extraService.AddInteriorAsync(vm.InteriorNew!);
            return RedirectToAction("ExtrasCrud");
        }

        [HttpPost]
        [Route("AddExterior")]
        public async Task<IActionResult> AddExterior(ExtrasCrudViewModel vm)
        {
            if (vm.ExteriorNew == null)
            {
                return RedirectToAction("ExtrasCrud", "Admin",
                    new { errorMsg = "The exterior extra cannot be null or empty!" });
            }
            else if (await extraService.CheckExteriorByNameExist(vm.ExteriorNew!))
            {
                return RedirectToAction("ExtrasCrud", "Admin",
                    new { errorMsg = "This exterior extra already exists!" });
            }

            await extraService.AddExteriorAsync(vm.ExteriorNew!);
            return RedirectToAction("ExtrasCrud");
        }

        [HttpPost]
        [Route("AddSafety")]
        public async Task<IActionResult> AddSafety(ExtrasCrudViewModel vm)
        {
            if (vm.SafetyNew == null)
            {
                return RedirectToAction("ExtrasCrud", "Admin",
                    new { errorMsg = "The safety extra cannot be null or empty!" });
            }
            else if (await extraService.CheckSafetyByNameExist(vm.SafetyNew!))
            {
                return RedirectToAction("ExtrasCrud", "Admin",
                    new { errorMsg = "This safety extra already exists!" });
            }

            await extraService.AddSafetyAsync(vm.SafetyNew!);
            return RedirectToAction("ExtrasCrud");
        }

        [HttpPost]
        [Route("AddComfort")]
        public async Task<IActionResult> AddComfort(ExtrasCrudViewModel vm)
        {
            if (vm.ComfortNew == null)
            {
                return RedirectToAction("ExtrasCrud", "Admin",
                    new { errorMsg = "The comfort extra cannot be null or empty!" });
            }
            else if (await extraService.CheckComfortByNameExist(vm.ComfortNew!))
            {
                return RedirectToAction("ExtrasCrud", "Admin",
                    new { errorMsg = "This comfort extra already exists!" });
            }

            await extraService.AddComfortAsync(vm.ComfortNew!);
            return RedirectToAction("ExtrasCrud");
        }

        [HttpPost]
        [Route("AddOther")]
        public async Task<IActionResult> AddOther(ExtrasCrudViewModel vm)
        {
            if (vm.OtherNew == null)
            {
                return RedirectToAction("ExtrasCrud", "Admin",
                    new { errorMsg = "The other extra cannot be null or empty!" });
            }
            else if (await extraService.CheckOtherByNameExist(vm.OtherNew!))
            {
                return RedirectToAction("ExtrasCrud", "Admin",
                    new { errorMsg = "This other extra already exists!" });
            }

            await extraService.AddOtherAsync(vm.OtherNew!);
            return RedirectToAction("ExtrasCrud");
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory(TypesViewModel vm)
        {
            if (vm.CategoryNew == null)
            {
                return RedirectToAction("TypesCrud", "Admin", new { errorMsg = "The category cannot be null or empty!" });
            }
            else if (await categoryService.CheckByNameExist(vm.CategoryNew))
            {
                return RedirectToAction("TypesCrud", "Admin", new { errorMsg = "This category already exists!" });
            }

            await categoryService.AddAsync(vm.CategoryNew);
            return RedirectToAction("TypesCrud");
        }

        [HttpPost]
        [Route("AddFuel")]
        public async Task<IActionResult> AddFuel(TypesViewModel vm)
        {
            if (vm.FuelNew == null)
            {
                return RedirectToAction("TypesCrud", "Admin", new { errorMsg = "The fuel cannot be null or empty!" });
            }
            else if (await fuelTypeService.CheckByNameExist(vm.FuelNew))
            {
                return RedirectToAction("TypesCrud", "Admin", new { errorMsg = "This fuel already exists!" });
            }

            await fuelTypeService.AddAsync(vm.FuelNew);
            return RedirectToAction("TypesCrud");
        }

        [HttpPost]
        [Route("AddColor")]
        public async Task<IActionResult> AddColor(TypesViewModel vm)
        {
            if (vm.ColorNew == null)
            {
                return RedirectToAction("TypesCrud", "Admin", new { errorMsg = "The Color cannot be null or empty!" });
            }
            else if (await colorService.CheckByNameExist(vm.ColorNew))
            {
                return RedirectToAction("TypesCrud", "Admin", new { errorMsg = "This Color already exists!" });
            }

            await colorService.AddAsync(vm.ColorNew);
            return RedirectToAction("TypesCrud");
        }

        [HttpPost]
        [Route("AddTransmission")]
        public async Task<IActionResult> AddTransmission(TypesViewModel vm)
        {
            if (vm.TransmissionNew == null)
            {
                return RedirectToAction("TypesCrud", "Admin",
                    new { errorMsg = "The Transmission Type cannot be null or empty!" });
            }
            else if (await transmissionTypeService.CheckByNameExist(vm.TransmissionNew))
            {
                return RedirectToAction("TypesCrud", "Admin", new { errorMsg = "This Transmission Type already exists!" });
            }

            await transmissionTypeService.AddAsync(vm.TransmissionNew);
            return RedirectToAction("TypesCrud");
        }

        [HttpPost]
        [Route("AddYear")]
        public async Task<IActionResult> AddYear(TypesViewModel vm)
        {
            if (vm.YearNew == null)
            {
                return RedirectToAction("TypesCrud", "Admin",
                    new { errorMsg = "The Year cannot be null or empty!" });
            }
            else if (await dateService.CheckByNameExist((int)vm.YearNew))
            {
                return RedirectToAction("TypesCrud", "Admin", new { errorMsg = "This Year already exists!" });
            }

            await dateService.AddAsync((int)vm.YearNew);
            return RedirectToAction("TypesCrud");
        }

        [HttpPost]
        [Route("AddMake")]
        public async Task<IActionResult> AddMake(MakesAndModelsViewModel vm)
        {
            if (vm.MakeNew == null)
            {
                return RedirectToAction("MakesAndModels", "Admin", new { errorMsg = "The make cannot be null or empty!" });
            }
            else if (await makeService.CheckByNameExist(vm.MakeNew))
            {

                return RedirectToAction("MakesAndModels", "Admin", new { errorMsg = "This make already exists!" });
            }

            await makeService.AddMakeAsync(vm.MakeNew);
            return RedirectToAction("MakesAndModels");
        }

        [HttpPost]
        [Route("AddModel")]
        public async Task<IActionResult> AddModel(MakesAndModelsViewModel vm)
        {
            if (vm.MakeId == null)
            {
                return RedirectToAction("MakesAndModels", "Admin", new { errorMsg = "The make must be selected!" });
            }

            else if (vm.ModelNew == null)
            {
                return RedirectToAction("MakesAndModels", "Admin", new { errorMsg = "The model cannot be null or empty!" });
            }
            else if (await modelService.CheckByNameExist(vm.ModelNew, vm.MakeId))
            {

                return RedirectToAction("MakesAndModels", "Admin", new { errorMsg = "This model already exists!" });
            }

            await modelService.AddModelAsync(vm.ModelNew, vm.MakeId);
            return RedirectToAction("MakesAndModels");
        }


        [Route("DeleteInterior")]
        public async Task<IActionResult> DeleteInterior(string interiorId)
        {
            await extraService.DeleteInteriorAsync(interiorId);
            return RedirectToAction("ExtrasCrud");
        }

        [Route("DeleteExterior")]
        public async Task<IActionResult> DeleteExterior(string exteriorId)
        {
            await extraService.DeleteExteriorAsync(exteriorId);
            return RedirectToAction("ExtrasCrud");
        }

        [Route("DeleteSafety")]
        public async Task<IActionResult> DeleteSafety(string safetyId)
        {
            await extraService.DeleteSafetyAsync(safetyId);
            return RedirectToAction("ExtrasCrud");
        }

        [Route("DeleteComfort")]
        public async Task<IActionResult> DeleteComfort(string comfortId)
        {
            await extraService.DeleteComfortAsync(comfortId);
            return RedirectToAction("ExtrasCrud");
        }

        [Route("DeleteOther")]
        public async Task<IActionResult> DeleteOther(string otherId)
        {
            await extraService.DeleteOtherAsync(otherId);
            return RedirectToAction("ExtrasCrud");
        }

        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(string categoryId)
        {
            await categoryService.DeleteAsync(categoryId);
            return RedirectToAction("TypesCrud");
        }

        [Route("DeleteFuel")]
        public async Task<IActionResult> DeleteFuel(string FuelId)
        {
            await fuelTypeService.DeleteAsync(FuelId);
            return RedirectToAction("TypesCrud");
        }

        [Route("DeleteColor")]
        public async Task<IActionResult> DeleteColor(string colorId)
        {
            await colorService.DeleteAsync(colorId);
            return RedirectToAction("TypesCrud");
        }

        [Route("DeleteTransmission")]
        public async Task<IActionResult> DeleteTransmission(string transmissionId)
        {
            await transmissionTypeService.DeleteAsync(transmissionId);
            return RedirectToAction("TypesCrud");
        }

        [Route("DeleteYear")]
        public async Task<IActionResult> DeleteYear(string year)
        {
            await dateService.DeleteAsync(year);
            return RedirectToAction("TypesCrud");
        }

        [Route("DeleteMake")]
        public async Task<IActionResult> DeleteMake(string makeId)
        {

            await makeService.DeleteMakeAsync(makeId);
            return RedirectToAction("MakesAndModels");
        }

        [Route("DeleteModel")]
        public async Task<IActionResult> DeleteModel(string modelId)
        {

            await modelService.DeleteModelAsync(modelId);
            return RedirectToAction("MakesAndModels");
        }
    }
}
