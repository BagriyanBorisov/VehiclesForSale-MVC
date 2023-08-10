namespace VehiclesForSale.Web.ViewModels.Vehicle.Search
{
    using VehiclesForSale.Web.ViewModels.Vehicle.Index;

    public class FilteredViewModel
    {
        public FilteredViewModel()
        {
            this.Vehicles = new List<VehicleIndexViewModel>();
        }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? TransmissionType { get; set; }
        public string? SelectedYearTo { get; set; }
        public string? SelectedYearFrom { get; set; }
        public string? PriceTo { get; set; }
        public string? PriceFrom { get; set; }
        public string? CategoryTypeId { get; set; }
        public string? ColorId { get; set; }
        public string? MileageTo { get; set; }
        public string? CubicCapacityTo { get; set; }
        public string? HorsePowerTo { get; set; }
        public string? FuelTypeId { get; set; }
        public ICollection<VehicleIndexViewModel> Vehicles { get; set; }
    }
}
