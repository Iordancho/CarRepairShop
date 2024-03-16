using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.Controllers
{
    public class ReservationController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
