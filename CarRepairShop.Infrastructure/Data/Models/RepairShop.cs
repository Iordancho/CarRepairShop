using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CarRepairShop.Infrastructure.Data.Models
{
    public class RepairShop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;

        public IList<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
