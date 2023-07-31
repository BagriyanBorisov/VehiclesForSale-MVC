namespace VehiclesForSale.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;

    using ViewModels.Vehicle;
    using Core.Contracts.Extra;

    [Authorize]
    public class ExtraController : Controller
    {
        private IExtraService extraService;

        public ExtraController(IExtraService extraService)
        {
            this.extraService = extraService;
        }

        public async Task<ActionResult> AddExtraForVehicle(string id)
        {
            var extra = await extraService.GetAddExtraAsync(id);

            return View(extra);
        }

        [HttpPost]
        public async Task<ActionResult> AddExtraForVehicle(string id,ExtraFormViewModel extraVm)
        {
            string? userId = GetUserId();
            await extraService.AddExtraAsync(extraVm, userId!, id);

            return RedirectToAction("YourVehicles", "Vehicle");
        }

        private string? GetUserId()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
