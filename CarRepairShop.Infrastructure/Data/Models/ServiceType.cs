using System.ComponentModel.DataAnnotations;

namespace CarRepairShop.Infrastructure.Data.Models
{
    public class ServiceType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
