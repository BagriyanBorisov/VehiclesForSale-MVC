using System.ComponentModel.DataAnnotations;
using static VehiclesForSale.Common.Validations.EntityValidationConstants.TypesValidations;
namespace VehiclesForSale.Data.Models.VehicleModel
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ColorMaxLength)]
        public string Name { get; set; } = null!;

    }
}
