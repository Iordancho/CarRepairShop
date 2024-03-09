using CarRepairShop.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using CarRepairShop.Core.Models;

namespace CarRepairShop.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;
        public CarController(ICarService _carService)
        {
            carService = _carService;
        }

        [HttpGet]
        public async Task<IActionResult> AddCar()
        {
            var model = new CarFormViewModel();
            model.Makes = await carService.GetMakes();
            return View(model);
        }
    }
}
