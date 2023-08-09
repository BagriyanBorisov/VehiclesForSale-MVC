using VehiclesForSale.Web.ViewModels.Vehicle;

namespace VehiclesForSale.Web.ViewModels.AdminPanel
{
    public class ExtrasCrudViewModel
    {
        public ExtrasCrudViewModel()
        {
            this.SafetyExtras = new HashSet<SafetyExtraFormViewModel>();
            this.ComfortExtras = new HashSet<ComfortExtraFormViewModel>();
            this.ExteriorExtras = new HashSet<ExteriorExtraFormViewModel>();
            this.InteriorExtras = new HashSet<InteriorExtraFormViewModel>();
            this.OtherExtras = new HashSet<OtherExtraFormViewModel>();
        }

        public string? ComfortNew { get; set; }
        public string? SafetyNew { get; set; }
        public string? ExteriorNew { get; set; }
        public string? InteriorNew { get; set; }
        public string? OtherNew { get; set; }

        public IEnumerable<InteriorExtraFormViewModel> InteriorExtras { get; set; }
        public IEnumerable<ExteriorExtraFormViewModel> ExteriorExtras { get; set; }
        public IEnumerable<SafetyExtraFormViewModel> SafetyExtras { get; set; }
        public IEnumerable<ComfortExtraFormViewModel> ComfortExtras { get; set; }
        public IEnumerable<OtherExtraFormViewModel> OtherExtras { get; set; }
    }
}
