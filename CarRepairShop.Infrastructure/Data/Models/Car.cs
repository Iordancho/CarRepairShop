using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static CarRepairShop.Infrastructure.Data.DataConstants;

namespace CarRepairShop.Infrastructure.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MakeId { get; set; }

        [Required]
        [ForeignKey(nameof(MakeId))]
        public CarMake Make { get; set; } = null!;

        [Required]
        [MaxLength(CarModelMax)]
        public string Model { get; set; } = null!;

        [Required]
        public DateTime Year { get; set; }

        [Required]
        [MaxLength(VINMax)]
        public string VIN { get; set; } = string.Empty;

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;

        public IList<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
