using VehiclesForSale.Data.Models;
using VehiclesForSale.Data.Models.VehicleModel.Enums;

namespace VehiclesForSale.Tests
{
    using Microsoft.AspNetCore.Identity;
    using VehiclesForSale.Data;

    using VehiclesForSale.Data.Models.VehicleModel;
    using VehiclesForSale.Data.Models.VehicleModel.Extras;

    public static class DatabaseSeeder
    {
        public static List<CategoryType> CategoryTypes;
        public static List<TransmissionType> TransmissionTypes;
        public static List<Color> Colors;
        public static List<FuelType> FuelTypes;
        public static List<Extra> Extras;
        public static List<ComfortExtra> ComfortExtras;
        public static List<ExteriorExtra> ExteriorExtras;
        public static List<InteriorExtra> InteriorExtras;
        public static List<SafetyExtra> SafetyExtras;
        public static List<OtherExtra> OtherExtras;
        public static List<ApplicationUser> Users;
        public static List<Vehicle> Vehicles;
        public static List<Make> Makes;
        public static List<Model> Models;
        public static List<Date> Dates;
        public static List<Image> Images;


        public static void SeedDatabase(VehiclesDbContext dbContext)
        {
           

            CategoryTypes = new List<CategoryType>()
            {
                new CategoryType()
                {
                    Name = "Category1"
                },
                new CategoryType()
                {
                    Name = "Category2"
                },
                new CategoryType()
                {
                    Name = "Category3"
                },
                new CategoryType()
                {
                    Name = "Category4"
                },
                new CategoryType()
                {
                    Name = "Category5"
                },
            };

            TransmissionTypes = new List<TransmissionType>()
            {
                new TransmissionType { Name = "Any"},
                new TransmissionType { Name = "Manual"},
                new TransmissionType { Name = "Automatic"},
                new TransmissionType { Name = "CVT" },
                new TransmissionType { Name = "Semi-Automatic" }
            };

            Colors = new List<Color>
            {
                new Color { Name = "Any" },
                new Color { Name = "Black" },
                new Color { Name = "Gray" },
                new Color { Name = "Silver" },
                new Color { Name = "Blue"},
                new Color { Name = "Red"},
                new Color { Name = "Brown" },
                new Color { Name = "Green" },
                new Color { Name = "Orange" },
                new Color { Name = "Beige"},
                new Color { Name = "Purple", },
                new Color { Name = "Gold"},
                new Color { Name = "Yellow" },
                new Color { Name = "White"}
            };

            FuelTypes = new List<FuelType>
            {
                new FuelType() { Name = "Diesel" },
                new FuelType() { Name = "Gasoline" } ,
                new FuelType() { Name = "Hybrid" } ,
            };

            Extras = new List<Extra>
            {
                new Extra(),
                new Extra(),
                new Extra(),
                new Extra(),
                new Extra(),

            };

            SafetyExtras = new List<SafetyExtra>
            {
                new SafetyExtra()
                {
                    ExtraId = null,
                    Name = "Safety1"
                },
                new SafetyExtra()
                {
                    ExtraId = null,
                    Name = "Safety2"
                },
                new SafetyExtra()
                {
                    Extra = Extras.ElementAt(1),
                    Name = "Safety3"
                },
            };

            ComfortExtras = new List<ComfortExtra>
            {
                new ComfortExtra()
                {
                    ExtraId = null,
                    Name = "Comfort1"
                },
                new ComfortExtra()
                {
                    ExtraId = null,
                    Name = "Comfort2"
                },
                new ComfortExtra()
                { 
                    Extra = Extras.ElementAt(1),
                    Name = "Comfort3"
                },
            };

            InteriorExtras = new List<InteriorExtra>
            {
                new InteriorExtra()
                {
                    ExtraId = null,
                    Name = "Interior1"
                },
                new InteriorExtra()
                {
                    ExtraId = null,
                    Name = "Interior2"
                },
                new InteriorExtra()
                {
                    Extra = Extras.ElementAt(1),
                    Name = "Interior3"
                }
            };

            ExteriorExtras = new List<ExteriorExtra>
            {
                new ExteriorExtra()
                {
                    ExtraId = null,
                    Name = "Exterior1"
                },
                new ExteriorExtra()
                {
                    ExtraId = null,
                    Name = "Exterior2"
                },
                new ExteriorExtra()
                {
                    Extra = Extras.ElementAt(1),
                    Name = "Exterior3"
                }
            };

            OtherExtras = new List<OtherExtra>
            {
                new OtherExtra()
                {
                    ExtraId = null,
                    Name = "Other1"
                },
                new OtherExtra()
                {
                    ExtraId = null,
                    Name = "Other2"
                },
                new OtherExtra()
                {
                    Extra = Extras.ElementAt(1),
                    Name = "Other2"
                },
            };

            var hasher = new PasswordHasher<IdentityUser>();

            Users = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = "3980b47a-31d5-4df8-9609-25c3db1cd533", // primary key
                    Email = "Pesho.peshev@abv.bg",
                    NormalizedEmail = "PESHO.PESHEV@ABV.bg",
                    UserName = "Pesho",
                    NormalizedUserName = "pesho",
                    PhoneNumber = "+359222222222",
                    RegistrationDate = DateTime.UtcNow,
                    PasswordHash = hasher.HashPassword(null, "admin1234")
                },
                new ApplicationUser()
                {
                    Id = "46b566bb-2410-4fad-9fba-465c69d5e38f", // primary key
                    Email = "Gosho.goshev@abv.bg",
                    NormalizedEmail = "GOSHO.GOSHEV@ABV.BG",
                    UserName = "Gosho",
                    NormalizedUserName = "gosho",
                    PhoneNumber = "+359111111111",
                    RegistrationDate = DateTime.UtcNow,
                    PasswordHash = hasher.HashPassword(null, "user1234")
                }
        };

