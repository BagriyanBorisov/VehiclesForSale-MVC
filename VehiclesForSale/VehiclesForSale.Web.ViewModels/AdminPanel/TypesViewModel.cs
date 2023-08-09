using VehiclesForSale.Web.ViewModels.Vehicle;

namespace VehiclesForSale.Web.ViewModels.AdminPanel
{
    public class TypesViewModel
    {
        public TypesViewModel()
        {
            this.TransmissionTypes = new HashSet<TransmissionTypeFormVehicleViewModel>();
            this.Colors = new HashSet<ColorFormVehicleViewModel>();
            this.FuelTypes = new HashSet<FuelTypeFormVehicleViewModel>();
            this.Categories = new HashSet<CategoryFormVehicleViewModel>();
            this.Years = new HashSet<int>();
        }

        public string? TransmissionNew { get; set; }
        public string? CategoryNew { get; set; }
        public int? YearNew { get; set; }
        public string? FuelNew { get; set; }
        public string? ColorNew { get; set; }

        public int TransmissionTypeId { get; set; }

        public int FuelTypeId { get; set; }

        public int ColorId { get; set; }

        public int CategoryTypeId { get; set; }

        public IEnumerable<int> Years { get; set; }
        public IEnumerable<TransmissionTypeFormVehicleViewModel> TransmissionTypes { get; set; }
        public IEnumerable<FuelTypeFormVehicleViewModel> FuelTypes { get; set; }
        public IEnumerable<ColorFormVehicleViewModel> Colors { get; set; }
        public IEnumerable<CategoryFormVehicleViewModel> Categories { get; set; }
    }
}
