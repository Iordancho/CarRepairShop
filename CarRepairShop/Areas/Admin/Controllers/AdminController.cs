using CarRepairShop.Areas.Admin.Models;
using CarRepairShop.Core.Contracts;
using CarRepairShop.Core.Services;
using CarRepairShop.Core.Models;
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
        private readonly IAdminService adminService;

        public AdminController(RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager, IAdminService _adminService)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            adminService = _adminService;
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
            var userName = await userManager.FindByEmailAsync(model.Email);
            if (userName == null)
            {
                ModelState.AddModelError(nameof(model.Email), $"User with this email don't exist");
                return View(model);
            }

            await adminService.AddRole(model, userName);

            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AllCars()
        {
            var cars = await adminService.AllCarsAdminAsync();
            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> AllReservations()
        {
            var reservations = await adminService.AllReservationsAdminAsync();
            return View(reservations);
        }

        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            var users = await adminService.AllUsersAdminAsync();
            return View(users);
        }
    }
}
