using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VehiclesForSale.Web.Models;

namespace VehiclesForSale.Web.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return RedirectToAction("Search", "Vehicle");
        }

        public IActionResult Chat()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}