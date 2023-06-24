using System.ComponentModel.DataAnnotations;

namespace VehiclesForSale.Data.Models.VehicleModel.Extras
{
    public class Extra
    {
        public Extra()
        {
            SafetyExtras = new HashSet<SafetyExtra>();
            ComfortExtras = new HashSet<ComfortExtra>();
            ExteriorExtras = new HashSet<ExteriorExtra>();
            InteriorExtras = new HashSet<InteriorExtra>();
            OtherExtras = new HashSet<OtherExtra>();
        }

        [Key]
        public int Id { get; set; }

        public ICollection<SafetyExtra> SafetyExtras { get; set; }
        public ICollection<ComfortExtra> ComfortExtras { get; set; }
        public ICollection<ExteriorExtra> ExteriorExtras { get; set; }
        public ICollection<InteriorExtra> InteriorExtras { get; set; }
        public ICollection<OtherExtra> OtherExtras { get; set; }

    }
}
