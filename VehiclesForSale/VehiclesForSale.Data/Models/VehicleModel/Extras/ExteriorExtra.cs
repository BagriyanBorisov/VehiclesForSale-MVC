using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static VehiclesForSale.Common.Validations.EntityValidationConstants.ExtrasValidations;


namespace VehiclesForSale.Data.Models.VehicleModel.Extras
{
    public class ExteriorExtra
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
    }
}
