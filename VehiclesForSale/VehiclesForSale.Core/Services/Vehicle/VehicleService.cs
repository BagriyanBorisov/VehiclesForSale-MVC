namespace VehiclesForSale.Core.Services.Vehicle
{
    using Contracts.Image;
    using Contracts.Vehicle;
    using Data;
    using Data.Models.VehicleModel;
    using Data.Models.VehicleModel.Enums;
    using Data.Models.VehicleModel.Extras;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Web.ViewModels.Vehicle;
    using Web.ViewModels.Vehicle.Details;
    using Web.ViewModels.Vehicle.Index;
    using Web.ViewModels.Vehicle.Search;

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
        private readonly IDateService dateService;

        public VehicleService(
            VehiclesDbContext context,
            ICategoryService categoryService,
            IColorService colorService,
            IFuelTypeService fuelTypeService,
            IMakeService makeService,
            IModelService modelService,
            ITransmissionTypeService transmissionService,
            IImageService imageService,
            IDateService dateService)
        {
            this.context = context;
            this.categoryService = categoryService;
            this.colorService = colorService;
            this.fuelTypeService = fuelTypeService;
            this.makeService = makeService;
            this.modelService = modelService;
            this.transmissionService = transmissionService;
            this.imageService = imageService;
            this.dateService = dateService;
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
                Extra = new Extra(),
                DateId = dateId,
                OwnerId = userId,
                TransmissionTypeId = vehicleVm.TransmissionTypeId,
                Description = vehicleVm.Description,
                Location = vehicleVm.Location
            };
            await context.Vehicles.AddAsync(vehicleToAdd);
            await context.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(string vehicleId, string userId)
        {
            var guidVehicleId = Guid.Parse(vehicleId);
            var vehicleToDel = await context.Vehicles
                .Where(v => v.Id.ToString() == vehicleId && v.OwnerId == userId)
                .Include(v => v.ImageCollection)
                .Include(v => v.Extra)
                .Include(v => v.FavoriteVehicleApplicationUsers)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (vehicleToDel != null)
            {
                var imageCollection = vehicleToDel.ImageCollection;
                await imageService.DeleteImage(imageCollection, vehicleId);
                await DeleteExtraAsync(vehicleToDel.Extra);


                var check = vehicleToDel.FavoriteVehicleApplicationUsers.Any();
                if (check)
                {
                    var users = await context.Users
                        .Include(u => u.FavoriteVehicleApplicationUsers)
                        .Where(u => u.FavoriteVehicleApplicationUsers
                            .Any(fv => fv.VehicleId.ToString() == vehicleId))
                        .ToListAsync();

                    foreach (var user in users)
                    {
                        var favoritesToRemove = user.FavoriteVehicleApplicationUsers
                            .Where(fv => fv.VehicleId == guidVehicleId)
                            .ToList();

                        foreach (var faToRemove in favoritesToRemove)
                        {
                            user.FavoriteVehicleApplicationUsers.Remove(faToRemove);
                            context.FavoriteVehicleApplicationUsers.Remove(faToRemove);
                            await context.SaveChangesAsync();
                        }
                    }

                    await context.SaveChangesAsync();
                }

                context.Vehicles.Remove(vehicleToDel);

            }

        }

        public async Task<ICollection<VehicleIndexViewModel>> GetAllVehiclesAsync()
        {
            var models = await context.Vehicles
                .Include(v => v.CategoryType)
                .Include(v => v.Make)
                .Include(v => v.Model)
                .Include(v => v.FuelType)
                .Include(v => v.ImageCollection)
                .Include(v => v.Color)
                .Include(v => v.TransmissionType)
                .Include(v => v.Date)
                .AsNoTracking()
                .OrderByDescending(v => v.DateAdded)
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
            var vehicle = await context.Vehicles.Where(x => x.Id.ToString() == id)
                .Include(v => v.Date)
                .FirstOrDefaultAsync();

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
            vehicleVm.Years = await dateService.GetAllAsync();
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
                .OrderByDescending(v => v.DateAdded)
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

        public async Task<DetailsViewModel> GetForDetailsVehicleAsync(string? userId, string id)
        {
            var vehicle = await context.Vehicles
                .Where(v => v.Id.ToString() == id)
                .AsNoTracking()
                .Include(v => v.CategoryType)
                .Include(v => v.Make)
                .Include(v => v.Model)
                .Include(v => v.FuelType)
                .Include(v => v.ImageCollection)
                .Include(v => v.Color)
                .Include(v => v.TransmissionType)
                .Include(v => v.Date)
                .Include(v => v.Extra)
                    .ThenInclude(e => e.ComfortExtras)
                .Include(v => v.Extra)
                    .ThenInclude(e => e.InteriorExtras)
                .Include(v => v.Extra)
                    .ThenInclude(e => e.ExteriorExtras)
                .Include(v => v.Extra)
                    .ThenInclude(e => e.OtherExtras)
                .Include(v => v.Extra)
                    .ThenInclude(e => e.SafetyExtras)
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
                    ComfortExtras = v.Extra.ComfortExtras.Select(e => e.Name).ToList(),
                    SafetyExtras = v.Extra.SafetyExtras.Select(e => e.Name).ToList(),
                    InteriorExtras = v.Extra.InteriorExtras.Select(e => e.Name).ToList(),
                    ExteriorExtras = v.Extra.ExteriorExtras.Select(e => e.Name).ToList(),
                    OtherExtras = v.Extra.OtherExtras.Select(e => e.Name).ToList(),
                    Images = v.ImageCollection.Select(i => i.ImageUrl).ToList(),
                })
                    .AsSplitQuery()
                    .FirstOrDefaultAsync();

            if (vehicle == null)
            {
                throw new NullReferenceException("This vehicle does not exist");
            }

            vehicle.IsInWatchList = await IsInWatchList(userId, id);

            var owner = await context.Users
                .FirstOrDefaultAsync(v => v.Id == vehicle.OwnerId);

            var detailsVm = new DetailsViewModel()
            {
                Seller = new DetailsSellerViewModel()
                {
                    Name = owner!.UserName,
                    Id = owner!.Id,
                    Location = "Cherven Bryag",
                    PhoneNumber = owner!.PhoneNumber,
                    RegistrationMade = owner!.RegistrationDate.ToString("MM/dd/yyyy")
                },
                Vehicle = vehicle
            };

            return detailsVm;
        }

        public async Task AddVehicleToWatchListAsync(string userId, string vehicleId)
        {
            var vehicle = await context.Vehicles.Where(v => v.Id.ToString() == vehicleId).FirstOrDefaultAsync();

            if (vehicle == null)
            {
                throw new NullReferenceException("This vehicle does not exist!");
            }

            var user = await context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new NullReferenceException("This user does not exist!");
            }

            var favUserVehicle = new FavoriteVehicleApplicationUser()
            {
                ApplicationUser = user,
                Vehicle = vehicle,
                VehicleId = vehicle.Id,
                ApplicationUserId = userId
            };

            if (vehicle.OwnerId != userId)
            {
                user.FavoriteVehicleApplicationUsers.Add(favUserVehicle);
                await context
                    .FavoriteVehicleApplicationUsers
                    .AddAsync(favUserVehicle);
                await context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<VehicleIndexViewModel>> GetWatchListAsync(string userId)
        {
            var models = await context
                .FavoriteVehicleApplicationUsers
                .Where(vu => vu.ApplicationUserId == userId)
                .Include(vu => vu.Vehicle)
                .Include(v => v.Vehicle.CategoryType)
                .Include(v => v.Vehicle.Make)
                .Include(v => v.Vehicle.Model)
                .Include(v => v.Vehicle.FuelType)
                .Include(v => v.Vehicle.ImageCollection)
                .Include(v => v.Vehicle.Color)
                .Include(v => v.Vehicle.TransmissionType)
                .Include(v => v.Vehicle.Date)
                .AsNoTracking()
                .OrderByDescending(v => v.Vehicle.DateAdded)
                .Select(v => new VehicleIndexViewModel()
                {
                    Title = v.Vehicle.Title,
                    Price = v.Vehicle.Price.ToString(),
                    CategoryType = v.Vehicle.CategoryType.Name,
                    Color = v.Vehicle.Color.Name,
                    CubicCapacity = v.Vehicle.CubicCapacity,
                    FuelType = v.Vehicle.FuelType.Name,
                    HorsePower = v.Vehicle.HorsePower,
                    Id = v.Vehicle.Id.ToString(),
                    Location = v.Vehicle.Location,
                    Year = v.Vehicle.Date.Year.ToString(),
                    Month = v.Vehicle.Date.Month.ToString(),
                    Mileage = v.Vehicle.Mileage,
                    Make = v.Vehicle.Make.Name,
                    Model = v.Vehicle.Model.Name,
                    Transmission = v.Vehicle.TransmissionType.Name,
                }).ToListAsync();

            foreach (var model in models)
            {
                model.MainImage = await imageService.GetPathById(model.Id);
            }


            return models;
        }

        public async Task DeleteVehicleFromWatchListAsync(string userId, string vehicleId)
        {

            var favVehicleToDel = await context
                .FavoriteVehicleApplicationUsers
                .Where(v => v.VehicleId.ToString() == vehicleId
                            && v.ApplicationUserId == userId)
                .FirstOrDefaultAsync();

            if (favVehicleToDel != null)
            {
                context.FavoriteVehicleApplicationUsers.Remove(favVehicleToDel);
                await context.SaveChangesAsync();
            }
        }

        private async Task<bool> IsInWatchList(string? userId, string vehicleId)
        {
            if (userId == null)
            {
                return false;
            }
            var isItIn = await context
                .FavoriteVehicleApplicationUsers
                .Where(v => v.ApplicationUserId == userId
                            && v.VehicleId.ToString() == vehicleId)
                .FirstOrDefaultAsync();




            if (isItIn != null)
            {
                return true;
            }

            return false;
        }

        public async Task<VehicleFormViewModel> GetForEditVehicleAsync(string vehicleId, string userId)
        {
            var vehicle = await context.Vehicles.Where(v => v.Id.ToString() == vehicleId)
                .Include(v => v.Date)
                .FirstOrDefaultAsync();

            if (vehicle == null)
            {
                throw new NullReferenceException("Getting non existent vehicle for edit");
            }

            if (vehicle.OwnerId != userId)
            {
                throw new NullReferenceException("You are not the owner of the vehicle");
            }

            var vehicleVm = new VehicleFormViewModel()
            {
                Id = vehicle.Id,
                Title = vehicle.Title,
                Price = vehicle.Price.ToString(),
                CategoryTypeId = vehicle.CategoryTypeId,
                Categories = await categoryService.GetAllAsync(),
                ColorId = vehicle.ColorId,
                Colors = await colorService.GetAllAsync(),
                FuelTypeId = vehicle.FuelTypeId,
                FuelTypes = await fuelTypeService.GetAllAsync(),
                MakeId = vehicle.MakeId,
                ModelId = vehicle.ModelId,
                Makes = await makeService.GetAllAsync(),
                Models = await modelService.GetAllAsync(vehicle.MakeId),
                TransmissionTypeId = vehicle.TransmissionTypeId,
                TransmissionTypes = await transmissionService.GetAllAsync(),
                Months = Enum.GetNames(typeof(Month)),
                Years = await context.Dates
                    .Where(date => date.Year >= 1930 && date.Year <= 2023)
                    .Select(date => date.Year)
                    .Distinct()
                    .OrderByDescending(d => d)
                    .ToArrayAsync(),
                SelectedMonth = vehicle.Date.Month.ToString(),
                SelectedYear = vehicle.Date.Year,
                Description = vehicle.Description,
                Location = vehicle.Location,
                HorsePower = vehicle.HorsePower,
                CubicCapacity = vehicle.CubicCapacity,
                Mileage = vehicle.Mileage
            };

            return vehicleVm;
        }

        public async Task EditVehicleAsync(VehicleFormViewModel vehicleVm, string userId)
        {
            var vehicleDb = await context.Vehicles.Where(v => v.Id == vehicleVm.Id).FirstOrDefaultAsync();

            var dateId = await context.Dates
                .Where(d =>
                    d.Year == vehicleVm.SelectedYear &&
                    d.Month == (Month)Enum.Parse(typeof(Month), vehicleVm.SelectedMonth, true))
                .Select(a => a.Id)
                .FirstOrDefaultAsync();

            if (vehicleDb != null)
            {
                vehicleDb.Title = vehicleVm.Title;
                vehicleDb.Price = Convert.ToDecimal(vehicleVm.Price);
                vehicleDb.MakeId = vehicleVm.MakeId;
                vehicleDb.ModelId = vehicleVm.ModelId;
                vehicleDb.CategoryTypeId = vehicleVm.CategoryTypeId;
                vehicleDb.CubicCapacity = vehicleVm.CubicCapacity;
                vehicleDb.ColorId = vehicleVm.ColorId;
                vehicleDb.FuelTypeId = vehicleVm.FuelTypeId;
                vehicleDb.Mileage = vehicleVm.Mileage;
                vehicleDb.HorsePower = vehicleVm.HorsePower;
                vehicleDb.DateId = dateId;
                vehicleDb.OwnerId = userId;
                vehicleDb.TransmissionTypeId = vehicleVm.TransmissionTypeId;
                vehicleDb.Description = vehicleVm.Description;
                vehicleDb.Location = vehicleVm.Location;

                context.Vehicles.Update(vehicleDb);
                await context.SaveChangesAsync();
            }
        }


        private async Task DeleteExtraAsync(Extra extra)
        {
            const int maxRetryCount = 3; // Maximum number of retry attempts

            for (int i = 0; i < maxRetryCount; i++)
            {
                try
                {
                    if (extra != null)
                    {
                        var interiorExtrasToDel =
                            await context.InteriorExtras.Where(ie => ie.ExtraId == extra.Id).ToListAsync();
                        var exteriorExtrasToDel =
                            await context.ExteriorExtras.Where(ie => ie.ExtraId == extra.Id).ToListAsync();
                        var comfortExtrasToDel =
                            await context.ComfortExtras.Where(ie => ie.ExtraId == extra.Id).ToListAsync();
                        var safetyExtrasToDel =
                            await context.SafetyExtras.Where(ie => ie.ExtraId == extra.Id).ToListAsync();
                        var otherExtrasToDel =
                            await context.OtherExtras.Where(ie => ie.ExtraId == extra.Id).ToListAsync();

                        context.InteriorExtras.RemoveRange(interiorExtrasToDel);
                        context.ExteriorExtras.RemoveRange(exteriorExtrasToDel);
                        context.ComfortExtras.RemoveRange(comfortExtrasToDel);
                        context.SafetyExtras.RemoveRange(safetyExtrasToDel);
                        context.OtherExtras.RemoveRange(otherExtrasToDel);
                        context.Extras.Remove(extra);

                        await context.SaveChangesAsync();

                        break; // Exit the loop if deletion is successful
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    // Reload the entity from the database
                    var entry = ex.Entries.Single();
                    await entry.ReloadAsync();
                }
            }
        }

        public async Task<VehicleSearchViewModel> GetForSearchAsync()
        {
            var vehicleVm = new VehicleSearchViewModel();
            vehicleVm.Categories = await categoryService.GetAllAsync();
            vehicleVm.Colors = await colorService.GetAllAsync();
            vehicleVm.FuelTypes = await fuelTypeService.GetAllAsync();
            vehicleVm.Makes = await makeService.GetAllAsync();
            vehicleVm.TransmissionTypes = await transmissionService.GetAllAsync();
            vehicleVm.Models = await modelService.GetAllAsync(1);
            vehicleVm.Years = await dateService.GetAllAsync();
            vehicleVm.Vehicles = await GetAllVehiclesAsync();
            return vehicleVm;
        }

        public async Task<ICollection<VehicleIndexViewModel>> GetFilteredAsync(
             string MakeId, string ModelId, string TransmissionTypeId,
            string SelectedYearTo, string SelectedYearFrom,
            string PriceTo, string PriceFrom, string CategoryTypeId,
            string ColorId, string MileageTo, string CubicCapacityTo,
            string HorsePowerTo, string FuelTypeId)
        {
            IQueryable<Vehicle> query = context.Vehicles
                .Include(v => v.Date); 

            // Apply filters based on non-empty and non-default parameters
            if (!string.IsNullOrEmpty(MakeId) && MakeId != "1")
            {
                query = query.Where(vehicle => vehicle.MakeId.ToString() == MakeId);
            }
            if (!string.IsNullOrEmpty(ModelId) && ModelId != "1")
            {
                query = query.Where(vehicle => vehicle.ModelId.ToString() == ModelId);
            }
            if (!string.IsNullOrEmpty(TransmissionTypeId) && TransmissionTypeId != "1")
            {
                query = query.Where(vehicle => vehicle.TransmissionTypeId.ToString() == TransmissionTypeId);
            }
            if (!string.IsNullOrEmpty(CategoryTypeId) && CategoryTypeId != "1")
            {
                query = query.Where(vehicle => vehicle.CategoryTypeId.ToString() == CategoryTypeId);
            }
            if (!string.IsNullOrEmpty(ColorId) && ColorId != "1")
            {
                query = query.Where(vehicle => vehicle.ColorId.ToString() == ColorId);
            }
            if (!string.IsNullOrEmpty(FuelTypeId) && FuelTypeId != "1")
            {
                query = query.Where(vehicle => vehicle.FuelTypeId.ToString() == FuelTypeId);
            }

            // Apply range filters
            if (!string.IsNullOrEmpty(SelectedYearFrom))
            {
                query = query.Where(vehicle => vehicle.Date.Year >= Convert.ToInt32(SelectedYearFrom));
            }
            if (!string.IsNullOrEmpty(SelectedYearTo))
            {
                query = query.Where(vehicle => vehicle.Date.Year <= Convert.ToInt32(SelectedYearTo));
            }
            if (!string.IsNullOrEmpty(PriceFrom))
            {
                query = query.Where(vehicle => vehicle.Price >= Convert.ToDecimal(PriceFrom));
            }
            if (!string.IsNullOrEmpty(PriceTo))
            {
                query = query.Where(vehicle => vehicle.Price <= Convert.ToDecimal(PriceTo));
            }
         
            if (!string.IsNullOrEmpty(MileageTo))
            {
                query = query.Where(vehicle => vehicle.Mileage <= Convert.ToInt64(MileageTo));
            }
         
            if (!string.IsNullOrEmpty(CubicCapacityTo))
            {
                query = query.Where(vehicle => vehicle.CubicCapacity <= Convert.ToInt32(CubicCapacityTo));
            }
      
            if (!string.IsNullOrEmpty(HorsePowerTo))
            {
                query = query.Where(vehicle => vehicle.HorsePower <= Convert.ToInt32(HorsePowerTo));
            }

            var filteredVehicles = await query
                .Include(v => v.CategoryType)
                .Include(v => v.Make)
                .Include(v => v.Model)
                .Include(v => v.FuelType)
                .Include(v => v.ImageCollection)
                .Include(v => v.Color)
                .Include(v => v.TransmissionType)
                .Select(v => new VehicleIndexViewModel
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
                })
                .ToListAsync();

            foreach (var model in filteredVehicles)
            {
                model.MainImage = await imageService.GetPathById(model.Id);
            }


            return filteredVehicles;
        }

    }
}
