﻿namespace VehiclesForSale.Web.ViewModels.Vehicle.Index
{
    using System.ComponentModel.DataAnnotations;

    public class VehicleIndexViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public string Price { get; set; } = null!;

        public int CubicCapacity { get; set; }

        [Display(Name = "Date of First Registration:"),
         DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public string Year { get; set; } = null!;

        public long Mileage { get; set; }

        public int HorsePower { get; set; }

        public string? Location { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        
        public string Transmission { get; set; } = null!;

        public string FuelType { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string CategoryType { get; set; } = null!;

        public string? MainImage { get; set; }
    }
}