namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel.Extras;

    public class SafetyExtrasConfiguration : IEntityTypeConfiguration<SafetyExtra>
    {
        public void Configure(EntityTypeBuilder<SafetyExtra> builder)
        {
            builder
               .HasOne(v => v.Extra)
               .WithMany(v => v.SafetyExtras)
               .HasForeignKey(v => v.ExtraId) // Assuming ExtraId is the foreign key in child extras
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(Seed());
        }

        private IEnumerable<SafetyExtra> Seed()
        {
            List<SafetyExtra> safetyExtras = new List<SafetyExtra>
            {
                new SafetyExtra { Name = "Anti-lock Braking System (ABS)", Id = 1 },
                new SafetyExtra { Name = "Electronic Stability Control (ESC)", Id = 2 },
                new SafetyExtra { Name = "Blind Spot Monitoring (BSM) System", Id = 3 },
                new SafetyExtra { Name = "Lane Departure Warning (LDW)", Id = 4 },
                new SafetyExtra { Name = "Lane Keeping Assist (LKA)", Id = 5 }
            };

            return safetyExtras;
        }
    }
}