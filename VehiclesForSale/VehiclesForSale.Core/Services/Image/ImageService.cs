using Microsoft.EntityFrameworkCore;

namespace VehiclesForSale.Core.Services.Image
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;

    using VehiclesForSale.Core.Contracts.Image;
    using VehiclesForSale.Core.Contracts.Vehicle;

    using Data;
    using VehiclesForSale.Web.ViewModels.Vehicle;
    using Image = Data.Models.VehicleModel.Image;
    public class ImageService : IImageService
    {
     
        private readonly VehiclesDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ImageService(VehiclesDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.context = context;
        }

        public async Task<ImageFormViewModel> GetImageWithVehicle(string vehicleId)
        {
            var imageForm = new ImageFormViewModel()
            {
                VehicleId = vehicleId,
                VehicleName = "Nz brat"
            };


            return imageForm;
        }

        public async Task CreateImages(string id,ImageFormViewModel imageVm)
        {
            foreach (var image in imageVm.Images)
            {
                string imageUrl = await UploadImage(image, id);
                Image imageModel = new Image()
                {
                    ImageUrl = imageUrl,
                    VehicleId = Guid.Parse((ReadOnlySpan<char>)id)
                };

                await context.Images.AddAsync(imageModel);
            }

            await context.SaveChangesAsync();
        }

        private async Task<string> UploadImage(IFormFile image, string vehicleId)
        {
            string fileName = null;
            if (image != null)
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                fileName = vehicleId + "_" + image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                   await image.CopyToAsync(fileStream);
                }
            }

            return fileName;
        }

        public async Task<string> GetPathById(string id)
        {
            var image = await context.Images.FirstOrDefaultAsync(i => i.VehicleId.ToString() == id);

            if (image == null)
            {
                return null;
                //TODO: ADD NO IMAGES - IMAGE
            }

            return image?.ImageUrl!;
        }
    }
}
