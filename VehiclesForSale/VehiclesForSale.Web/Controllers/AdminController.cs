namespace VehiclesForSale.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using VehiclesForSale.Core.Contracts.Vehicle;
    using VehiclesForSale.Web.ViewModels.AdminPanel;
    using static Common.GeneralConstants;

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

        public AdminController(
            IModelService modelService,
            IMakeService makeService,
            ITransmissionTypeService transmissionTypeService,
            IFuelTypeService fuelTypeService,
            IColorService colorService,
            ICategoryService categoryService, 
            IDateService dateService)
        {
            this.makeService = makeService;
            this.modelService = modelService;
            this.transmissionTypeService = transmissionTypeService;
            this.fuelTypeService = fuelTypeService;
            this.colorService = colorService;
            this.categoryService = categoryService;
            this.dateService = dateService;

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index(string? errorMsg)
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
            if(vm.MakeNew == null)
            {
                return RedirectToAction("Index", "Admin", new {errorMsg = "The make cannot be null or empty!" });
            }
            else if(await makeService.CheckByNameExist(vm.MakeNew))
            {
              
                return RedirectToAction("Index", "Admin", new { errorMsg = "This make already exists!" });
            }

            await makeService.AddMakeAsync(vm.MakeNew);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("AddModel")]
        public async Task<IActionResult> AddModel(MakesAndModelsViewModel vm)
        {
            if(vm.MakeId == null)
            {
                return RedirectToAction("Index", "Admin", new { errorMsg = "The make must be selected!" });
            }

            else if (vm.ModelNew == null)
            {
                return RedirectToAction("Index", "Admin", new { errorMsg = "The model cannot be null or empty!" });
            }
            else if (await modelService.CheckByNameExist(vm.ModelNew, vm.MakeId))
            {

                return RedirectToAction("Index", "Admin", new { errorMsg = "This model already exists!" });
            }

            await modelService.AddModelAsync(vm.ModelNew, vm.MakeId);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        [Route("DeleteModel")]
        public async Task<IActionResult> DeleteModel(string modelId)
        {

            await modelService.DeleteModelAsync(modelId);
            return RedirectToAction("Index");
        }
    }
}
