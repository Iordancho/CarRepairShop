namespace CarRepairShop.Core.Models
{
    public class UserWithRolesViewModel
    {
        public string Email { get; set; } = string.Empty;
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
