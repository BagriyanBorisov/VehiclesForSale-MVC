using System.Collections.Immutable;

namespace VehiclesForSale.Tests
{
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts.Extra;
    using Core.Services.Extra;
    using Data;
    using Web.ViewModels.Vehicle;
    using static DatabaseSeeder;

    [TestFixture]
    public class ExtraServiceTest
    {
        private DbContextOptions<VehiclesDbContext> dbOptions;
        private VehiclesDbContext dbContext;
        private IExtraService extraService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<VehiclesDbContext>()
                .UseInMemoryDatabase("VehiclesDbInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new VehiclesDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.extraService = new ExtraService(this.dbContext);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            dbContext.Dispose();
        }

        [Test]
        public async Task CheckOwner_ValidOwner_ReturnsTrue()
        {
            // Arrange
            var vehicle = dbContext.Vehicles.Select(v => v).First();
           

            // Act
            var result = await extraService.CheckOwner(vehicle.Id.ToString(), vehicle.OwnerId);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task CheckOwner_ValidOwner_ReturnsFalse()
        {
            // Arrange
            var vehicle = dbContext.Vehicles.Select(v => v).First();


            // Act
            var result = await extraService.CheckOwner(vehicle.Id.ToString() + "asd", vehicle.OwnerId);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task CheckOwner_InValidOwner_ReturnsFalse()
        {
            // Arrange
            var vehicle = dbContext.Vehicles.Select(v => v).First();


            // Act
            var result = await extraService.CheckOwner(vehicle.Id.ToString() + "asd", vehicle.OwnerId + "asd123");

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task CheckOwner_InValidOwnerTwo_ReturnsFalse()
        {
            // Arrange
            var vehicle = dbContext.Vehicles.Select(v => v).First();


            // Act
            var result = await extraService.CheckOwner(vehicle.Id.ToString(), vehicle.OwnerId + "asd123");

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task AddExtraAsync_ValidInput_UpdatesDatabase()
        {
            // Arrange
            var vehicle = dbContext.Vehicles.First(); // Get a valid vehicle
            var extraId = vehicle.ExtraId.ToString(); // Get a valid extra ID
            var extraVm = new ExtraFormViewModel
            {
                SafetyExtrasChecked = new List<string> { "Safety123", "Safety1234" }, // Provide some checked extras
                ComfortExtrasChecked = new List<string> { "Comfort12345", "Comfort12346" },
                ExteriorExtrasChecked = new List<string> { "Exterior123", "Exterior1234" },
                InteriorExtrasChecked = new List<string> { "Interior1234", "Interior123" },
                OtherExtrasChecked = new List<string> { "Other1234", "Other1236" }
            };

            // Act
            await extraService.AddExtraAsync(extraVm, vehicle.OwnerId, extraId);

            // Assert
            // Query the database to retrieve the added extras
            var addedExteriorExtras = dbContext.ExteriorExtras
                .Where(e => e.ExtraId.ToString() == extraId)
                .ToList();
            var addedInteriorExtras = dbContext.InteriorExtras
                .Where(e => e.ExtraId.ToString() == extraId)
                .ToList();
            var addedComfortExtras = dbContext.ComfortExtras
                .Where(e => e.ExtraId.ToString() == extraId)
                .ToList();
            var addedSafetyExtras = dbContext.SafetyExtras
                .Where(e => e.ExtraId.ToString() == extraId)
                .ToList();
            var addedOtherExtras = dbContext.OtherExtras
                .Where(e => e.ExtraId.ToString() == extraId)
                .ToList();

            // Perform assertions for each type of extra
            foreach (var extra in extraVm.SafetyExtrasChecked)
            {
                Assert.That(addedSafetyExtras.Any(e => e.Name == extra), Is.True);
            }

            foreach (var extra in extraVm.ComfortExtrasChecked)
            {
                Assert.That(addedComfortExtras.Any(e => e.Name == extra), Is.True);
            }

            foreach (var extra in extraVm.ExteriorExtrasChecked)
            {
                Assert.That(addedExteriorExtras.Any(e => e.Name == extra), Is.True);
            }

            foreach (var extra in extraVm.InteriorExtrasChecked)
            {
                Assert.That(addedInteriorExtras.Any(e => e.Name == extra), Is.True);
            }

            foreach (var extra in extraVm.OtherExtrasChecked)
            {
                Assert.That(addedOtherExtras.Any(e => e.Name == extra), Is.True);
            }
        }

        [Test]
        public void AddExtraAsync_InvalidVehicle_ThrowsException()
        {
            // Arrange
            var invalidVehicleId = "invalid"; // Provide an invalid vehicle ID
            var extraId = dbContext.Extras.First().Id.ToString(); // Get a valid extra ID
            var extraVm = new ExtraFormViewModel();

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await extraService.AddExtraAsync(extraVm, invalidVehicleId, extraId));
        }

        [Test]
        public void AddExtraAsync_InvalidExtra_ThrowsException()
        {
            // Arrange
            var vehicle = dbContext.Vehicles.First(); // Get a valid vehicle
            var invalidExtraId = "invalid"; // Provide an invalid extra ID
            var extraVm = new ExtraFormViewModel();

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await extraService.AddExtraAsync(extraVm, vehicle.OwnerId, invalidExtraId));
        }

        [Test]
        public async Task GetAddExtraAsync_ValidVehicleId_ReturnsExtraFormViewModel()
        {
            // Arrange
            var vehicle = dbContext.Vehicles.First(); // Get a vehicle from the database

            // Act
            var result = await extraService.GetAddExtraAsync(vehicle.Id.ToString());

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(result.ExtraId, vehicle.ExtraId);
            // Perform more assertions as needed
        }

        [Test]
        public void GetAddExtraAsync_InvalidVehicleId_ThrowsNullReferenceException()
        {
            // Arrange
            var invalidId = "invalidId";

            // Act and Assert
            Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await extraService.GetAddExtraAsync(invalidId);
            });
        }

