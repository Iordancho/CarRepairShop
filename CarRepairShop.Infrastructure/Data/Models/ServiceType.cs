namespace CarRepairShop.Infrastructure.Data.Models
{
    public class ServiceType
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
