using CarRepairShop.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data;
using System.Globalization;
using CarRepairShop.Infrastructure.Data.Models;
using CarRepairShop.Extensions;

namespace CarRepairShop.Controllers
{
    public class CarController : BaseController
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

        [HttpPost]
        public async Task<IActionResult> AddCar(CarFormViewModel car)
        {
            DateTime productionDate;

            if (!DateTime.TryParseExact(
              car.ProductionDate,
              DataConstants.DateFormat,
              CultureInfo.InvariantCulture,
              DateTimeStyles.None,
              out productionDate))
            {
                ModelState.AddModelError(nameof(car.ProductionDate), $"Invalid Date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                car.Makes = await carService.GetMakes();
                return View(car);
            }

            var userId = User.Id();

            await carService.AddAsync(car, productionDate, userId);

            return RedirectToAction("Index", "Home");
        }
    }
}
