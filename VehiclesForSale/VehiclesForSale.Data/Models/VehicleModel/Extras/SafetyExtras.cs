using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VehiclesForSale.Common.Validations.EntityValidationConstants.ExtrasValidations;

namespace VehiclesForSale.Data.Models.VehicleModel.Extras
{
    public class SafetyExtra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int ExtraId { get; set; }

        [ForeignKey(nameof(ExtraId))]
        public Extra Extra { get; set; } = null!;

        //public bool GpsSystemForTracking { get; set; }

        //public bool AdaptiveFrontLights { get; set; }

        //public bool ElectronicStabilityControl { get; set; }

        //public bool AntilockBrakingSystem { get; set; }

        //public bool RearAirbags { get; set; }

        //public bool FrontAirbags { get; set; }

        //public bool SideAirbags { get; set; }

        //public bool ElectronicBrakeforceDistribution { get; set; }

        //public bool ElectronicStabilityProgram { get; set; }

        //public bool TirePressureMonitoringSystem { get; set; }

        //public bool ParkingSensorSystem { get; set; }

        //public bool IsofixSystem { get; set; }

        //public bool Distronic { get; set; }

        //public bool BrakeDryingSystem { get; set; }

        //public bool BrakeAssist { get; set; }

        //public bool HillDescentControl { get; set; }

    }
}