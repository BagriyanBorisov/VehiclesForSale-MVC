namespace VehiclesForSale.Tests
{
    using Moq;
    using NUnit.Framework;

    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts.Vehicle;
    using Core.Services.Vehicle;
    using Data;
    using Data.Models.VehicleModel;
    using static DatabaseSeeder;

    [TestFixture]
    public class ColorServiceTest
    {
        private DbContextOptions<VehiclesDbContext> dbOptions;
        private VehiclesDbContext dbContext;
        private IColorService colorService; // Make sure you have an IColorService interface

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<VehiclesDbContext>()
                .UseInMemoryDatabase("VehiclesDbInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new VehiclesDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);
            this.colorService = new ColorService(this.dbContext); // Initialize the ColorService
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
            Assert.ThrowsAsync<NullReferenceException>(async () => await colorService.AddAsync(invalidName));
        }

        [Test]
        public async Task AddAsync_ValidName_CallsAddAsync()
        {
            // Arrange
            var validName = "Valid Name";

            // Act
            await colorService.AddAsync(validName);

            // Assert
            Assert.That(dbContext.Colors.Any(c => c.Name == validName));
        }

        [Test]
        public async Task DeleteAsync_ColorExists_RemovesColorAndSavesChanges()
        {
            // Arrange
            var colorId = 1; // Assume there's a color with this ID in the seeded data

            // Act
            await colorService.DeleteAsync(colorId.ToString());

            // Assert
            var deletedColor = await dbContext.Colors.FindAsync(colorId);
            Assert.IsNull(deletedColor); // The color should not be found in the database
        }

        [Test]
        public async Task CheckByNameExist_ColorWithNameExists_ReturnsTrue()
        {
            // Arrange
            var colorName = "Test Color";
            dbContext.Colors.Add(new Color { Name = colorName });
            await dbContext.SaveChangesAsync();

            // Act
            var result = await colorService.CheckByNameExist(colorName);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task CheckByNameExist_ColorWithNameDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var colorName = "Non-existent Color";

            // Act
            var result = await colorService.CheckByNameExist(colorName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task GetAllAsync_ReturnsAllColors()
        {
            // Arrange

            // Act
            var result = await colorService.GetAllAsync();

            // Assert
            Assert.AreEqual(dbContext.Colors.Count(), result.Count());
            // Assert that the count of returned colors is as expected
        }
    }
}
