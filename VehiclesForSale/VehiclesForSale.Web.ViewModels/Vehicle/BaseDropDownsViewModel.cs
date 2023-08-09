namespace VehiclesForSale.Web.ViewModels.Vehicle
{
    using System.ComponentModel.DataAnnotations;

    public class BaseDropDownsViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int Id { get; set; }
    }
}
