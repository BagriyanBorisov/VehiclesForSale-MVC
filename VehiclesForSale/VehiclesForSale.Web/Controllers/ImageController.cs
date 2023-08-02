namespace VehiclesForSale.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Core.Contracts.Image;
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
            var imageForm = await imageService.GetImageWithVehicle(id);
            
            return View(imageForm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string vehicleId, ImageFormViewModel imageVm)
        {
            await imageService.CreateImages(vehicleId, imageVm);

            return RedirectToAction("AddExtraForVehicle", "Extra", new { id = vehicleId });
        }
    }
}
