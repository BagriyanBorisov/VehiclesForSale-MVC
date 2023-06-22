using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VehiclesForSale.Common.Validations.EntityValidationConstants.TypesValidations;

namespace VehiclesForSale.Data.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int VehicleId {get; set; }

        [ForeignKey(nameof(VehicleId))] 
        public Vehicle Vehicle { get; set; } = null!;
    }
}
