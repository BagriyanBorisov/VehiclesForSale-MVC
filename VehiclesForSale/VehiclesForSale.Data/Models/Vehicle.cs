using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VehiclesForSale.Common.Validations.EntityValidationConstants.VehicleValidations;


namespace VehiclesForSale.Data.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            this.Images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }

        [Required] 
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public decimal Price {get; set; }

        [Required]
        public int CubicCapacity { get; set; }

        [Required]
        public DateTime Year {get; set; }

        [Required]
        public long Mileage { get; set; }

        [Required]
        public int HorsePower { get; set; }


        //Relations
        [Required]
        public int MakeId { get; set; }

        [ForeignKey(nameof(MakeId))]
        public Make Make { get; set; } = null!;


        [Required]
        public int ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public Model Model { get; set; } = null!;


        [Required]
        public int TransmissionTypeId { get; set; }

        [ForeignKey(nameof(TransmissionTypeId))]
        public TransmissionType TransmissionType { get; set; } = null!;


        [Required]
        public int FuelTypeId { get; set; }

        [ForeignKey(nameof(FuelTypeId))]
        public FuelType FuelType { get; set; } = null!;


        [Required]
        public int ColorId { get; set; }

        [ForeignKey(nameof(ColorId))]
        public Color Color { get; set; } = null!;


        [Required]
        public int CategoryTypeId { get; set; }

        [ForeignKey(nameof(CategoryTypeId))]
        public CategoryType CategoryType { get; set; } = null!;

        public ICollection<Image> Images { get; set; }

    }
}
