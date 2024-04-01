using System.Globalization;
using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Extensions;
using CarRepairShop.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.Controllers
{
    [Authorize(Roles ="Admin, Customer")]
    public class ReservationController : BaseController
    {
        private readonly IReservationService reservationService;
        public ReservationController(IReservationService _reservationService)
        {
            reservationService = _reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            var reservationModel = new ReservationWithIdFormViewModel();
            reservationModel.UserCars = await reservationService.GetUserCars(User.Id());
            reservationModel.ServiceTypes = await reservationService.GetServiceTypes();
            reservationModel.Id = id;

            return View(reservationModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReservationWithIdFormViewModel reservationModel)
        {
            DateTime reservationDateAndTime;

            if (!DateTime.TryParseExact(
              reservationModel.ReservationDateTime,
              DataConstants.DateFormat,
              CultureInfo.InvariantCulture,
              DateTimeStyles.None,
              out reservationDateAndTime))
            {
                ModelState.AddModelError(nameof(reservationModel.ReservationDateTime), $"Invalid Date! Format must be: {DataConstants.DateFormat}");
            }

            if (!await reservationService.IsDateAndTimeAvailable(reservationDateAndTime))
            {
                ModelState.AddModelError(nameof(reservationModel.ReservationDateTime), $"Sorry! We are not available at this hour. Select a different date and time!");
            }

            if (!ModelState.IsValid)
            {
                reservationModel.UserCars = await reservationService.GetUserCars(User.Id());
                reservationModel.ServiceTypes = await reservationService.GetServiceTypes();
                return View(reservationModel);
            }

            await reservationService.AddAsync(reservationModel, reservationDateAndTime);

            return RedirectToAction("All", "RepairShop");
        }

        public async Task<IActionResult> AllCarReservations(int id)
        {
            if (!await reservationService.CarExists(id))
            {
                return BadRequest();
            }
            var reservations = await reservationService.GetAllCarReservations(id);

            return View(reservations);
        }

        public async Task<IActionResult> Cancel(int id)
        {
            var reservation = await reservationService.FindReservationById(id);

            if(reservation == null)
            {
                return BadRequest();
            }

            return View(reservation);
        }
    }
}
