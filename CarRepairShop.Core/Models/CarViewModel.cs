using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShop.Core.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public string  Make { get; set; } = string.Empty;
        public string ProductionDate { get; set; } = string.Empty;
        public string VIN { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
    }
}
