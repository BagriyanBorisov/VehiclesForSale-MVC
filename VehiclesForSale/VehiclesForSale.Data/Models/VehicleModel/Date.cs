namespace VehiclesForSale.Data.Models.VehicleModel
{
    using Enums;

    public class Date
    {
        public Date()
        {
            this.Vehicles = new List<Vehicle>();
        }

        public int Id { get; set; }
        public int Year { get; set; }
        public Month Month { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
