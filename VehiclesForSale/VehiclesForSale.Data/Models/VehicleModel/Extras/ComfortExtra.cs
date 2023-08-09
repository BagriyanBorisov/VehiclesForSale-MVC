using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VehiclesForSale.Common.Validations.EntityValidationConstants.ExtrasValidations;

namespace VehiclesForSale.Data.Models.VehicleModel.Extras
{
    public class ComfortExtra
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Extra))]
        public int? ExtraId { get; set; }

        public Extra? Extra { get; set; }

    }
}
