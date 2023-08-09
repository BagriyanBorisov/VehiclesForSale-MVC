namespace VehiclesForSale.Web.ViewModels.AdminPanel
{
    using VehiclesForSale.Web.ViewModels.Vehicle;

    public class MakesAndModelsViewModel
    {
        public MakesAndModelsViewModel()
        {
            Models = new HashSet<ModelFormVehicleViewModel>();
            Makes = new HashSet<MakeFormVehicleViewModel>();
        }

        public string? MakeNew { get; set; }
        public string? ModelNew { get; set; }

        public int? MakeId { get; set; }

        public int ModelId { get; set; }

        public IEnumerable<MakeFormVehicleViewModel> Makes { get; set; }
        public IEnumerable<ModelFormVehicleViewModel> Models { get; set; }
    }
}
