using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CarRepairShop.Infrastructure.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public int MakeId { get; set; }

        [Required]
        public CarMake Make { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public string VIN { get; set; } = string.Empty;

        public string OwnerId { get; set; } = string.Empty;

        public IdentityUser Owner { get; set; } = null!;

        public IList<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
