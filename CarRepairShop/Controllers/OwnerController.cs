using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.Controllers
{
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
    }
}
