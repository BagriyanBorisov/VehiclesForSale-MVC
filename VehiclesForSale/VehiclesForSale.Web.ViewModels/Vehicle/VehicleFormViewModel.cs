namespace VehiclesForSale.Web.ViewModels.Vehicle
{
    using System.ComponentModel.DataAnnotations;

    using static Common.Validations.EntityValidationConstants.VehicleValidations;
    public class VehicleFormViewModel
    {
        public VehicleFormViewModel()
        {
            this.Id = Guid.NewGuid();
            this.Makes = new HashSet<MakeFormVehicleViewModel>();
            this.Models = new HashSet<ModelFormVehicleViewModel>();
            this.TransmissionTypes = new HashSet<TransmissionTypeFormVehicleViewModel>();
            this.Colors = new HashSet<ColorFormVehicleViewModel>();
            this.FuelTypes = new HashSet<FuelTypeFormVehicleViewModel>();
            this.Categories = new HashSet<CategoryFormVehicleViewModel>();
            this.SafetyExtras = new HashSet<SafetyExtraFormViewModel>();
            this.ComfortExtras = new HashSet<ComfortExtraFormViewModel>();
            this.ExteriorExtras = new HashSet<ExteriorExtraFormViewModel>();
            this.InteriorExtras = new HashSet<InteriorExtraFormViewModel>();
            this.OtherExtras = new HashSet<OtherExtraFormViewModel>();
            this.Months = new HashSet<string>();
            this.Years = new HashSet<int>();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMin, PriceMax)]
        public string Price { get; set; } = null!;

        [Required]
        [Range(typeof(int), CubicCapacityMin, CubicCapacityMax)]
        public int CubicCapacity { get; set; }


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


        public int SelectedYear { get; set; }

        [Required]
        public string SelectedMonth { get; set; } = null!;

        public string? Description { get; set; }

        public IEnumerable<int> Years { get; set; }
        public IEnumerable<string> Months { get; set; }
        public IEnumerable<MakeFormVehicleViewModel> Makes { get; set; }
        public IEnumerable<ModelFormVehicleViewModel> Models { get; set; }
        public IEnumerable<TransmissionTypeFormVehicleViewModel> TransmissionTypes { get; set; }
        public IEnumerable<FuelTypeFormVehicleViewModel> FuelTypes { get; set; }
        public IEnumerable<ColorFormVehicleViewModel> Colors { get; set; }
        public IEnumerable<CategoryFormVehicleViewModel> Categories { get; set; }

        public IEnumerable<InteriorExtraFormViewModel> InteriorExtras { get; set; }
        public IEnumerable<ExteriorExtraFormViewModel> ExteriorExtras { get; set; }
        public IEnumerable<SafetyExtraFormViewModel> SafetyExtras { get; set; }
        public IEnumerable<ComfortExtraFormViewModel> ComfortExtras { get; set; }
        public IEnumerable<OtherExtraFormViewModel> OtherExtras { get; set; }
    }
}
