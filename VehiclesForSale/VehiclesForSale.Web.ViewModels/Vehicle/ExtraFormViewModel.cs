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

            this.ComfortExtrasChecked = new List<string>();
            this.SafetyExtrasChecked = new List<string>();
            this.InteriorExtrasChecked = new List<string>();
            this.ExteriorExtrasChecked = new List<string>();
            this.OtherExtrasChecked = new List<string>();
        }

        public int ExtraId { get; set; }
        public IEnumerable<InteriorExtraFormViewModel> InteriorExtras { get; set; }
        public IEnumerable<ExteriorExtraFormViewModel> ExteriorExtras { get; set; }
        public IEnumerable<SafetyExtraFormViewModel> SafetyExtras { get; set; }
        public IEnumerable<ComfortExtraFormViewModel> ComfortExtras { get; set; }
        public IEnumerable<OtherExtraFormViewModel> OtherExtras { get; set; }

        public ICollection<string> InteriorExtrasChecked { get; set; }
        public ICollection<string> ExteriorExtrasChecked { get; set; }
        public ICollection<string> SafetyExtrasChecked { get; set; }
        public ICollection<string> ComfortExtrasChecked { get; set; }
        public ICollection<string> OtherExtrasChecked { get; set; }
    }
}
