namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.VehicleModel;

    public class TransmissionTypeConfiguration : IEntityTypeConfiguration<TransmissionType>
    {
        public void Configure(EntityTypeBuilder<TransmissionType> builder)
        {
            builder.HasData(Seed());
        }

        private IEnumerable<TransmissionType> Seed()
        {
            List<TransmissionType> transmissionTypes = new List<TransmissionType>
            {
                new TransmissionType { Name = "Any", Id = 1 },
                new TransmissionType { Name = "Manual", Id = 2 },
                new TransmissionType { Name = "Automatic", Id = 3 },
                new TransmissionType { Name = "CVT", Id = 4 },
                new TransmissionType { Name = "Semi-Automatic", Id = 5 }
            };

            return transmissionTypes;
        }
    }
}