using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(StatusId))]
        public ReservationStatus Status { get; set; } = null!;

        [Required]
        public DateTime ReservationDateTime { get; set; }

        [Required]
        public int RepairShopId { get; set; }
        [Required]
        [ForeignKey(nameof(RepairShopId))]
        public RepairShop RepairShop { get; set; } = null!;

        [Required]
        public int CarId { get; set; }
        [Required]
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        [Required]
        public int ServiceTypeId { get; set; }
        [Required]
        [ForeignKey(nameof(ServiceTypeId))]
        public ServiceType ServiceType { get; set; } = null!;
    }
}
