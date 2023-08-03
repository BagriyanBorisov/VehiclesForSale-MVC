namespace VehiclesForSale.Core.Services.Vehicle
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using Web.ViewModels.Vehicle;
    using Contracts.Vehicle;
    using Data;
    using Data.Models.VehicleModel;
    using Web.ViewModels.Vehicle.Index;
    using Data.Models.VehicleModel.Enums;
    using Core.Contracts.Image;
    using Web.ViewModels.Vehicle.Details;

    public class VehicleService : IVehicleService
    {
        private readonly VehiclesDbContext context;

        private readonly ICategoryService categoryService;
        private readonly IColorService colorService;
        private readonly IFuelTypeService fuelTypeService;
        private readonly IMakeService makeService;
        private readonly IModelService modelService;
        private readonly ITransmissionTypeService transmissionService;
        private readonly IImageService imageService;

        public VehicleService(
            VehiclesDbContext context,
            ICategoryService categoryService,
            IColorService colorService,
            IFuelTypeService fuelTypeService,
            IMakeService makeService,
            IModelService modelService,
            ITransmissionTypeService transmissionService,
            IImageService imageService)
        {
            this.context = context;
            this.categoryService = categoryService;
            this.colorService = colorService;
            this.fuelTypeService = fuelTypeService;
            this.makeService = makeService;
            this.modelService = modelService;
            this.transmissionService = transmissionService;
            this.imageService = imageService;
        }

        public async Task AddVehicleAsync(VehicleFormViewModel vehicleVm, string userId)
        {
            var dateId = await context.Dates
                .Where(d => 
                    d.Year == vehicleVm.SelectedYear && 
                    d.Month == (Month)Enum.Parse(typeof(Month), vehicleVm.SelectedMonth, true))
                .Select(a => a.Id)
                .FirstOrDefaultAsync();

            var vehicleToAdd = new Vehicle
            {
                Title = vehicleVm.Title,
                Price = Convert.ToDecimal(vehicleVm.Price),
                MakeId = vehicleVm.MakeId,
                ModelId = vehicleVm.ModelId,
                CategoryTypeId = vehicleVm.CategoryTypeId,
                CubicCapacity = vehicleVm.CubicCapacity,
                ColorId = vehicleVm.ColorId,
                FuelTypeId = vehicleVm.FuelTypeId,
                Mileage = vehicleVm.Mileage,
                Id = vehicleVm.Id,
                HorsePower = vehicleVm.HorsePower,
                Extra = new Data.Models.VehicleModel.Extras.Extra(),
                DateId = dateId,
                OwnerId = userId,
                TransmissionTypeId = vehicleVm.TransmissionTypeId
            };
            await context.Vehicles.AddAsync(vehicleToAdd);
            await context.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(string vehicleId, string userId)
        {
            var vehicleToDel = await context.Vehicles.Where(v => v.Id.ToString() == vehicleId && v.OwnerId == userId).Include(v => v.ImageCollection).AsNoTracking().FirstOrDefaultAsync();

            if (vehicleToDel != null)
            {
                var imageCollection = vehicleToDel.ImageCollection;
                await imageService.DeleteImage(imageCollection, vehicleId);


                context.Vehicles.Remove(vehicleToDel);
                await context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<VehicleIndexViewModel>> GetAllVehiclesAsync()
        {
            var models = await context.Vehicles
                .Include(v => v.CategoryType)
                .Include(v => v.Make)
                .Include(v=> v.Model)
                .Include(v=> v.FuelType)
                .Include(v=> v.ImageCollection)
                .Include(v=>v.Color)
                .Include(v=> v.TransmissionType)
                .Include(v => v.Date)
                .AsNoTracking()
                .Select(v => new VehicleIndexViewModel()
                {
                Title = v.Title,
                Price = v.Price.ToString(),
                CategoryType = v.CategoryType.Name,
                Color = v.Color.Name,
                CubicCapacity = v.CubicCapacity,
                FuelType = v.FuelType.Name,
                HorsePower = v.HorsePower,
                Id = v.Id.ToString(),
                Location = v.Location,
                Year = v.Date.Year.ToString(),
                Month = v.Date.Month.ToString(),
                Mileage = v.Mileage,
                Make = v.Make.Name,
                Model = v.Model.Name,
                Transmission = v.TransmissionType.Name,
                 }).ToListAsync();

            foreach (var model in models)
            {
                model.MainImage = await imageService.GetPathById(model.Id);
            }


            return models;
        }

        public async Task<VehicleFormViewModel> GetById(string id)
        {
            var vehicle = await context.Vehicles.FirstOrDefaultAsync(x => x.Id.ToString() == id);

            if (vehicle == null)
            {
                throw new NullReferenceException("This vehicle does not exist");
            }
            return new VehicleFormViewModel()
            {
                Id = vehicle.Id,
                CategoryTypeId = vehicle.CategoryTypeId,
                ColorId = vehicle.ColorId,
                CubicCapacity = vehicle.CubicCapacity,
                FuelTypeId = vehicle.FuelTypeId,
                MakeId = vehicle.MakeId,
                Title = vehicle.Title,
                ModelId = vehicle.ModelId,
                SelectedYear = vehicle.Date.Year,
                SelectedMonth = vehicle.Date.Month.ToString(),
                Mileage = vehicle.Mileage,
                Price = vehicle.Price.ToString(),
                HorsePower = vehicle.HorsePower,
                TransmissionTypeId = vehicle.TransmissionTypeId
            };

        }

        public async Task<VehicleFormViewModel> GetForAddVehicleAsync()
        {
            var vehicleVm = new VehicleFormViewModel();
                vehicleVm.Categories = await categoryService.GetAllAsync();
                vehicleVm.Colors = await colorService.GetAllAsync();
                vehicleVm.FuelTypes = await fuelTypeService.GetAllAsync();
                vehicleVm.Makes = await makeService.GetAllAsync();
                vehicleVm.TransmissionTypes = await transmissionService.GetAllAsync();
                vehicleVm.Models = await modelService.GetAllAsync(1);
                vehicleVm.Months = Enum.GetNames(typeof(Month));
                vehicleVm.Years = await context.Dates
                    .Where(date => date.Year >= 1930 && date.Year <= 2023)
                    .Select(date => date.Year)
                    .Distinct()
                    .OrderByDescending(d => d)
                    .ToArrayAsync();
            return vehicleVm;
        }

        public async Task<ICollection<VehicleIndexViewModel>> GetUserVehiclesAsync(string userId)
        {
            var models = await context.Vehicles.Where(v => v.OwnerId == userId)
                .Include(v => v.CategoryType)
                .Include(v => v.Make)
                .Include(v => v.Model)
                .Include(v => v.FuelType)
                .Include(v => v.ImageCollection)
                .Include(v => v.Color)
                .Include(v => v.TransmissionType)
                .Include(v => v.Date)
                .AsNoTracking()
                .Select(v => new VehicleIndexViewModel()
                {
                    Title = v.Title,
                    Price = v.Price.ToString(),
                    CategoryType = v.CategoryType.Name,
                    Color = v.Color.Name,
                    CubicCapacity = v.CubicCapacity,
                    FuelType = v.FuelType.Name,
                    HorsePower = v.HorsePower,
                    Id = v.Id.ToString(),
                    Location = v.Location,
                    Year = v.Date.Year.ToString(),
                    Month = v.Date.Month.ToString(),
                    Mileage = v.Mileage,
                    Make = v.Make.Name,
                    Model = v.Model.Name,
                    Transmission = v.TransmissionType.Name,
                }).ToListAsync();

            foreach (var model in models)
            {
                model.MainImage = await imageService.GetPathById(model.Id);
            }


            return models;
        }

        public async Task<IEnumerable<ModelFormVehicleViewModel>> GetModels(string id)
        {
            int makeId = Int32.Parse(id);
            return await modelService.GetAllAsync(makeId);
        }

        public async Task<DetailsViewModel> GetForDetailsVehicleAsync(string id)
        {
            var vehicle = await context.Vehicles
                .Where(v => v.Id.ToString() == id)
                .Include(v => v.CategoryType)
                .Include(v => v.Make)
                .Include(v => v.Model)
                .Include(v => v.FuelType)
                .Include(v => v.ImageCollection)
                .Include(v => v.Color)
                .Include(v => v.TransmissionType)
                .Include(v => v.Date)
                .Include(v => v.Extra)
                .Include(v => v.Extra.ComfortExtras)
                .Include(v => v.Extra.InteriorExtras)
                .Include(v => v.Extra.ExteriorExtras)
                .Include(v => v.Extra.OtherExtras)
                .Include(v => v.Extra.SafetyExtras)
                .AsNoTracking()
                .Select(v => new DetailsVehicleViewModel()
                {
                    Title = v.Title,
                    Price = v.Price.ToString(),
                    CategoryType = v.CategoryType.Name,
                    Color = v.Color.Name,
                    CubicCapacity = v.CubicCapacity.ToString(),
                    FuelType = v.FuelType.Name,
                    HorsePower = v.HorsePower.ToString(),
                    Id = v.Id.ToString(),
                    Location = v.Location,
                    Year = v.Date.Year.ToString(),
                    Month = v.Date.Month.ToString(),
                    Mileage = v.Mileage.ToString(),
                    Make = v.Make.Name,
                    Model = v.Model.Name,
                    Transmission = v.TransmissionType.Name,
                    Description = v.Description,
                    OwnerId = v.OwnerId.ToString(),
                    ComfortExtras =  v.Extra.ComfortExtras.Select(e => e.Name).ToList(),
                    SafetyExtras =  v.Extra.SafetyExtras.Select(e => e.Name).ToList(),
                    InteriorExtras =  v.Extra.InteriorExtras.Select(e => e.Name).ToList(),
                    ExteriorExtras =  v.Extra.ExteriorExtras.Select(e => e.Name).ToList(),
                    OtherExtras =  v.Extra.OtherExtras.Select(e => e.Name).ToList(),
                    Images = v.ImageCollection
                        .Select(i => i.ImageUrl)
                        .Where(i => i.Contains("_MainImage_") == false)
                        .ToList(),
                    MainImage = v.ImageCollection.Select(i => i.ImageUrl).Where(i => i.Contains("_MainImage_")).First()
                }).FirstOrDefaultAsync();

            if (vehicle == null)
            {
                throw new NullReferenceException("This vehicle does not exist");
            }

            var owner = await context.Users
                .FirstOrDefaultAsync(v => v.Id == vehicle.OwnerId);

            var detailsVm = new DetailsViewModel()
            {
                Seller = new DetailsSellerViewModel()
                {
                    Name = owner!.UserName,
                    Id = owner!.Id,
                    Location = "Cherven Bryag",
                    PhoneNumber = "+359 123 456 987",
                    RegistrationMade = "March, 2022"
                },
                Vehicle = vehicle
            };

            return detailsVm;
        }
    }
}
