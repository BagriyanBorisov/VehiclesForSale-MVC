namespace VehiclesForSale.Web.ViewModels.Vehicle.Search
{
    using System.ComponentModel.DataAnnotations;
    using Index;
    using Common;
   
    public class VehicleSearchViewModel
    {
        public VehicleSearchViewModel()
        {
            this.Makes = new HashSet<MakeFormVehicleViewModel>();
            this.Models = new HashSet<ModelFormVehicleViewModel>();
            this.TransmissionTypes = new HashSet<TransmissionTypeFormVehicleViewModel>();
            this.Colors = new HashSet<ColorFormVehicleViewModel>();
            this.FuelTypes = new HashSet<FuelTypeFormVehicleViewModel>();
            this.Categories = new HashSet<CategoryFormVehicleViewModel>();
            this.Years = new HashSet<int>();
            this.Vehicles = new HashSet<VehicleIndexViewModel>();
        }

        [PriceToLessThanOrEqual(nameof(PriceFrom),
            ErrorMessage = "Price To must be greater than or equal to Price From")]
        public int? PriceTo { get; set; }
        public int? PriceFrom { get; set; }

        public int? HorsePowerTo { get; set; }

        public long? MileageTo { get; set; }

        public int? CubicCapacityTo { get; set; }

        [Required]
        public int MakeId { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        public int TransmissionTypeId { get; set; }

        [Required]
        public int FuelTypeId { get; set; }

        [Required]
        public int ColorId { get; set; }

        [Required]
        public int CategoryTypeId { get; set; }

        [YearToLessThanOrEqual("SelectedYearFrom", ErrorMessage = "Selected Year To must be greater than or equal to Selected Year From")]
        public int? SelectedYearTo { get; set; }
        public int? SelectedYearFrom { get; set; }
        public IEnumerable<int> Years { get; set; }

        public IEnumerable<MakeFormVehicleViewModel> Makes { get; set; }
        public IEnumerable<ModelFormVehicleViewModel> Models { get; set; }
        public IEnumerable<TransmissionTypeFormVehicleViewModel> TransmissionTypes { get; set; }
        public IEnumerable<FuelTypeFormVehicleViewModel> FuelTypes { get; set; }
        public IEnumerable<ColorFormVehicleViewModel> Colors { get; set; }
        public IEnumerable<CategoryFormVehicleViewModel> Categories { get; set; }

        public ICollection<VehicleIndexViewModel> Vehicles { get; set; }
    }
}
