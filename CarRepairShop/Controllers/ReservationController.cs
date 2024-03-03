using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
