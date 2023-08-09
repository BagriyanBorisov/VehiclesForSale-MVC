namespace VehiclesForSale.Data.Models.VehicleModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.Validations.EntityValidationConstants.ModelValidations;

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
