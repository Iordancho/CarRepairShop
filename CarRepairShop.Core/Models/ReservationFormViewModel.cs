using CarRepairShop.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CarRepairShop.Infrastructure.Data.DataConstants;

namespace CarRepairShop.Core.Models
{
    public class ReservationFormViewModel
    {

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(ReservationDescriptionMax, MinimumLength = ReservationDescriptionMin, ErrorMessage = StringLenghtErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int StatusId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string ReservationDateTime { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int RepairShopId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int CarId { get; set; }
        public IEnumerable<CarReservationViewModel> UserCars { get; set; } = new List<CarReservationViewModel>();

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int ServiceTypeId { get; set; }
        public IEnumerable<ServiceTypeReservationViewModel> ServiceTypes { get; set; } = new List<ServiceTypeReservationViewModel>();
    }
}
