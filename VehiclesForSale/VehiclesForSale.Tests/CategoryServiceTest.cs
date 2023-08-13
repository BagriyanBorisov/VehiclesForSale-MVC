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
    public class CategoryServiceTest
    {
        private DbContextOptions<VehiclesDbContext> dbOptions;
        private VehiclesDbContext dbContext;
        private ICategoryService categoryService;

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
            var invalidName =""; // An invalid name, empty in this case

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await categoryService.AddAsync(invalidName));
        }

        [Test]
        public async Task AddAsync_ValidName_CallsAddAsync()
        {
            // Arrange
            var validName = "Valid Name";

            // Act
            await categoryService.AddAsync(validName);
            
            // Assert
            Assert.That(dbContext.CategoryTypes.Any(c => c.Name == validName));
        }



        [Test]
        public async Task DeleteAsync_CategoryExists_RemovesCategoryAndSavesChanges()
        {
            // Arrange
            var categoryId = 1; // Assume there's a category with this ID in the seeded data

            // Act
            await categoryService.DeleteAsync(categoryId.ToString());

            // Assert
            var deletedCategory = await dbContext.CategoryTypes.FindAsync(categoryId);
            Assert.IsNull(deletedCategory); // The category should not be found in the database
        }

        [Test]
        public async Task CheckByNameExist_CategoryWithNameExists_ReturnsTrue()
        {
            // Arrange
            var categoryName = "Test Category";
            dbContext.CategoryTypes.Add(new CategoryType { Name = categoryName });
            await dbContext.SaveChangesAsync();

            // Act
            var result = await categoryService.CheckByNameExist(categoryName);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task CheckByNameExist_CategoryWithNameDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var categoryName = "Non-existent Category";

            // Act
            var result = await categoryService.CheckByNameExist(categoryName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task DeleteAsync_CategoryExists_Removes2CategoryAndSavesChanges()
        {
            // Arrange
            var categoryName = "Test Category";
            var categoryToRemove = new CategoryType { Name = categoryName };
            dbContext.CategoryTypes.Add(categoryToRemove);
            await dbContext.SaveChangesAsync();

            // Act
            await categoryService.DeleteAsync(categoryToRemove.Id.ToString());

            // Assert
            Assert.IsFalse(dbContext.CategoryTypes.Contains(categoryToRemove));
        }

        [Test]
        public void DeleteAsync_CategoryDoesNotExist_ThrowsNullReferenceException()
        {
            // Arrange
            var nonExistentCategoryId = "999"; // A non-existent category Id

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await categoryService.DeleteAsync(nonExistentCategoryId));
        }


        [Test]
        public async Task GetAllAsync_ReturnsAllCategories()
        {
            // Arrange

            // Act
            var result = await categoryService.GetAllAsync();

            // Assert
            Assert.AreEqual(dbContext.CategoryTypes.Count(), result.Count()); 
            // Assert that the count of returned categories is as expected

        }

    }

}


