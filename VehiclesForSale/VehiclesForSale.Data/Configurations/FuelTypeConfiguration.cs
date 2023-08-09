namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel;

    public class FuelTypeConfiguration : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder.HasData(Seed());
        }

        private IEnumerable<FuelType> Seed()
        {
            List<FuelType> fuelTypes = new List<FuelType>
            {
                new FuelType { Name = "Any", Id = 1 },
                new FuelType { Name = "Gasoline", Id = 2 },
                new FuelType { Name = "Diesel", Id = 3 },
                new FuelType { Name = "Electric", Id = 4 },
                new FuelType { Name = "Hybrid(D/E)", Id = 5 },
                new FuelType { Name = "Hybrid(G/E)", Id = 6 },
                new FuelType { Name = "LPG", Id = 7 }
            };

            return fuelTypes;
        }
    }
}