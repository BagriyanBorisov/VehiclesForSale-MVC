using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehiclesForSale.Data.Models.VehicleModel.Extras;
using static VehiclesForSale.Common.Validations.EntityValidationConstants.VehicleValidations;


namespace VehiclesForSale.Data.Models.VehicleModel
{
    public class Vehicle
    {
        public Vehicle()
        {
            ImageCollection = new HashSet<Image>();
            FavoriteVehicleApplicationUsers = new HashSet<FavoriteVehicleApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CubicCapacity { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public long Mileage { get; set; }

        [Required]
        public int HorsePower { get; set; }

        public string? Location { get; set; }


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

        [Required]
        public int ExtraId { get; set; }

        [ForeignKey(nameof(ExtraId))]
        public Extra Extra { get; set; } = null!;

        [Required]
        public string OwnerId { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public ApplicationUser Owner { get; set; } = null!;

        public ICollection<FavoriteVehicleApplicationUser> FavoriteVehicleApplicationUsers { get; set; }

        public ICollection<Image> ImageCollection { get; set; }

    }
}
