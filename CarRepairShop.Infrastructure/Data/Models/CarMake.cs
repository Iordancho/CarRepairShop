using System.ComponentModel.DataAnnotations;

namespace CarRepairShop.Infrastructure.Data.Models
{
    public class CarMake
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
