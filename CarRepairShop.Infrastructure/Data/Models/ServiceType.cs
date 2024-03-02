using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRepairShop.Infrastructure.Data.Models
{
    public class ServiceType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public IList<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
