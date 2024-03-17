using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Models;
using CarRepairShop.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.Controllers
{
    public class ReservationController : BaseController
    {
        private readonly IReservationService reservationService;
        public ReservationController(IReservationService _reservationService)
        {
            reservationService = _reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var reservationModel = new ReservationFormViewModel();
            reservationModel.UserCars = await reservationService.GetUserCars(User.Id());
            reservationModel.ServiceTypes = await reservationService.GetServiceTypes();
            return View(reservationModel);
        }
    }
}
