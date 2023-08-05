namespace VehiclesForSale.Web.ViewModels.Vehicle.Details
{
    public class DetailsVehicleViewModel
    {
        public DetailsVehicleViewModel()
        {
            this.Images = new List<string>();
            this.ComfortExtras = new List<string>();
            this.ExteriorExtras = new List<string>();
            this.InteriorExtras = new List<string>();
            this.OtherExtras = new List<string>();
            this.SafetyExtras = new List<string>();
        }

        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string OwnerId { get; set; } = null!;

        public string Price { get; set; } = null!;

        public string CubicCapacity { get; set; } = null!;

        public string Year { get; set; } = null!;
        public string Month { get; set; } = null!;

        public string Mileage { get; set; } = null!;

        public string HorsePower { get; set; } = null!;

        public string? Location { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;


        public string Transmission { get; set; } = null!;

        public string FuelType { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string CategoryType { get; set; } = null!;

        public string? MainImage { get; set; }
        public string? Description { get; set; }

        public bool? IsInWatchList { get; set; }

        public IEnumerable<string> Images { get; set; }
        public ICollection<string> ComfortExtras { get; set; }
        public ICollection<string> SafetyExtras { get; set; }
        public ICollection<string> InteriorExtras { get; set; }
        public ICollection<string> ExteriorExtras { get; set; }
        public ICollection<string> OtherExtras { get; set; }

    }
}
