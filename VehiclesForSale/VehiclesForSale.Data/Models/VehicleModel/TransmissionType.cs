using System.ComponentModel.DataAnnotations;
using static VehiclesForSale.Common.Validations.EntityValidationConstants.TypesValidations;

namespace VehiclesForSale.Data.Models.VehicleModel
{
    public class TransmissionType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TransmissionMaxLength)]
        public string Name { get; set; } = null!;


    }
}
