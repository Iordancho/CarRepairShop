using System.ComponentModel.DataAnnotations;

namespace CarRepairShop.Core.Models.Admin
{
    public class AddRoleToUserFormModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}
