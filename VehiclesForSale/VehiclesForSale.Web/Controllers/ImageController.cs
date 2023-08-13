namespace VehiclesForSale.Web.Controllers
{
    using Core.Contracts.Image;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using ViewModels.Vehicle;

    public class ImageController : Controller
    {

        private readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public async Task<IActionResult> Add(string id)
        {
            var userId = GetUserId();
            if (await imageService.CheckOwner(id, userId))
            {
                var imageForm = await imageService.GetImageWithVehicle(id);
                return View(imageForm);
            }

            return RedirectToAction("Index", "Error");

        }

        private string? GetUserId()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Add(string vehicleId, ImageFormViewModel imageVm)
        {
            await imageService.CreateImages(vehicleId, imageVm);

            return RedirectToAction("Add", "Image", new { id = vehicleId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var userId = GetUserId();
            if (await imageService.CheckOwner(id, userId))
            {
                var imageForm = await imageService.GetImageWithVehicle(id);
                return View(imageForm);
            }

            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string vehicleId, ImageFormViewModel imageVm)
        {
            await imageService.CreateImages(vehicleId, imageVm);

            return RedirectToAction("Edit", "Image", new { id = vehicleId });
        }

        public async Task<IActionResult> Delete(string imageId, string vehicleId)
        {
            var userId = GetUserId();
            if (await imageService.CheckOwner(vehicleId, userId))
            {
                await imageService.DeleteImageById(imageId, vehicleId);

                return RedirectToAction("Edit", "Image", new { id = vehicleId });
            }

             return RedirectToAction("Index", "Error");
    }
    }
}
