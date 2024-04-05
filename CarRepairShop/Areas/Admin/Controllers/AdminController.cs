using CarRepairShop.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> AddRole(AddRoleToUserFormModel model)
        {
            string roleName = model.RoleName;
            if (!await roleManager.RoleExistsAsync(roleName))
                await roleManager.CreateAsync(new IdentityRole(roleName));

            var userName = await userManager.FindByEmailAsync(model.Email);
            if (userName == null)
            {
                ModelState.AddModelError(nameof(model.Email), $"User with this email dont exist");
                return View(model);
            }
            await userManager.AddToRoleAsync(userName, roleName);

            return RedirectToPage("/Home/Index");
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
