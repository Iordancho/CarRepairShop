using System.ComponentModel.DataAnnotations;
using static CarRepairShop.Infrastructure.Data.DataConstants;

namespace CarRepairShop.Infrastructure.Data.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ReservationDescriptionMax)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int StatusId { get; set; }
        [Required]
        public ReservationStatus Status { get; set; } = null!;

        [Required]
        public DateTime ReservationDateTime { get; set; }

        [Required]
        public int RepairShopId { get; set; }
        [Required]
        public RepairShop RepairShop { get; set; } = null!;

        [Required]
        public int CarId { get; set; }
        [Required]
        public Car Car { get; set; } = null!;

        [Required]
        public int ServiceTypeId { get; set; }
        [Required]
        public ServiceType ServiceType { get; set; } = null!;
    }
}
