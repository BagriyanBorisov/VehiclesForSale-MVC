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
    public class TransmissionServiceTest
    {
        private DbContextOptions<VehiclesDbContext> dbOptions;
        private VehiclesDbContext dbContext;
        private ITransmissionTypeService transmissionService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<VehiclesDbContext>()
                .UseInMemoryDatabase("VehiclesDbInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new VehiclesDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.transmissionService = new TransmissionTypeService(this.dbContext);
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
            Assert.ThrowsAsync<NullReferenceException>(async () => await transmissionService.AddAsync(invalidName));
        }

        [Test]
        public async Task AddAsync_ValidName_CallsAddAsync()
        {
            // Arrange
            var validName = "Valid Name";

            // Act
            await transmissionService.AddAsync(validName);

            // Assert
            Assert.That(dbContext.TransmissionTypes.Any(c => c.Name == validName));
        }



        [Test]
        public async Task DeleteAsync_TransmissionExists_RemovesTransmissionAndSavesChanges()
        {
            // Arrange
            var transmissionId = 1; 

            // Act
            await transmissionService.DeleteAsync(transmissionId.ToString());

            // Assert
            var deletedTransmissionType = await dbContext.TransmissionTypes.FindAsync(transmissionId);
            Assert.IsNull(deletedTransmissionType); 
        }

        [Test]
        public async Task CheckByNameExist_TransmissionWithNameExists_ReturnsTrue()
        {
            // Arrange
            var transmissionName = "Test Transmission";
            dbContext.TransmissionTypes.Add(new TransmissionType() { Name = transmissionName });
            await dbContext.SaveChangesAsync();

            // Act
            var result = await transmissionService.CheckByNameExist(transmissionName);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task CheckByNameExist_TransmissionWithNameDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var transmissionName = "Non-existent Transmission";

            // Act
            var result = await transmissionService.CheckByNameExist(transmissionName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task DeleteAsync_TransmissionExists_Removes2TransmissionAndSavesChanges()
        {
            // Arrange
            var categoryName = "Test Category";
            var categoryToRemove = new TransmissionType() { Name = categoryName };
            dbContext.TransmissionTypes.Add(categoryToRemove);
            await dbContext.SaveChangesAsync();

            // Act
            await transmissionService.DeleteAsync(categoryToRemove.Id.ToString());

            // Assert
            Assert.IsFalse(dbContext.TransmissionTypes.Contains(categoryToRemove));
        }

        [Test]
        public void DeleteAsync_TransmissionDoesNotExist_ThrowsNullReferenceException()
        {
            // Arrange
            var nonExistentTransmissionId = "999"; // A non-existent transmission Id

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await transmissionService.DeleteAsync(nonExistentTransmissionId));
        }


        [Test]
        public async Task GetAllAsync_ReturnsAllCategories()
        {
            // Arrange

            // Act
            var result = await transmissionService.GetAllAsync();

            // Assert
            Assert.AreEqual(dbContext.TransmissionTypes.Count(), result.Count());
            // Assert that the count of returned categories is as expected

        }

    }

}


