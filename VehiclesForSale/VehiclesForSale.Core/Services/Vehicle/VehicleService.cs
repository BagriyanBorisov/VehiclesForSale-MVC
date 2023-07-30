using VehiclesForSale.Core.Contracts.Image;
using VehiclesForSale.Data.Models.VehicleModel.Extras;

namespace VehiclesForSale.Core.Services.Vehicle
{
    using Web.ViewModels.Vehicle;
    using Contracts.Vehicle;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Data.Models.VehicleModel;
    using System.Collections.Generic;
    using VehiclesForSale.Web.ViewModels.Vehicle.Index;

    public class VehicleService : IVehicleService
    {
        private readonly VehiclesDbContext context;

        private readonly ICategoryService categoryService;
        private readonly IColorService colorService;
        private readonly IFuelTypeService fuelTypeService;
        private readonly IMakeService makeService;
        private readonly IModelService modelService;
        private readonly ITransmissionTypeService transmissionService;
        private readonly IExtraService extraService;
        private readonly IImageService imageService;

        public VehicleService(
            VehiclesDbContext context,
            ICategoryService categoryService,
            IColorService colorService,
            IFuelTypeService fuelTypeService,
            IMakeService makeService,
            IModelService modelService,
            ITransmissionTypeService transmissionService,
            IExtraService extraService,
            IImageService imageService)
        {
            this.context = context;
            this.categoryService = categoryService;
            this.colorService = colorService;
            this.fuelTypeService = fuelTypeService;
            this.makeService = makeService;
            this.modelService = modelService;
            this.transmissionService = transmissionService;
            this.extraService = extraService;
            this.imageService = imageService;
        }

        public async Task AddVehicleAsync(VehicleFormViewModel vehicleVm, string userId)
        {
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
                Extra = new Extra(),
                Year = vehicleVm.Year,
                OwnerId = userId,
                TransmissionTypeId = vehicleVm.TransmissionTypeId
            };

            foreach (var extra in vehicleVm.SafetyExtras.Where(s => s.IsChecked == true))
            {
                SafetyExtra safeExtra = new SafetyExtra
                {
                    Name = extra.Name,
                    Extra = vehicleToAdd.Extra
                };
                vehicleToAdd.Extra.SafetyExtras.Add(safeExtra);
            }

            foreach (var extra in vehicleVm.ComfortExtras)
            {
                ComfortExtra comfExtra = new ComfortExtra
                {
                    Name = extra.Name,
                    Extra = vehicleToAdd.Extra
                };
                vehicleToAdd.Extra.ComfortExtras.Add(comfExtra);
            }

            foreach (var extra in vehicleVm.InteriorExtras)
            {
                InteriorExtra inExtra = new InteriorExtra
                {
                    Name = extra.Name,
                    Extra = vehicleToAdd.Extra
                };
                vehicleToAdd.Extra.InteriorExtras.Add(inExtra);
            }

            foreach (var extra in vehicleVm.ExteriorExtras)
            {
                ExteriorExtra exExtra = new ExteriorExtra
                {
                    Name = extra.Name,
                    Extra = vehicleToAdd.Extra
                };
                vehicleToAdd.Extra.ExteriorExtras.Add(exExtra);
            }

            foreach (var extra in vehicleVm.OtherExtras)
            {
                OtherExtra otherExtra = new OtherExtra
                {
                    Name = extra.Name,
                    Extra = vehicleToAdd.Extra
                };
                vehicleToAdd.Extra.OtherExtras.Add(otherExtra);
            }

            await context.Vehicles.AddAsync(vehicleToAdd);
            await context.Extras.AddAsync(vehicleToAdd.Extra);
            await context.SaveChangesAsync();
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
                Year = v.Year.ToString(),
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
                Year = vehicle.Year,
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

                vehicleVm.SafetyExtras = await context.SafetyExtras.Select(se => new SafetyExtraFormViewModel
            {
                Id = se.Id,
                Name = se.Name,
                IsChecked = false
            }).ToListAsync();

                vehicleVm.ComfortExtras = await context.ComfortExtras.Select(se => new ComfortExtraFormViewModel
            {
                Id = se.Id,
                Name = se.Name,
                IsChecked = false
            }).ToListAsync();


                vehicleVm.InteriorExtras = await context.InteriorExtras.Select(se => new InteriorExtraFormViewModel()
            {
                Id = se.Id,
                Name = se.Name,
                IsChecked = false
            }).ToListAsync();

                vehicleVm.ExteriorExtras = await context.ExteriorExtras.Select(se => new ExteriorExtraFormViewModel()
            {
                Id = se.Id,
                Name = se.Name,
                IsChecked = false
            }).ToListAsync();

                vehicleVm.OtherExtras = await context.OtherExtras.Select(se => new OtherExtraFormViewModel()
            {
                Id = se.Id,
                Name = se.Name,
                IsChecked = false
            }).ToListAsync();


            return vehicleVm;
        }

        private async Task<VehicleFormViewModel> GetModels(VehicleFormViewModel vehicleVm)
        {
            vehicleVm.Models = await modelService.GetAllAsync(vehicleVm.MakeId);

            return vehicleVm;
        }
    }
}
