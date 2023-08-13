namespace VehiclesForSale.Tests
{
    using NUnit.Framework;

    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts.Vehicle;
    using Core.Services.Vehicle;
    using Data;
    using Data.Models.VehicleModel;
    using static DatabaseSeeder;

    [TestFixture]
    public class FuelTypeServiceTest
    {
        private DbContextOptions<VehiclesDbContext> dbOptions;
        private VehiclesDbContext dbContext;
        private IFuelTypeService fuelTypeService; // Make sure you have an IFuelTypeService interface

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<VehiclesDbContext>()
                .UseInMemoryDatabase("VehiclesDbInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new VehiclesDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.fuelTypeService = new FuelTypeService(this.dbContext); // Initialize the FuelTypeService
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            dbContext.Dispose();
        }

        [Test]
        public void AddAsync_InvalidName_ThrowsNullReferenceException()
        {
            // Arrange
            var invalidName = ""; // An invalid name, empty in this case

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await fuelTypeService.AddAsync(invalidName));
        }

        [Test]
        public async Task AddAsync_ValidName_CallsAddAsync()
        {
            // Arrange
            var validName = "Valid Name";

            // Act
            await fuelTypeService.AddAsync(validName);

            // Assert
            Assert.That(dbContext.FuelTypes.Any(c => c.Name == validName));
        }

        [Test]
        public async Task DeleteAsync_FuelTypeExists_RemovesFuelTypeAndSavesChanges()
        {
            // Arrange
            var fuelTypeId = 1; // Assume there's a fuel type with this ID in the seeded data

            // Act
            await fuelTypeService.DeleteAsync(fuelTypeId.ToString());

            // Assert
            var deletedFuelType = await dbContext.FuelTypes.FindAsync(fuelTypeId);
            Assert.IsNull(deletedFuelType); // The fuel type should not be found in the database
        }

        [Test]
        public async Task CheckByNameExist_FuelTypeWithNameExists_ReturnsTrue()
        {
            // Arrange
            var fuelTypeName = "Test Fuel Type";
            dbContext.FuelTypes.Add(new FuelType { Name = fuelTypeName });
            await dbContext.SaveChangesAsync();

            // Act
            var result = await fuelTypeService.CheckByNameExist(fuelTypeName);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task CheckByNameExist_FuelTypeWithNameDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var fuelTypeName = "Non-existent Fuel Type";

            // Act
            var result = await fuelTypeService.CheckByNameExist(fuelTypeName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task GetAllAsync_ReturnsAllFuelTypes()
        {
            // Arrange

            // Act
            var result = await fuelTypeService.GetAllAsync();

            // Assert
            Assert.AreEqual(dbContext.FuelTypes.Count(), result.Count());
            // Assert that the count of returned fuel types is as expected
        }
    }
}
