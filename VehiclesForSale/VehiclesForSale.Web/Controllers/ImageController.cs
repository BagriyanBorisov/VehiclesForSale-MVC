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

        public IActionResult Add(string id)
        {
            var imageForm =imageService.GetImageWithVehicle(id);
            
            return View(imageForm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string id, ImageFormViewModel imageVm)
        {
            await imageService.CreateImages(id, imageVm);

            return RedirectToAction("Index", "Vehicle");
        }
    }
}
