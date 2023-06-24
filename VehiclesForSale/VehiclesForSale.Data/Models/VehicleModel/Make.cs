namespace VehiclesForSale.Data.Models.VehicleModel
{
    using System.ComponentModel.DataAnnotations;
    using static Common.Validations.EntityValidationConstants.MakeValidations;
    public class Make
    {
        public Make()
        {
            Models = new HashSet<Model>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Model> Models { get; set; }
    }
}
