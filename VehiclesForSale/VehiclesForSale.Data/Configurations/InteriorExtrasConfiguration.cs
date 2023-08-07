namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel.Extras;

    public class InteriorExtrasConfiguration : IEntityTypeConfiguration<InteriorExtra>
    {
        public void Configure(EntityTypeBuilder<InteriorExtra> builder)
        {
            builder
               .HasOne(v => v.Extra)
               .WithMany(v => v.InteriorExtras)
               .HasForeignKey(v => v.ExtraId) // Assuming ExtraId is the foreign key in child extras
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(Seed());
        }

        private IEnumerable<InteriorExtra> Seed()
        {
            List<InteriorExtra> interiorExtras = new List<InteriorExtra>
            {
                new InteriorExtra { Name = "Heated Seats", Id = 1 },
                new InteriorExtra { Name = "Panoramic Sunroof", Id = 2 },
                new InteriorExtra { Name = "Infotainment System", Id = 3 },
                new InteriorExtra { Name = "Key less Entry and Push-Button Start", Id = 4 }
            };

            return interiorExtras;
        }
    }
}