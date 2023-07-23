namespace VehiclesForSale.Web.ViewModels.Vehicle
{
    using System.ComponentModel.DataAnnotations;

    using static Common.Validations.EntityValidationConstants.VehicleValidations;
    public class VehicleFormViewModel
    {
        public VehicleFormViewModel()
        {
            this.Makes = new HashSet<MakeFormVehicleViewModel>();
            this.Models = new HashSet<ModelFormVehicleViewModel>();
            this.TransmissionTypes = new HashSet<TransmissionTypeFormVehicleViewModel>();
            this.Colors = new HashSet<ColorFormVehicleViewModel>();
            this.FuelTypes = new HashSet<FuelTypeFormVehicleViewModel>();
            this.Categories = new HashSet<CategoryFormVehicleViewModel>();
        }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMin, PriceMax)]
        public string Price { get; set; } = null!;

        [Required]
        [Range(typeof(int), CubicCapacityMin,CubicCapacityMax)]
        public int CubicCapacity { get; set; }

        [Required]
        [Display(Name = "Date of First Registration:"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; }

        [Required]
        [Range(typeof(long), MileageMin, MileageMax)]
        public long Mileage { get; set; }

        [Required]
        [Range(typeof(int), HorsePowerMin, HorsePowerMax)]
        public int HorsePower { get; set; }

        public string? Location { get; set; }

        [Required]
        public int MakeId { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        public int TransmissionTypeId { get; set; }

        [Required]
        public int FuelTypeId { get; set; }

        [Required]
        public int ColorId { get; set; }

        [Required]
        public int CategoryTypeId { get; set; }

        public ICollection<MakeFormVehicleViewModel> Makes { get; set; }
        public ICollection<ModelFormVehicleViewModel> Models {get; set; }
        public ICollection<TransmissionTypeFormVehicleViewModel> TransmissionTypes {get; set; } 
        public ICollection<FuelTypeFormVehicleViewModel> FuelTypes {get; set; }
        public ICollection<ColorFormVehicleViewModel> Colors {get; set; }
        public ICollection<CategoryFormVehicleViewModel> Categories {get; set; } 



    }
}