        [Test]
        public async Task GetEditExtraAsync_ValidVehicleId_ReturnsExtraFormViewModel()
        {
            // Arrange
            var vehicle = dbContext.Vehicles.First(); // Get a vehicle from the database

            // Act
            var result = await extraService.GetEditExtraAsync(vehicle.Id.ToString());

            // Assert
            Assert.NotNull(result);
            // Perform more assertions based on the expected result
        }

        [Test]
        public void GetEditExtraAsync_InvalidVehicleId_ThrowsNullReferenceException()
        {
            // Arrange
            var invalidId = "invalidId";

            // Act and Assert
            Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await extraService.GetEditExtraAsync(invalidId);
            });
        }

        [Test]
        public async Task EditExtraAsync_ValidData_UpdatesExtrasAndDatabase()
        {
            // Arrange
            var vehicle = dbContext.Vehicles.First(); // Get a vehicle from the database
            var extraId = vehicle.ExtraId.ToString();
            var userId = vehicle.OwnerId;

            var extraVm = new ExtraFormViewModel
            {
                InteriorExtrasChecked = new List<string> { "InteriorExtra1" }, // Example: Add your desired extras here
                ExteriorExtrasChecked = new List<string> { "ExteriorExtra1" },
                SafetyExtrasChecked = new List<string> { "SafetyExtra1" },
                ComfortExtrasChecked = new List<string> { "ComfortExtra1" },
                OtherExtrasChecked = new List<string> { "OtherExtra1" }
            };

            // Act
            await extraService.EditExtraAsync(extraVm, userId, extraId);

            // Assert
            var updatedVehicle = dbContext.Vehicles
                .Include(v => v.Extra)
                .First(v => v.Id == vehicle.Id);

            var updatedExtraDb = dbContext.Extras
                .Include(e => e.SafetyExtras)
                .Include(e => e.ComfortExtras)
                .Include(e => e.ExteriorExtras)
                .Include(e => e.InteriorExtras)
                .Include(e => e.OtherExtras)
                .First(e => e.Id.ToString() == extraId);

            // Assert that extras and database are updated as expected
            Assert.AreEqual( 1, updatedExtraDb.SafetyExtras.Count()); 
            Assert.AreEqual( 1, updatedExtraDb.ComfortExtras.Count());
            Assert.AreEqual( 1, updatedExtraDb.ExteriorExtras.Count()); 
            Assert.AreEqual( 1, updatedExtraDb.InteriorExtras.Count()); 
            Assert.AreEqual( 1, updatedExtraDb.OtherExtras.Count());

           
        }

        [Test]
        public void EditExtraAsync_InvalidData_ThrowsException()
        {
            // Arrange
            var vehicle = dbContext.Vehicles.First(); // Get a vehicle from the database
            var extraId = vehicle.ExtraId.ToString();
            var userId = vehicle.OwnerId;

            var initialSafetyExtrasCount = dbContext.SafetyExtras.Count();
            var initialComfortExtrasCount = dbContext.ComfortExtras.Count();
            var initialExteriorExtrasCount = dbContext.ExteriorExtras.Count();
            var initialInteriorExtrasCount = dbContext.InteriorExtras.Count();
            var initialOtherExtrasCount = dbContext.OtherExtras.Count();

            // Invalid data: extras that don't exist in the database
            var extraVm = new ExtraFormViewModel
            {
                InteriorExtrasChecked = new List<string> { "InvalidInteriorExtra" },
                ExteriorExtrasChecked = new List<string> { "InvalidExteriorExtra" },
                SafetyExtrasChecked = new List<string> { "InvalidSafetyExtra" },
                ComfortExtrasChecked = new List<string> { "InvalidComfortExtra" },
                OtherExtrasChecked = new List<string> { "InvalidOtherExtra" }
            };

            // Act and Assert
            Assert.ThrowsAsync<NullReferenceException>(
                async () => await extraService.EditExtraAsync(extraVm, userId, extraId + "asd"));

            // Assert that the counts of extras remain unchanged
            Assert.AreEqual(initialSafetyExtrasCount, dbContext.SafetyExtras.Count());
            Assert.AreEqual(initialComfortExtrasCount, dbContext.ComfortExtras.Count());
            Assert.AreEqual(initialExteriorExtrasCount, dbContext.ExteriorExtras.Count());
            Assert.AreEqual(initialInteriorExtrasCount, dbContext.InteriorExtras.Count());
            Assert.AreEqual(initialOtherExtrasCount, dbContext.OtherExtras.Count());
        }

        [Test]
        public async Task GetInteriorExtrasAsync_ReturnsInteriorExtras()
        {
            // Arrange
            var initialInteriorExtrasCount = dbContext.InteriorExtras.Count();

            // Act
            var result = await extraService.GetInteriorExtrasAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<InteriorExtraFormViewModel>>(result);

            var newInteriorExtrasCount = dbContext.InteriorExtras.Count();
            Assert.AreEqual(initialInteriorExtrasCount, newInteriorExtrasCount); // Ensure the count of actual records hasn't changed

        }

        [Test]
        public async Task GetExteriorExtrasAsync_ReturnsExteriorExtras()
        {
            // Arrange
            var initialExteriorExtrasCount = dbContext.ExteriorExtras.Count();

            // Act
            var result = await extraService.GetExteriorExtrasAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<ExteriorExtraFormViewModel>>(result);

            var newExteriorExtrasCount = dbContext.ExteriorExtras.Count();
            Assert.AreEqual(initialExteriorExtrasCount, newExteriorExtrasCount); // Ensure the count of actual records hasn't changed
        }

        [Test]
        public async Task GetSafetyExtrasAsync_ReturnsSafetyExtras()
        {
            // Arrange
            var initialSafetyExtrasCount = dbContext.SafetyExtras.Count();

            // Act
            var result = await extraService.GetSafetyExtrasAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<SafetyExtraFormViewModel>>(result);

            var newSafetyExtrasCount = dbContext.SafetyExtras.Count();
            Assert.AreEqual(initialSafetyExtrasCount, newSafetyExtrasCount); // Ensure the count of actual records hasn't changed
        }

        [Test]
        public async Task GetComfortExtrasAsync_ReturnsComfortExtras()
        {
            // Arrange
            var initialComfortExtrasCount = dbContext.ComfortExtras.Count();

            // Act
            var result = await extraService.GetComfortExtrasAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<ComfortExtraFormViewModel>>(result);

            var newComfortExtrasCount = dbContext.ComfortExtras.Count();
            Assert.AreEqual(initialComfortExtrasCount, newComfortExtrasCount); // Ensure the count of actual records hasn't changed
        }

        [Test]
        public async Task GetOtherExtrasAsync_ReturnsOtherExtras()
        {
            // Arrange
            var initialOtherExtrasCount = dbContext.OtherExtras.Count();

            // Act
            var result = await extraService.GetOtherExtrasAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<OtherExtraFormViewModel>>(result);

            var newOtherExtrasCount = dbContext.OtherExtras.Count();
            Assert.AreEqual(initialOtherExtrasCount, newOtherExtrasCount); // Ensure the count of actual records hasn't changed
        }

        [Test]
        public async Task CheckInteriorByNameExist_ExistingName_ReturnsTrue()
        {
            // Arrange
            var existingName = dbContext.InteriorExtras.Select(i => i.Name).First(); // Replace with an existing name in your database

            // Act
            var result = await extraService.CheckInteriorByNameExist(existingName);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task CheckInteriorByNameExist_NonExistingName_ReturnsFalse()
        {
            // Arrange
            var nonExistingName = "nonExistingName"; // Replace with a name that doesn't exist in your database

            // Act
            var result = await extraService.CheckInteriorByNameExist(nonExistingName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task CheckExteriorByNameExist_ExistingName_ReturnsTrue()
        {
            // Arrange
            var existingName = dbContext.ExteriorExtras.Select(e => e.Name).First();

            // Act
            var result = await extraService.CheckExteriorByNameExist(existingName);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task CheckExteriorByNameExist_NonExistingName_ReturnsFalse()
        {
            // Arrange
            var nonExistingName = "nonExistingName"; // Replace with a name that doesn't exist in your database

            // Act
            var result = await extraService.CheckExteriorByNameExist(nonExistingName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task CheckSafetyByNameExist_ExistingName_ReturnsTrue()
        {
            // Arrange
            var existingName = dbContext.SafetyExtras.Select(s => s.Name).First();

            // Act
            var result = await extraService.CheckSafetyByNameExist(existingName);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task CheckSafetyByNameExist_NonExistingName_ReturnsFalse()
        {
            // Arrange
            var nonExistingName = "nonExistingName"; // Replace with a name that doesn't exist in your database

            // Act
            var result = await extraService.CheckSafetyByNameExist(nonExistingName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task CheckComfortByNameExist_ExistingName_ReturnsTrue()
        {
            // Arrange
            var existingName = dbContext.ComfortExtras.Select(c => c.Name).First();

            // Act
            var result = await extraService.CheckComfortByNameExist(existingName);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task CheckComfortByNameExist_NonExistingName_ReturnsFalse()
        {
            // Arrange
            var nonExistingName = "nonExistingName"; // Replace with a name that doesn't exist in your database

            // Act
            var result = await extraService.CheckComfortByNameExist(nonExistingName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task CheckOtherByNameExist_ExistingName_ReturnsTrue()
        {
            // Arrange
            var existingName = dbContext.OtherExtras.Select(o => o.Name).First();

            // Act
            var result = await extraService.CheckOtherByNameExist(existingName);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task CheckOtherByNameExist_NonExistingName_ReturnsFalse()
        {
            // Arrange
            var nonExistingName = "nonExistingName"; // Replace with a name that doesn't exist in your database

            // Act
            var result = await extraService.CheckOtherByNameExist(nonExistingName);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task AddInteriorAsync_ValidName_AddsInteriorExtra()
        {
            // Arrange
            var validName = "NewInteriorExtra";

            // Act
            await extraService.AddInteriorAsync(validName);

            // Assert
            var addedInteriorExtra = await dbContext.InteriorExtras.FirstOrDefaultAsync(ex => ex.Name == validName);
            Assert.NotNull(addedInteriorExtra);
        }

        [Test]
        public async Task AddInteriorAsync_NullName_DoesNotAddInteriorExtra()
        {
            // Arrange
            string nullName = null;

            // Act
            await extraService.AddInteriorAsync(nullName);

            // Assert
            var addedInteriorExtra = await dbContext.InteriorExtras.FirstOrDefaultAsync(ex => ex.Name == nullName);
            Assert.Null(addedInteriorExtra);
        }

        [Test]
        public async Task AddExteriorAsync_ValidName_AddsExteriorExtra()
        {
            // Arrange
            var validName = "NewExteriorExtra";

            // Act
            await extraService.AddExteriorAsync(validName);

            // Assert
            var addedExteriorExtra = await dbContext.ExteriorExtras.FirstOrDefaultAsync(ex => ex.Name == validName);
            Assert.NotNull(addedExteriorExtra);
        }

        [Test]
        public async Task AddExteriorAsync_NullName_DoesNotAddExteriorExtra()
        {
            // Arrange
            string nullName = null;

            // Act
            await extraService.AddExteriorAsync(nullName);

            // Assert
            var addedExteriorExtra = await dbContext.ExteriorExtras.FirstOrDefaultAsync(ex => ex.Name == nullName);
            Assert.Null(addedExteriorExtra);
        }

        [Test]
        public async Task AddSafetyAsync_ValidName_AddsSafetyExtra()
        {
            // Arrange
            var validName = "NewSafetyExtra";

            // Act
            await extraService.AddSafetyAsync(validName);

            // Assert
            var addedSafetyExtra = await dbContext.SafetyExtras.FirstOrDefaultAsync(ex => ex.Name == validName);
            Assert.NotNull(addedSafetyExtra);
        }

        [Test]
        public async Task AddSafetyAsync_NullName_DoesNotAddSafetyExtra()
        {
            // Arrange
            string nullName = null;

            // Act
            await extraService.AddSafetyAsync(nullName);

            // Assert
            var addedSafetyExtra = await dbContext.SafetyExtras.FirstOrDefaultAsync(ex => ex.Name == nullName);
            Assert.Null(addedSafetyExtra);
        }

        [Test]
        public async Task AddComfortAsync_ValidName_AddsComfortExtra()
        {
            // Arrange
            var validName = "NewComfortExtra";

            // Act
            await extraService.AddComfortAsync(validName);

            // Assert
            var addedComfortExtra = await dbContext.ComfortExtras.FirstOrDefaultAsync(ex => ex.Name == validName);
            Assert.NotNull(addedComfortExtra);
        }

        [Test]
        public async Task AddComfortAsync_NullName_DoesNotAddComfortExtra()
        {
            // Arrange
            string nullName = null;

            // Act
            await extraService.AddComfortAsync(nullName);

            // Assert
            var addedComfortExtra = await dbContext.ComfortExtras.FirstOrDefaultAsync(ex => ex.Name == nullName);
            Assert.Null(addedComfortExtra);
        }

        [Test]
        public async Task AddOtherAsync_ValidName_AddsOtherExtra()
        {
            // Arrange
            var validName = "NewOtherExtra";

            // Act
            await extraService.AddOtherAsync(validName);

            // Assert
            var addedOtherExtra = await dbContext.OtherExtras.FirstOrDefaultAsync(ex => ex.Name == validName);
            Assert.NotNull(addedOtherExtra);
        }

        [Test]
        public async Task AddOtherAsync_NullName_DoesNotAddOtherExtra()
        {
            // Arrange
            string nullName = null;

            // Act
            await extraService.AddOtherAsync(nullName);

            // Assert
            var addedOtherExtra = await dbContext.InteriorExtras.FirstOrDefaultAsync(ex => ex.Name == nullName);
            Assert.Null(addedOtherExtra);
        }

        [Test]
        public async Task DeleteInteriorAsync_ValidId_DeletesInteriorExtra()
        {
            // Arrange
            var interiorExtraToDelete = dbContext.InteriorExtras.First(); // Get an existing interior extra

            // Act
            await extraService.DeleteInteriorAsync(interiorExtraToDelete.Id.ToString());

            // Assert
            var deletedInteriorExtra = await dbContext.InteriorExtras.FirstOrDefaultAsync(ex => ex.Id == interiorExtraToDelete.Id);
            Assert.Null(deletedInteriorExtra);
        }

        [Test]
        public void DeleteInteriorAsync_InvalidId_ThrowsNullReferenceException()
        {
            // Arrange
            var invalidId = "nonexistent_id";

            // Act and Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await extraService.DeleteInteriorAsync(invalidId));
        }

        [Test]
        public async Task DeleteExteriorAsync_ValidId_DeletesExteriorExtra()
        {
            // Arrange
            var exteriorExtraToDelete = dbContext.ExteriorExtras.First(); // Get an existing exterior extra

            // Act
            await extraService.DeleteExteriorAsync(exteriorExtraToDelete.Id.ToString());

            // Assert
            var deletedExteriorExtra = await dbContext.ExteriorExtras.FirstOrDefaultAsync(ex => ex.Id == exteriorExtraToDelete.Id);
            Assert.Null(deletedExteriorExtra);
        }

        [Test]
        public void DeleteExteriorAsync_InvalidId_ThrowsNullReferenceException()
        {
            // Arrange
            var invalidId = "nonexistent_id";

            // Act and Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await extraService.DeleteExteriorAsync(invalidId));
        }

        [Test]
        public async Task DeleteSafetyAsync_ValidId_DeletesSafetyExtra()
        {
            // Arrange
            var safetyExtraToDelete = dbContext.SafetyExtras.First(); // Get an existing safety extra

            // Act
            await extraService.DeleteSafetyAsync(safetyExtraToDelete.Id.ToString());

            // Assert
            var deletedSafetyExtra = await dbContext.SafetyExtras.FirstOrDefaultAsync(ex => ex.Id == safetyExtraToDelete.Id);
            Assert.Null(deletedSafetyExtra);
        }

        [Test]
        public void DeleteSafetyAsync_InvalidId_ThrowsNullReferenceException()
        {
            // Arrange
            var invalidId = "nonexistent_id";

            // Act and Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await extraService.DeleteSafetyAsync(invalidId));
        }

        [Test]
        public async Task DeleteComfortAsync_ValidId_DeletesComfortExtra()
        {
            // Arrange
            var comfortExtraToDelete = dbContext.ComfortExtras.First(); // Get an existing comfort extra

            // Act
            await extraService.DeleteComfortAsync(comfortExtraToDelete.Id.ToString());

            // Assert
            var deletedComfortExtra = await dbContext.ComfortExtras.FirstOrDefaultAsync(ex => ex.Id == comfortExtraToDelete.Id);
            Assert.Null(deletedComfortExtra);
        }

        [Test]
        public void DeleteComfortAsync_InvalidId_ThrowsNullReferenceException()
        {
            // Arrange
            var invalidId = "nonexistent_id";

            // Act and Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await extraService.DeleteComfortAsync(invalidId));
        }

        [Test]
        public async Task DeleteOtherAsync_ValidId_DeletesOtherExtra()
        {
            // Arrange
            var otherExtraToDelete = dbContext.OtherExtras.First(); // Get an existing other extra

            // Act
            await extraService.DeleteOtherAsync(otherExtraToDelete.Id.ToString());

            // Assert
            var deletedOtherExtra = await dbContext.OtherExtras.FirstOrDefaultAsync(ex => ex.Id == otherExtraToDelete.Id);
            Assert.Null(deletedOtherExtra);
        }

        [Test]
        public void DeleteOtherAsync_InvalidId_ThrowsNullReferenceException()
        {
            // Arrange
            var invalidId = "nonexistent_id";

            // Act and Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await extraService.DeleteOtherAsync(invalidId));
        }



    }
}
