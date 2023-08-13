using Microsoft.EntityFrameworkCore;

namespace VehiclesForSale.Core.Services.Image
{
    using Data;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Processing;
    using System.Collections.Generic;
    using System.IO;
    using VehiclesForSale.Core.Contracts.Image;
    using VehiclesForSale.Web.ViewModels.Vehicle;


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
            var vehicle = await context.Vehicles
                .Where(v => v.Id.ToString() == vehicleId)
                .Include(v => v.ImageCollection)
                .FirstOrDefaultAsync();

            if (vehicle == null)
            {
                throw new NullReferenceException("This vehicle does not exist.");
            }


            var imageForm = new ImageFormViewModel()
            {
                VehicleId = vehicleId,
                VehicleName = vehicle.Title,
                ImagesForTable = vehicle.ImageCollection.Select(i => new Web.ViewModels.ImageViewModel
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl
                }).ToList()
            };

            foreach (var image in imageForm.ImagesForTable)
            {
                char[] array = image.ImageUrl.ToCharArray();
                var charArr = image.ImageUrl.Skip(Array.IndexOf(array, '_'));
                string name = string.Empty;
                foreach (var ch in charArr)
                {
                    name += ch;
                }
                image.Name = name;
            }

            return imageForm;
        }

        public async Task CreateImages(string id, ImageFormViewModel imageVm)
        {
            var vehicle = await context.Vehicles
                .Where(v => v.Id.ToString().Equals(id))
                .Include(v => v.ImageCollection).AsNoTracking().FirstOrDefaultAsync();

            if (vehicle == null)
            {
                throw new NullReferenceException("Vehicle does not exist");
            }

            bool isFirst = true;
            foreach (var item in vehicle.ImageCollection)
            {
                if (item.ImageUrl.Contains("_MainImage_"))
                {
                    isFirst = false;
                }
            }

            if (imageVm.Images.Count + vehicle.ImageCollection.Count < 17)
            {
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

        }

        private async Task<string> UploadImage(IFormFile image, string vehicleId, bool isFirst)
        {
            string fileName = string.Empty;
            if (image.Length != 0)
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                fileName = vehicleId + "_" + image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

               await using (var fileStream = new FileStream(filePath, FileMode.Create))
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
                        await resizedImage.SaveAsync(resizedFilePath);
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

        public async Task DeleteImageById(string imageId, string vehicleId)
        {
            var image = await context.Images.FirstOrDefaultAsync(i => i.Id.ToString() == imageId);
            var vehicleToDel = await context.Vehicles
                .Where(v => v.Id.ToString() == vehicleId)
                .Include(v => v.ImageCollection)
                .FirstOrDefaultAsync();

            if (image == null)
            {
                throw new NullReferenceException("Image does not exist");
            }

            if (vehicleToDel == null)
            {
                throw new NullReferenceException("Vehicle does not exist");
            }

            var filePath = Path.Combine(webHostEnvironment.WebRootPath, "Uploads") + "/" + image.ImageUrl;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            vehicleToDel.ImageCollection.Remove(image);
            context.Images.Remove(image);
            await context.SaveChangesAsync();
        }

        public async Task<bool> CheckOwner(string vehicleId, string userId)
        {
            return await context.Vehicles
                .Where(v => v.Id.ToString() == vehicleId && v.OwnerId == userId).AnyAsync();
        }
    }
}
