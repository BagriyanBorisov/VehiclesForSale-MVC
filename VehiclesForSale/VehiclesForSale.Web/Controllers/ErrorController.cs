using Microsoft.AspNetCore.Mvc;

namespace VehiclesForSale.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
