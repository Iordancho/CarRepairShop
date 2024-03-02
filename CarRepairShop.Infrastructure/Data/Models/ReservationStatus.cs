using System.ComponentModel.DataAnnotations;

namespace CarRepairShop.Infrastructure.Data.Models
{
    public class ReservationStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public IList<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
