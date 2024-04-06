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
        public string ProductionDate { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(VINMax, MinimumLength =VINMax, ErrorMessage = VINLengthErrorMessage)]
        public string VIN { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int MakeId { get; set; }
        public IEnumerable<MakeFormViewModel> Makes { get; set; } = new List<MakeFormViewModel>();
    }
}
