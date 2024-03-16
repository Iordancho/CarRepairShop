using CarRepairShop.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.Controllers
{
    public class RepairShopController : BaseController
    {
        private readonly IRepairShopService repairshopService;
        public RepairShopController(IRepairShopService _repairshopService)
        {
            repairshopService = _repairshopService;
        }

        public async Task<IActionResult> All()
        {
            var shops = await repairshopService.AllRepairShopsAsync();
            return View(shops);
        }
    }
}
