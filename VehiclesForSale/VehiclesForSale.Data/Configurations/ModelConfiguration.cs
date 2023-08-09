namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel;

    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasData(Seed());
        }

        private IEnumerable<Model> Seed()
        {
            List<Model> models = new List<Model>
            {
                new Model { Name = "Any", Id = 1, MakeId = 1 },
                new Model { Name = "W211", Id = 2, MakeId = 2 },
                new Model { Name = "W209", Id = 3, MakeId = 2 },
                new Model { Name = "W203", Id = 4, MakeId = 2 },
                new Model { Name = "W219", Id = 5, MakeId = 2 },
                new Model { Name = "E46", Id = 6, MakeId = 3 },
                new Model { Name = "E60", Id = 7, MakeId = 3 },
                new Model { Name = "E90", Id = 8, MakeId = 3 },
                new Model { Name = "E39", Id = 9, MakeId = 3 },
                new Model { Name = "A3", Id = 10, MakeId = 4 },
                new Model { Name = "A4", Id = 11, MakeId = 4 },
                new Model { Name = "A5", Id = 12, MakeId = 4 },
                new Model { Name = "A6", Id = 13, MakeId = 4 }
            };

            return models;
        }
    }
}