using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
