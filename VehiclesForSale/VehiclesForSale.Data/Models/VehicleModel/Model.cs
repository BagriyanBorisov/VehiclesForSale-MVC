using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static VehiclesForSale.Common.Validations.EntityValidationConstants.ModelValidations;

namespace VehiclesForSale.Data.Models.VehicleModel
{
    public class Model
    {
        public Model()
        {
            this.VehiclesFromModel = new HashSet<Vehicle>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int MakeId { get; set; }

        [ForeignKey(nameof(MakeId))]
        public Make Make { get; set; } = null!;

        public ICollection<Vehicle> VehiclesFromModel { get; set; }
    }
}
