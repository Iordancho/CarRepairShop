namespace CarRepairShop.Infrastructure.Data.Models
{
    public class ReservationStatus
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IList<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
