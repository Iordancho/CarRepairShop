using CarRepairShop.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.Controllers
{
    [Authorize(Roles ="Owner")]
    public class OwnerController : BaseController
    {
        private readonly IOwnerService ownerService;
        public OwnerController(IOwnerService _ownerService)
        {
            ownerService = _ownerService;
        }
        public async Task<IActionResult> AllRepairShopReservations(int id)
        {
            if (!await ownerService.RepairShopExists(id))
            {
                return BadRequest();
            }
            var reservations = await ownerService.AllRepairShopReservations(id);
            return View(reservations);

        }
        public async Task<IActionResult> FinishService(int id)
        {
            var reservation = await ownerService.FindReservationById(id);
            if (reservation == null)
            {
                return BadRequest();
            }
            
            await ownerService.FinishService(id);
            return RedirectToAction("All", "RepairShop");
        }
    }
}
