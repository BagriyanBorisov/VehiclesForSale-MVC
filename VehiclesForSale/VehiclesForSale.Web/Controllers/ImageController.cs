﻿namespace VehiclesForSale.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Vehicle;

    public class ImageController : Controller
    {
        public IActionResult Add(string id)
        {
            ImageFormViewModel imageForm = new ImageFormViewModel()
            {
                
            };

            return View(imageForm);
        }
    }
}