using System.ComponentModel.DataAnnotations;
using static VehiclesForSale.Common.Validations.EntityValidationConstants.TypesValidations;

namespace VehiclesForSale.Data.Models.VehicleModel
{
    public class CategoryType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryMaxLength)]
        public string Name { get; set; } = null!;
    }
}
