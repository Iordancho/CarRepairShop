using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShop.Core.Models
{
    public class AllCarsSearchViewModel
    {
        [Display(Name ="Seach by text")]
        public string SearchTerm { get; set; } = null!;
        public IEnumerable<CarViewModel> Cars { get; set; } = new List<CarViewModel>();
    }
}