            Makes = new List<Make>()
            {
                new Make()
                {
                    Name = "Make1"
                },
                new Make()
                {
                    Name = "Make2"
                 },
                new Make()
                {
                    Name = "Make3"
                },
                new Make()
                {
                    Name = "Make3"
                }
            };

            Models = new List<Model>
            {
                new Model()
                {
                    MakeId = 1,
                    Name = "Model1"
                },
                new Model()
                {
                    MakeId = 2,
                    Name = "Model2"
                },
                new Model()
                {
                    MakeId = 3,
                    Name = "Model3"
                },

            };

            Dates = new List<Date>
            {
                new Date()
                {
                    Year = 1,
                    Month = Month.January
                },
                new Date()
                {
                    Year = 1,
                    Month = Month.February
                },
                new Date()
                {
                    Year = 1,
                    Month = Month.March
                },

                new Date()
                {
                    Year = 1,
                    Month = Month.April
                },

            };

            Vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Title = "Vehicle 1",
                    Price = 20000,
                    CubicCapacity = 2000,
                    DateId = 1,
                    Mileage = 50000,
                    HorsePower = 150,
                    Location = "Location 1",
                    Description = "Description 1",
                    DateAdded = DateTime.UtcNow,
                    MakeId = 1,
                    ModelId = 1,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    ColorId = 1,
                    CategoryTypeId = 1,
                    ExtraId = 1,
                    OwnerId = "46b566bb-2410-4fad-9fba-465c69d5e38f"
                },
                new Vehicle
                {
                    Title = "Vehicle 2",
                    Price = 25000,
                    CubicCapacity = 1800,
                    DateId = 2,
                    Mileage = 60000,
                    HorsePower = 140,
                    Location = "Location 2",
                    Description = "Description 2",
                    DateAdded = DateTime.UtcNow,
                    MakeId = 2,
                    ModelId = 2,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    ColorId = 2,
                    CategoryTypeId = 2,
                    ExtraId = 2,
                    OwnerId = "3980b47a-31d5-4df8-9609-25c3db1cd533"

                }

            };

            Images = new List<Image>
            {
                new Image()
                {
                    ImageUrl = "imagePath1",
                    VehicleId = Vehicles.Select(v => v.Id).FirstOrDefault(),
                },
                new Image()
                {
                    ImageUrl = "imagePath2",
                    VehicleId = Vehicles.Select(v => v.Id).FirstOrDefault(),
                },
                new Image()
                {
                    ImageUrl = "imagePath3",
                    VehicleId = Vehicles.Where(v => v.Title == "Vehicle 2").Select(v => v.Id).FirstOrDefault(),
                },
                new Image()
                {
                    ImageUrl = "imagePath4",
                    VehicleId = Vehicles.Where(v => v.Title == "Vehicle 2").Select(v => v.Id).FirstOrDefault(),
                },

            };


            dbContext.CategoryTypes.AddRange(CategoryTypes);
            dbContext.TransmissionTypes.AddRange(TransmissionTypes);
            dbContext.Colors.AddRange(Colors);
            dbContext.FuelTypes.AddRange(FuelTypes);
            dbContext.Extras.AddRange(Extras);
            dbContext.SafetyExtras.AddRange(SafetyExtras);
            dbContext.InteriorExtras.AddRange(InteriorExtras);
            dbContext.ExteriorExtras.AddRange(ExteriorExtras);
            dbContext.OtherExtras.AddRange(OtherExtras);
            dbContext.ComfortExtras.AddRange(ComfortExtras);
            dbContext.Users.AddRange(Users);
            dbContext.Vehicles.AddRange(Vehicles);
           

            dbContext.SaveChanges();
        }

            
    }
}

