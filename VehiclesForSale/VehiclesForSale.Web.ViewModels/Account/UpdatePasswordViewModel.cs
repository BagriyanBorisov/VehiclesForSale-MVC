using System.ComponentModel.DataAnnotations;

namespace VehiclesForSale.Web.ViewModels.Account
{
    using static Common.Validations.EntityValidationConstants.UserValidations;
    public class UpdatePasswordViewModel
    {
        [Required]
        [StringLength(UserPassMaxLength, MinimumLength = UserPassMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;


        [Required]
        [StringLength(UserPassMaxLength, MinimumLength = UserPassMinLength)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; } = null!;
    }
}
