using CarRepairShop.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using CarRepairShop.Core.Models;
using CarRepairShop.Infrastructure.Data;
using System.Globalization;
using CarRepairShop.Infrastructure.Data.Models;
using CarRepairShop.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace CarRepairShop.Controllers
{
    [Authorize(Roles ="Admin, Customer")]
    public class CarController : BaseController
    {
        private readonly ICarService carService;
        public CarController(ICarService _carService)
        {
            carService = _carService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CarFormViewModel();
            model.Makes = await carService.GetMakes();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarFormViewModel car)
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

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All(AllCarsSearchViewModel query)
        {
            var userId = User.Id();
            var model = await carService.AllCarsAsync(userId, query.SearchTerm);

            query.Cars = model;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            
            var car = await carService.FindCarById(id);


            if(car == null)
            {
                return BadRequest();
            }
            if(car.OwnerId != User.Id())
            {
                return Unauthorized();
            }
            
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await carService.FindCarById(id);

            if (car == null)
            {
                return BadRequest();
            }
            if (car.OwnerId != User.Id())
            {
                return Unauthorized();
            }

            await carService.RemoveCarReservationsAsync(id);
            await carService.RemoveCarAsync(id);
            return RedirectToAction("All");
        }
    }
}
