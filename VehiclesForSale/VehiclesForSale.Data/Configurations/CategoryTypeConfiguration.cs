namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel;

    public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
    {
        public void Configure(EntityTypeBuilder<CategoryType> builder)
        {
            builder.HasData(Seed());
        }

        private IEnumerable<CategoryType> Seed()
        {
            List<CategoryType> categoryTypes = new List<CategoryType>
            {
                new CategoryType { Name = "Any", Id = 1 },
                new CategoryType { Name = "Sedan", Id = 2 },
                new CategoryType { Name = "SUV", Id = 3 },
                new CategoryType { Name = "MUV", Id = 4 },
                new CategoryType { Name = "Coupe", Id = 5 },
                new CategoryType { Name = "Convertible", Id = 6 },
                new CategoryType { Name = "Pickup Truck", Id = 7 },
                new CategoryType { Name = "Hatchback", Id = 8 }
            };

            return categoryTypes;
        }
    }
}