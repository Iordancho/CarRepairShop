using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CarRepairShop.Infrastructure.Data.DataConstants;


namespace CarRepairShop.Core.Models
{
    public class CarFormViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(CarModelMax, MinimumLength = CarModelMin, ErrorMessage = StringLenghtErrorMessage)]
        public string Model { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string ProductionYear { get; set; } = string.Empty;

        [Required]
        [StringLength(VINMax, ErrorMessage = VINLengthErrorMessage)]
        public string VIN { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int MakeId { get; set; }
        public IEnumerable<MakeViewModel> Makes { get; set; } = new List<MakeViewModel>();
    }
}
