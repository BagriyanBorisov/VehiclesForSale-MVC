namespace VehiclesForSale.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    using Core.Contracts.Extra;
    using ViewModels.Vehicle;

    [Authorize]
    public class ExtraController : Controller
    {
        private readonly IExtraService extraService;

        public ExtraController(IExtraService extraService)
        {
            this.extraService = extraService;
        }

        public async Task<ActionResult> AddExtraForVehicle(string id)
        {
            var userId = GetUserId();
            if (await extraService.CheckOwner(id, userId))
            {
                var extra = await extraService.GetAddExtraAsync(id);

                return View(extra);
            }

            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<ActionResult> AddExtraForVehicle(string id, ExtraFormViewModel extraVm)
        {
            string? userId = GetUserId();
            await extraService.AddExtraAsync(extraVm, userId!, id);

            return RedirectToAction("YourVehicles", "Vehicle");
        }

        private string? GetUserId()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        public async Task<ActionResult> EditExtraForVehicle(string id)
        {
            var userId = GetUserId();
            if (await extraService.CheckOwner(id, userId))
            {
                var extra = await extraService.GetEditExtraAsync(id);
                return View(extra);
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<ActionResult> EditExtraForVehicle(string id, ExtraFormViewModel extraVm)
        {
            string? userId = GetUserId();
            await extraService.EditExtraAsync(extraVm, userId!, id);

            return RedirectToAction("YourVehicles", "Vehicle");
        }
    }
}
