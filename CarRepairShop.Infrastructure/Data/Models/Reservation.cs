namespace CarRepairShop.Infrastructure.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime ReservationDateTime { get; set; }

        public int RepairShopId { get; set; }
        public RepairShop RepairShop { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
