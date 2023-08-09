namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel;

    public class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> builder)
        {
            builder.HasData(Seed());
        }

        private IEnumerable<Make> Seed()
        {
            List<Make> makes = new List<Make>
            {
                new Make { Name = "Any", Id = 1 },
                new Make { Name = "Mercedes-Benz", Id = 2 },
                new Make { Name = "BMW", Id = 3 },
                new Make { Name = "Audi", Id = 4 },
                new Make { Name = "Volkswagen", Id = 5 }
            };

            return makes;
        }
    }
}
