namespace VehiclesForSale.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using static Common.Validations.EntityValidationConstants.UserValidations;

    public class UpdateInformationViewModel
    {

            [Required]
            [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
            public string UserName { get; set; } = null!;

            [Required]
            [StringLength(UserPassMaxLength, MinimumLength = UserPassMinLength)]
            [DataType(DataType.Password)]
            public string Password { get; set; } = null!;


            [Required]
            [EmailAddress]
            [StringLength(UserEmailMaxLength, MinimumLength = UserEmailMinLength)]
            public string Email { get; set; } = null!;

            [Required]
            [Phone]
            public string PhoneNumber { get; set; } = null!;

        

    }

}

