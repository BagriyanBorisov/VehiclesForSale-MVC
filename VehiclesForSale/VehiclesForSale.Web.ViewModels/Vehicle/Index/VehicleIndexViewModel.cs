namespace VehiclesForSale.Web.ViewModels.Vehicle.Index
{
    public class VehicleIndexViewModel
    {
        public VehicleIndexViewModel()
        {

        }
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string Price { get; set; } = null!;

        public int CubicCapacity { get; set; }

        public string Year { get; set; } = null!;
        public string Month { get; set; } = null!;

        public long Mileage { get; set; }

        public int HorsePower { get; set; }

        public string? Location { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;


        public string Transmission { get; set; } = null!;

        public string FuelType { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string CategoryType { get; set; } = null!;

        public string? MainImage { get; set; }

        public bool? IsInWatchList { get; set; }


    }
}
