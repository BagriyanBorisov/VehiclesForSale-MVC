namespace VehiclesForSale.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
