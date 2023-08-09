using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Models.VehicleModel;

    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasOne(v => v.Model)
                .WithMany(m => m.VehiclesFromModel)
                .HasForeignKey(v => v.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(v => v.Date)
                .WithMany(d => d.Vehicles)
                .HasForeignKey(v => v.DateId);
        }

        private IEnumerable<Vehicle> Seed()
        {
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle {
                    Title = "Mercedes-Benz E class 320CDI",
                    CategoryTypeId = 2, Price = 10000,
                    CubicCapacity = 3224,
                    DateId = 123,
                    Mileage = 300000,
                    HorsePower = 224,
                    MakeId = 1,
                    ModelId = 1,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    ColorId = 5,
                    OwnerId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                }

                };

            return vehicles;
        }
    }
}
