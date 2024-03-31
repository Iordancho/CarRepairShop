using CarRepairShop.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public AdminController(RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            var model = new AddRoleToUserFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleToUserFormModel user)
        {
            string roleName = user.RoleName;
            if (!await roleManager.RoleExistsAsync(roleName))
                await roleManager.CreateAsync(new IdentityRole(roleName));

            var userName = await userManager.FindByEmailAsync(user.Email);
            if (userName == null)
            {
                ModelState.AddModelError(nameof(user.Email), $"User with this email dont exist");
                return View(user);
            }
            await userManager.AddToRoleAsync(userName, roleName);

            return RedirectToAction("Index", "Home");
        }
    }
}
