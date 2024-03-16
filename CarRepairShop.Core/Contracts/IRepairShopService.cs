using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepairShop.Core.Models;

namespace CarRepairShop.Core.Contracts
{
    public interface IRepairShopService
    {
        Task<IEnumerable<RepairShopViewModel>> AllRepairShopsAsync();
    }
}
