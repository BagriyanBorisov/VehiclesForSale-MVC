namespace VehiclesForSale.Tests
{
    using NUnit.Framework;
    using Microsoft.AspNetCore.Hosting;
    using Core.Services.Image;
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts.Vehicle;
    using Core.Services.Vehicle;
    using Data;
    using Core.Contracts.Image;
    using Web.ViewModels.Vehicle;
    using Web.ViewModels.Vehicle.Index;
    using VehiclesForSale.Web.ViewModels.Vehicle.Details;
    using static DatabaseSeeder;
    using VehiclesForSale.Data.Models.VehicleModel;
    using VehiclesForSale.Web.ViewModels.Vehicle.Search;

    [TestFixture]
    public class VehicleServiceTest
    {
        private DbContextOptions<VehiclesDbContext> dbOptions;
        private VehiclesDbContext dbContext;
        private IVehicleService vehicleService;
        private ICategoryService categoryService;
        private IColorService colorService;
        private IFuelTypeService fuelTypeService;
        private IMakeService makeService;
        private IModelService modelService;
        private ITransmissionTypeService transmissionService;
        private IImageService imageService;
        private IDateService dateService;
        private IWebHostEnvironment webHostEnvironment;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<VehiclesDbContext>()
                .UseInMemoryDatabase("VehiclesDbInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new VehiclesDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);
            this.categoryService = new CategoryService(this.dbContext);
            this.colorService = new ColorService(this.dbContext);
            this.fuelTypeService = new FuelTypeService(this.dbContext);
            this.makeService = new MakeService(this.dbContext);
            this.modelService = new ModelService(this.dbContext);
            this.transmissionService = new TransmissionTypeService(this.dbContext);
            this.dateService = new DateService(this.dbContext);
            this.imageService = new ImageService(this.dbContext, webHostEnvironment);

            this.vehicleService = new VehicleService(this.dbContext,categoryService, colorService, fuelTypeService, makeService, modelService,transmissionService, imageService, dateService);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            dbContext.Dispose();
        }

        [Test]
        public async Task AddVehicleAsync_ShouldAddVehicleToDatabase()
        {
            // Arrange
            var userId = dbContext.Users.Select(v => v.Id).First(); // Replace with a valid user ID
            var vehicleVm = new VehicleFormViewModel
            {
                Title = "Test Vehicle",
                Price = "10000",
                MakeId = dbContext.Makes.Select(v => v.Id).First(),
                ModelId = dbContext.Models.Select(v => v.Id).First(),
                CategoryTypeId = dbContext.CategoryTypes.Select(v => v.Id).First(), 
                CubicCapacity = 2000,
                ColorId = dbContext.Colors.Select(v => v.Id).First(), 
                FuelTypeId = dbContext.FuelTypes.Select(v => v.Id).First(), 
                Mileage = 50000, 
                Id = Guid.NewGuid(),
                HorsePower = 150, 
                SelectedYear = 2023,
                SelectedMonth = "January",
                TransmissionTypeId = dbContext.TransmissionTypes.Select(v => v.Id).First(), 
                Description = "Test vehicle description",
                Location = "Test location"
            };

            // Act
            await vehicleService.AddVehicleAsync(vehicleVm, userId);

            // Assert
            using (var context = new VehiclesDbContext(dbOptions))
            {
                var addedVehicle = await context.Vehicles
                    .Include(v => v.Extra) // Include navigation property
                    .FirstOrDefaultAsync(v => v.Id == vehicleVm.Id);

                Assert.NotNull(addedVehicle);
                Assert.AreEqual(vehicleVm.Title, addedVehicle.Title);
                Assert.AreEqual(Convert.ToDecimal(vehicleVm.Price), addedVehicle.Price);
                Assert.AreEqual(vehicleVm.MakeId, addedVehicle.MakeId);
                Assert.AreEqual(vehicleVm.ModelId, addedVehicle.ModelId);
                Assert.AreEqual(vehicleVm.CategoryTypeId, addedVehicle.CategoryTypeId);
                Assert.AreEqual(vehicleVm.CubicCapacity, addedVehicle.CubicCapacity);
                Assert.AreEqual(vehicleVm.ColorId, addedVehicle.ColorId);
                Assert.AreEqual(vehicleVm.FuelTypeId, addedVehicle.FuelTypeId);
                Assert.AreEqual(vehicleVm.Mileage, addedVehicle.Mileage);
                Assert.AreEqual(vehicleVm.HorsePower, addedVehicle.HorsePower);
                Assert.AreEqual(vehicleVm.TransmissionTypeId, addedVehicle.TransmissionTypeId);
                Assert.AreEqual(vehicleVm.Description, addedVehicle.Description);
                Assert.AreEqual(vehicleVm.Location, addedVehicle.Location);

                // Check the Extra navigation property
                Assert.NotNull(addedVehicle.Extra);
            }
        }

        [Test]
        public async Task GetAllVehiclesAsync_ShouldReturnAllVehiclesWithMainImages()
        {
            // Arrange
            var expectedCount = dbContext.Vehicles.Count(); // Replace with the expected count of vehicles in the database

            // Act
            var vehicles = await vehicleService.GetAllVehiclesAsync();

            // Assert
            Assert.AreEqual(expectedCount, vehicles.Count);
        }

        [Test]
        public async Task GetById_ShouldReturnCorrectVehicleViewModel()
        {
            // Arrange
            var vehicleId = dbContext.Vehicles.Select(v => v.Id.ToString()).First(); // Replace with a valid vehicle ID

            // Act
            var vehicleVm = await vehicleService.GetById(vehicleId);

            // Assert
            Assert.NotNull(vehicleVm);
            Assert.AreEqual(vehicleId, vehicleVm.Id.ToString());
            // Add more assertions to check if the properties of the VehicleFormViewModel match the expected values
            Assert.NotNull(vehicleVm.CategoryTypeId);
            Assert.NotNull(vehicleVm.ColorId);
            Assert.NotNull(vehicleVm.CubicCapacity);
            Assert.NotNull(vehicleVm.FuelTypeId);
            Assert.NotNull(vehicleVm.MakeId);
            Assert.NotNull(vehicleVm.Title);
            Assert.NotNull(vehicleVm.ModelId);
            Assert.NotNull(vehicleVm.SelectedYear);
            Assert.NotNull(vehicleVm.SelectedMonth);
            Assert.NotNull(vehicleVm.Mileage);
            Assert.NotNull(vehicleVm.Price);
            Assert.NotNull(vehicleVm.HorsePower);
            Assert.NotNull(vehicleVm.TransmissionTypeId);
        }

        [Test]
        public async Task GetForAddVehicleAsync_ShouldReturnPopulatedVehicleViewModelForAdd()
        {
            // Arrange

            // Act
            var vehicleVm = await vehicleService.GetForAddVehicleAsync();

            // Assert
            Assert.NotNull(vehicleVm);
            Assert.NotNull(vehicleVm.Categories);
            Assert.NotNull(vehicleVm.Colors);
            Assert.NotNull(vehicleVm.FuelTypes);
            Assert.NotNull(vehicleVm.Makes);
            Assert.NotNull(vehicleVm.TransmissionTypes);
            Assert.NotNull(vehicleVm.Models);
            Assert.NotNull(vehicleVm.Months);
            Assert.NotNull(vehicleVm.Years);

            // Add more assertions as needed to validate the contents of the returned VehicleFormViewModel
            // For example, you can check if lists are not empty, if certain properties are initialized, etc.
        }

        [Test]
        public async Task GetUserVehiclesAsync_ShouldReturnUserVehicles()
        {
            // Arrange
            var userId = "3980b47a-31d5-4df8-9609-25c3db1cd533"; // Replace with a valid user ID

            // Act
            var userVehicles = await vehicleService.GetUserVehiclesAsync(userId);

            // Assert
            Assert.NotNull(userVehicles);
            Assert.IsInstanceOf<ICollection<VehicleIndexViewModel>>(userVehicles);
            Assert.That(userVehicles.Count, Is.EqualTo(dbContext.Vehicles.Count(u => u.OwnerId == userId)));

            // Add more assertions to check the properties of each VehicleIndexViewModel in the collection
            foreach (var vehicle in userVehicles)
            {
                Assert.NotNull(vehicle.Title);
                Assert.NotNull(vehicle.Price);
                Assert.NotNull(vehicle.CategoryType);
                Assert.NotNull(vehicle.Color);
                Assert.NotNull(vehicle.CubicCapacity);
                Assert.NotNull(vehicle.FuelType);
                Assert.NotNull(vehicle.HorsePower);
                Assert.NotNull(vehicle.Id);
                Assert.NotNull(vehicle.Location);
                Assert.NotNull(vehicle.Year);
                Assert.NotNull(vehicle.Month);
                Assert.NotNull(vehicle.Mileage);
                Assert.NotNull(vehicle.Make);
                Assert.NotNull(vehicle.Model);
                Assert.NotNull(vehicle.Transmission);
            }
        }

        [Test]
        public async Task GetForDetailsVehicleAsync_ShouldReturnDetailsViewModel()
        {
            // Arrange
            var userId = "3980b47a-31d5-4df8-9609-25c3db1cd533"; // Replace with a valid user ID
            var vehicleId = dbContext.Vehicles.Where(v => v.OwnerId == userId).Select(v => v.Id.ToString()).First(); // Replace with a valid vehicle ID

            // Act
            var detailsViewModel = await vehicleService.GetForDetailsVehicleAsync(userId, vehicleId);

            // Assert
            Assert.NotNull(detailsViewModel);
            Assert.IsInstanceOf<DetailsViewModel>(detailsViewModel);


            Assert.NotNull(detailsViewModel.Seller);
            Assert.NotNull(detailsViewModel.Seller.Name);
            Assert.NotNull(detailsViewModel.Seller.Id);
            Assert.NotNull(detailsViewModel.Seller.Location);
            Assert.NotNull(detailsViewModel.Seller.PhoneNumber);
            Assert.NotNull(detailsViewModel.Seller.RegistrationMade);

            Assert.NotNull(detailsViewModel.Vehicle);
            Assert.NotNull(detailsViewModel.Vehicle.Title);
            Assert.NotNull(detailsViewModel.Vehicle.Price);
            Assert.NotNull(detailsViewModel.Vehicle.CategoryType);
            Assert.NotNull(detailsViewModel.Vehicle.Color);
            Assert.NotNull(detailsViewModel.Vehicle.CubicCapacity);
            Assert.NotNull(detailsViewModel.Vehicle.FuelType);
            Assert.NotNull(detailsViewModel.Vehicle.HorsePower);
            Assert.NotNull(detailsViewModel.Vehicle.Id);
            Assert.NotNull(detailsViewModel.Vehicle.Location);
            Assert.NotNull(detailsViewModel.Vehicle.Year);
            Assert.NotNull(detailsViewModel.Vehicle.Month);
            Assert.NotNull(detailsViewModel.Vehicle.Mileage);
            Assert.NotNull(detailsViewModel.Vehicle.Make);
            Assert.NotNull(detailsViewModel.Vehicle.Model);
            Assert.NotNull(detailsViewModel.Vehicle.Transmission);
            Assert.NotNull(detailsViewModel.Vehicle.Description);
            Assert.NotNull(detailsViewModel.Vehicle.OwnerId);
            Assert.NotNull(detailsViewModel.Vehicle.ComfortExtras);
            Assert.NotNull(detailsViewModel.Vehicle.SafetyExtras);
            Assert.NotNull(detailsViewModel.Vehicle.InteriorExtras);
            Assert.NotNull(detailsViewModel.Vehicle.ExteriorExtras);
            Assert.NotNull(detailsViewModel.Vehicle.OtherExtras);
            Assert.NotNull(detailsViewModel.Vehicle.Images);
            Assert.NotNull(detailsViewModel.Vehicle.IsInWatchList);

        }


        [Test]
        public async Task AddVehicleToWatchListAsync_ShouldAddToFavorites_WhenVehicleAndUserExist()
        {
            // Arrange
            var userId = "3980b47a-31d5-4df8-9609-25c3db1cd533"; 
            var vehicleId = dbContext.Vehicles.Where(v => v.OwnerId != userId).Select(v => v.Id.ToString()).First(); // Replace with a valid vehicle ID

            // Act
            await vehicleService.AddVehicleToWatchListAsync(userId, vehicleId);

            // Assert
            using (var context = new VehiclesDbContext(dbOptions))
            {
                var user = await context.Users
                    .Include(u => u.FavoriteVehicleApplicationUsers)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                var vehicle = await context.Vehicles
                    .Include(v => v.FavoriteVehicleApplicationUsers)
                    .FirstOrDefaultAsync(v => v.Id.ToString() == vehicleId);

                Assert.NotNull(user);
                Assert.NotNull(vehicle);

                var userHasVehicleInFavorites = user.FavoriteVehicleApplicationUsers.Any(fv => fv.VehicleId.ToString() == vehicleId);
                var vehicleHasUserInFavorites = vehicle.FavoriteVehicleApplicationUsers.Any(fv => fv.ApplicationUserId == userId);

                Assert.IsTrue(userHasVehicleInFavorites);
                Assert.IsTrue(vehicleHasUserInFavorites);
            }
        }

        [Test]
        public void AddVehicleToWatchListAsync_ShouldNotAddToFavorites_WhenUserDoesNotExist()
        {
            // Arrange
            var vehicleId = dbContext.Vehicles.Select(v => v.Id.ToString()).First(); 
            var nonExistentUserId = "nonexistentuser";

            // Act and Assert
            Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await vehicleService.AddVehicleToWatchListAsync(nonExistentUserId, vehicleId);
            });
        }

        [Test]
        public void AddVehicleToWatchListAsync_ShouldNotAddToFavorites_WhenVehicleDoesNotExist()
        {
            // Arrange
            var userId = dbContext.Users.Select(u => u.Id).First(); 
            var nonExistentVehicleId = Guid.NewGuid().ToString();

            // Act and Assert
            Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await vehicleService.AddVehicleToWatchListAsync(userId, nonExistentVehicleId);
            });
        }

        [Test]
        public async Task GetWatchListAsync_ShouldReturnVehiclesInWatchList_WhenValidUserId()
        {
            // Arrange
            var userId = "3980b47a-31d5-4df8-9609-25c3db1cd533"; 

            // Act
            var watchList = await vehicleService.GetWatchListAsync(userId);

            // Assert
            foreach (var vehicleVm in watchList)
            {
                Assert.NotNull(vehicleVm.Title);
                Assert.NotNull(vehicleVm.Price);
                Assert.NotNull(vehicleVm.CategoryType);
                Assert.NotNull(vehicleVm.Color);
                Assert.NotNull(vehicleVm.CubicCapacity);
                Assert.NotNull(vehicleVm.FuelType);
                Assert.NotNull(vehicleVm.HorsePower);
                Assert.NotNull(vehicleVm.Id);
                Assert.NotNull(vehicleVm.Location);
                Assert.NotNull(vehicleVm.Year);
                Assert.NotNull(vehicleVm.Month);
                Assert.NotNull(vehicleVm.Mileage);
                Assert.NotNull(vehicleVm.Make);
                Assert.NotNull(vehicleVm.Model);
                Assert.NotNull(vehicleVm.Transmission);
                Assert.NotNull(vehicleVm.MainImage);
            }
        }

        [Test]
        public async Task DeleteVehicleFromWatchListAsync_ShouldRemoveVehicleFromWatchList_WhenValidUserIdAndVehicleId()
        {
            // Arrange
            var userId = "3980b47a-31d5-4df8-9609-25c3db1cd533"; 
            var vehicleId = dbContext.Vehicles.Where(v => v.OwnerId != userId).Select(v => v.Id.ToString()).First(); 
            var initialWatchListCount = await dbContext.FavoriteVehicleApplicationUsers.CountAsync();

            // Act
            await vehicleService.DeleteVehicleFromWatchListAsync(userId, vehicleId);
            var updatedWatchListCount = await dbContext.FavoriteVehicleApplicationUsers.CountAsync();

            // Assert
            Assert.AreEqual(initialWatchListCount - 1, updatedWatchListCount);
        }

        [Test]
        public void GetForEditVehicleAsync_ShouldThrowException_WhenInvalidVehicleId()
        {
            // Arrange
            var userId = "3980b47a-31d5-4df8-9609-25c3db1cd533"; // Replace with a valid user ID
            var invalidVehicleId = "invalid_vehicle_id";

            // Act and Assert
            var exception = Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await vehicleService.GetForEditVehicleAsync(invalidVehicleId, userId);
            });
            Assert.That(exception.Message, Is.EqualTo("Getting non existent vehicle for edit"));
        }

        [Test]
        public void GetForEditVehicleAsync_ShouldThrowException_WhenUserIsNotOwner()
        {
            // Arrange
            var userId = "3980b47a-31d5-4df8-9609-25c3db1cd533";
            var vehicleOwnedByOtherUser = dbContext.Vehicles
                .Where(v => v.OwnerId != userId)
                .Select(v => v.Id.ToString())
                .FirstOrDefault();

            // Act and Assert
            var exception = Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await vehicleService.GetForEditVehicleAsync(vehicleOwnedByOtherUser, userId);
            });
            Assert.That(exception.Message, Is.EqualTo("You are not the owner of the vehicle"));
        }

        [Test]
        public async Task GetForEditVehicleAsync_ShouldReturnEditViewModel_WhenValidVehicleIdAndUserId()
        {
            // Arrange
            var userId = "3980b47a-31d5-4df8-9609-25c3db1cd533";
            var vehicleId = dbContext.Vehicles.Where(v => v.OwnerId == userId).Select(v => v.Id.ToString()).First();

            // Act
            var editViewModel = await vehicleService.GetForEditVehicleAsync(vehicleId, userId);

            // Assert
            Assert.NotNull(editViewModel);
            Assert.That(editViewModel.Id.ToString(), Is.EqualTo(vehicleId));
            
        }


        [Test]
        public async Task EditVehicleAsync_ShouldUpdateVehicleInformation()
        {
            // Arrange
            var userId = "3980b47a-31d5-4df8-9609-25c3db1cd533";
            var vehicleToUpdateId = dbContext.Vehicles.Where(v => v.OwnerId == userId).Select(v => v.Id).First();

            var updatedVehicleVm = new VehicleFormViewModel
            {
                Id = vehicleToUpdateId,
                Title = "Updated Vehicle",
                Price = "15000",
                MakeId = 1,
                ModelId = 1,
                CategoryTypeId = 1,
                CubicCapacity = 2500,
                ColorId = 1,
                FuelTypeId = 1,
                Mileage = 60000,
                HorsePower = 180,
                SelectedYear = 2022,
                SelectedMonth = "February",
                TransmissionTypeId = 1,
                Description = "Updated vehicle description",
                Location = "Updated location"
            };

            // Act
            await vehicleService.EditVehicleAsync(updatedVehicleVm, userId);

            // Assert
            var updatedVehicle = await dbContext.Vehicles
                .Include(v => v.Extra) // Include navigation property
                .FirstOrDefaultAsync(v => v.Id == vehicleToUpdateId);

            Assert.NotNull(updatedVehicle);
            Assert.AreEqual(updatedVehicleVm.Title, updatedVehicle.Title);
            Assert.AreEqual(Convert.ToDecimal(updatedVehicleVm.Price), updatedVehicle.Price);
            Assert.AreEqual(updatedVehicleVm.MakeId, updatedVehicle.MakeId);
            Assert.AreEqual(updatedVehicleVm.ModelId, updatedVehicle.ModelId);
            Assert.AreEqual(updatedVehicleVm.CategoryTypeId, updatedVehicle.CategoryTypeId);
            Assert.AreEqual(updatedVehicleVm.CubicCapacity, updatedVehicle.CubicCapacity);
            Assert.AreEqual(updatedVehicleVm.ColorId, updatedVehicle.ColorId);
            Assert.AreEqual(updatedVehicleVm.FuelTypeId, updatedVehicle.FuelTypeId);
            Assert.AreEqual(updatedVehicleVm.Mileage, updatedVehicle.Mileage);
            Assert.AreEqual(updatedVehicleVm.HorsePower, updatedVehicle.HorsePower);
            Assert.AreEqual(updatedVehicleVm.TransmissionTypeId, updatedVehicle.TransmissionTypeId);
            Assert.AreEqual(updatedVehicleVm.Description, updatedVehicle.Description);
            Assert.AreEqual(updatedVehicleVm.Location, updatedVehicle.Location);
        }

        [Test]
        public async Task GetForSearchAsync_ShouldReturnVehicleSearchViewModel()
        {
            // Arrange
            var vehicleService = new VehicleService(
                dbContext,
                categoryService,
                colorService,
                fuelTypeService,
                makeService,
                modelService,
                transmissionService,
                imageService,
                dateService);

            // Act
            var result = await vehicleService.GetForSearchAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Categories);
            Assert.NotNull(result.Colors);
            Assert.NotNull(result.FuelTypes);
            Assert.NotNull(result.Makes);
            Assert.NotNull(result.TransmissionTypes);
            Assert.NotNull(result.Models);
            Assert.NotNull(result.Years);
            Assert.NotNull(result.Vehicles);
           
        }

        [Test]
        public async Task GetFilteredAsync_ShouldReturnFilteredVehicles_WithDifferentFilters()
        {

            
            var makeId = "1"; 
            var modelId = "1"; 
            var transmissionTypeId = "1";
            string? selectedYearFrom = null;
            string? selectedYearTo = null;
            string? priceFrom = null;
            string? priceTo = null;
            var categoryTypeId = "1"; 
            var colorId = "1";
            string? mileageTo = null;
            string? cubicCapacityTo = null;
            string? horsePowerTo = null;
            var fuelTypeId = "1"; 

            // Act
            var result = await vehicleService.GetFilteredAsync(
                makeId, modelId, transmissionTypeId,
                selectedYearTo, selectedYearFrom,
                priceTo, priceFrom, categoryTypeId,
                colorId, mileageTo, cubicCapacityTo,
                horsePowerTo, fuelTypeId);

            // Assert
            Assert.NotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public async Task GetFilteredAsync_ShouldReturnAllVehicles_WithNoFilters()
        {
            // Arrange
            var vehicleService = new VehicleService(
                dbContext,
                categoryService,
                colorService,
                fuelTypeService,
                makeService,
                modelService,
                transmissionService,
                imageService,
                dateService);

            // Act
            var result = await vehicleService.GetFilteredAsync(
                null, null, null, null, null, null, null, null, null, null, null, null, null);

            // Assert
            Assert.NotNull(result);
            // Assert that all vehicles are returned since there are no filters
            Assert.AreEqual(dbContext.Vehicles.Count(), result.Count);
        }


    }
}

