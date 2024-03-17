using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShop.Core.Models
{
    public class RepairShopViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = null!;
    }
}
