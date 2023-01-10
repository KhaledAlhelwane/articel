using Articels.Models;
using Articels.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Articels.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManger;
        private readonly RoleManager<IdentityRole> rolesManger;

        public AdminController(UserManager<ApplicationUser> userManger, RoleManager<IdentityRole> RolesManger)
        {
            this.userManger = userManger;
            rolesManger = RolesManger;
        }

        public async Task<IActionResult> Index()
        {
            var rolesList = await rolesManger.Roles.ToListAsync();

            return View(rolesList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(RoleViewModel collection)
        {
            if (!ModelState.IsValid )
            {
                ModelState.AddModelError("name", "Role cant be empty or too long name for role");
                return View("Index", await rolesManger.Roles.ToListAsync());
            }
            var roleexist = await rolesManger.RoleExistsAsync(collection.Name);
            if (roleexist)
            {
                ModelState.AddModelError("NAME", "THIS ROLE IS REALY EXISIT");
                return View("Index", await rolesManger.Roles.ToListAsync());
            }
            await rolesManger.CreateAsync(new IdentityRole(collection.Name));
            return View("Index", await rolesManger.Roles.ToListAsync());

        }
    }
}
