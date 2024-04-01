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

            foreach (var shop in shops)
            {
                string input = shop.Address;
                string delimiter = ", ";

                int index = input.IndexOf(delimiter);

                if (index != -1 && index < input.Length - delimiter.Length)
                {
                    string result = input.Substring(index + delimiter.Length);
                    shop.City = result;
                }
            }
            return View(shops);
        }
    }
}
