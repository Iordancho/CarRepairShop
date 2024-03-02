using System.ComponentModel.DataAnnotations;

namespace CarRepairShop.Infrastructure.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int StatusId { get; set; }
        [Required]
        public ReservationStatus Status { get; set; } = null!;

        [Required]
        public DateTime ReservationDateTime { get; set; }

        public int RepairShopId { get; set; }
        public RepairShop RepairShop { get; set; } = null!;

        public int CarId { get; set; }
        public Car Car { get; set; } = null!;

        [Required]
        public int ServiceTypeId { get; set; }
        [Required]
        public ServiceType ServiceType { get; set; } = null!;
    }
}
