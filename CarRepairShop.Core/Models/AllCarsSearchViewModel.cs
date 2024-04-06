using System.ComponentModel.DataAnnotations;

namespace CarRepairShop.Core.Models
{
    public class AllCarsSearchViewModel
    {
        [Display(Name ="Search by text")]
        public string SearchTerm { get; set; } = null!;
        public IEnumerable<CarViewModel> Cars { get; set; } = new List<CarViewModel>();
    }
}
