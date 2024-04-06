using System.ComponentModel.DataAnnotations;

namespace CarRepairShop.Areas.Admin.Models
{
    public class AddRoleToUserFormModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}
