using System.ComponentModel.DataAnnotations;
using static VehiclesForSale.Common.Validations.EntityValidationConstants.TypesValidations;

namespace VehiclesForSale.Data.Models.VehicleModel
{
    public class FuelType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FuelMaxLength)]
        public string Name { get; set; } = null!;

    }
}
