namespace VehiclesForSale.Web.ViewModels.Vehicle.Index
{
    public class VehicleCollectionViewModel
    {
        public VehicleCollectionViewModel()
        {
            this.Vehicles = new List<VehicleIndexViewModel>();
            this.Makes = new HashSet<MakeFormVehicleViewModel>();
            this.Models = new HashSet<ModelFormVehicleViewModel>();
        }
        public int? MakeSelectedId { get; set; }
        public int? ModelSelectedId { get; set; }


        public IEnumerable<MakeFormVehicleViewModel> Makes { get; set; }
        public IEnumerable<ModelFormVehicleViewModel> Models { get; set; }
        public ICollection<VehicleIndexViewModel> Vehicles { get; set; }
    }
}
