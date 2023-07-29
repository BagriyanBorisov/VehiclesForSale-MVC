namespace VehiclesForSale.Web.ViewModels.Vehicle
{
    public class ExtraFormViewModel
    {
        public ExtraFormViewModel()
        {
            this.SafetyExtras = new HashSet<SafetyExtraFormViewModel>();
            this.ComfortExtras = new HashSet<ComfortExtraFormViewModel>();
            this.ExteriorExtras = new HashSet<ExteriorExtraFormViewModel>();
            this.InteriorExtras = new HashSet<InteriorExtraFormViewModel>();
            this.OtherExtras = new HashSet<OtherExtraFormViewModel>();
        }

        public IEnumerable<InteriorExtraFormViewModel> InteriorExtras { get; set; }
        public IEnumerable<ExteriorExtraFormViewModel> ExteriorExtras { get; set; }
        public IEnumerable<SafetyExtraFormViewModel> SafetyExtras { get; set; }
        public IEnumerable<ComfortExtraFormViewModel> ComfortExtras { get; set; }
        public IEnumerable<OtherExtraFormViewModel> OtherExtras { get; set; }
    }
}
