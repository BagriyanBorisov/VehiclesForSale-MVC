using Microsoft.EntityFrameworkCore;

namespace VehiclesForSale.Core.Services.Image
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;

    using VehiclesForSale.Core.Contracts.Image;

    using Data;
    using VehiclesForSale.Web.ViewModels.Vehicle;
    using System.Collections.Generic;
    using System.IO;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Processing;


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
            var vehicleName = await context.Vehicles
                .Where(v => v.Id.ToString() == vehicleId)
                .Select(v => v.Title)
                .FirstOrDefaultAsync();

            var imageForm = new ImageFormViewModel()
            {
                VehicleId = vehicleId,
                VehicleName = vehicleName!
            };
            return imageForm;
        }

        public async Task CreateImages(string id,ImageFormViewModel imageVm)
        {
            bool isFirst = true;
            foreach (var image in imageVm.Images)
            {
                string imageUrl = await UploadImage(image, id, isFirst);
                var imageModel = new Data.Models.VehicleModel.Image()
                {
                    ImageUrl = imageUrl,
                    VehicleId = Guid.Parse((ReadOnlySpan<char>)id)
                };

                await context.Images.AddAsync(imageModel);
                isFirst = false;
            }

            await context.SaveChangesAsync();
        }


        //private async Task<string> UploadImage(IFormFile image, string vehicleId)
        //{
        //    string fileName = null;
        //    if (image != null)
        //    {
        //        string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
        //        fileName = vehicleId + "_" + image.FileName;
        //        string filePath = Path.Combine(uploadDir, fileName);

        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await image.CopyToAsync(fileStream);
        //        }

        //        // Resize the image after saving
        //        using (var originalImage = Image.Load(filePath))
        //        using (var resizedImage = ResizeImage(originalImage, 1024, 768))
        //        {
        //            // Save the resized image, overwriting the original file
        //            resizedImage.Save(filePath);
        //        }
        //    }

        //    return fileName;
        //}

        private async Task<string> UploadImage(IFormFile image, string vehicleId, bool isFirst)
        {
            string fileName = null;
            if (image.Length != 0)
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                fileName = vehicleId + "_" + image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                // Resize the image after saving
                if (isFirst)
                {
                    string resizedFileName = vehicleId + "_MainImage_" + image.FileName;
                    string resizedFilePath = Path.Combine(uploadDir, resizedFileName);

                    using (var originalImage = Image.Load(filePath))
                    using (var resizedImage = ResizeImage(originalImage, 1024, 768))
                    {
                        // Save the resized image with the new filename
                        resizedImage.Save(resizedFilePath);
                    }
                    var imageModel = new Data.Models.VehicleModel.Image()
                    {
                        ImageUrl = resizedFileName,
                        VehicleId = Guid.Parse((ReadOnlySpan<char>)vehicleId)
                    };

                    await context.Images.AddAsync(imageModel);
                }
            }
            return fileName;
        }


        public async Task<string> GetPathById(string id)
        {
            //Gets main image for index view
            string imgPath = id.ToLower() + "_MainImage";
            var image = await context.Images.FirstOrDefaultAsync(i => i.ImageUrl.Contains(imgPath));

            if (image == null)
            {
                return null;
                //TODO: ADD NO IMAGES - IMAGE
            }

            return image?.ImageUrl!;
        }

        public async Task DeleteImage(ICollection<Data.Models.VehicleModel.Image> imagesCollection, string vehicleId)
        {
            foreach (var image in imagesCollection)
            {
                var filePath = Path.Combine(webHostEnvironment.WebRootPath, "Uploads") + "/" + image.ImageUrl;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            context.Images.RemoveRange(imagesCollection);
            await context.SaveChangesAsync();
        }


        private Image ResizeImage(Image sourceImage, int newWidth, int newHeight)
        {
            using (var ms = new MemoryStream())
            {
                // Resize the image
                sourceImage.Mutate(ctx => ctx.Resize(new ResizeOptions
                {
                    Mode = ResizeMode.Crop, // Crop to fit in index view
                    Size = new Size(newWidth, newHeight)
                }));

                // Save the resized image to a memory stream
                sourceImage.Save(ms, new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder());

                // Create a new Image instance from the memory stream
                return Image.Load(ms.ToArray());
            }
        }
    }
}
