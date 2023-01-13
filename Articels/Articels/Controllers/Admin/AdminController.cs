using Articels.Models;
using Articels.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

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

        //for adding roles
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

        public async Task<IActionResult> UserRolesIndex()
        {
            //var lisat = new UserViewModel();
            var list = await userManger.Users.Select(x => new UserViewModel
            {
                Email = x.Email,
                FirstName = x.FirstName,
                id = x.Id,
                LastName = x.SecoundName,
                UserName = x.UserName,
                Roles = userManger.GetRolesAsync(x).Result
            }).ToListAsync();
            //foreach(var b in x)
            //{
            //    var user = new UserViewModel
            //    {
            //        Email = b.Email,
            //        FirstName = b.FirstName,
            //        LastName = b.SecoundName,
            //        Roles = rolesManger.Roles.ToListAsync().Result
            //    };
            //}
            
            return View(list);
        }


        public async Task<IActionResult> MangeRoles(string Id) {
            var user = await userManger.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound(); 
            }
            var roles =await rolesManger.Roles.ToListAsync();
            var UserWithRoles = new UserRoleViewModel
            {
                UserId = user.Id,
                UserName = user.FirstName,
                roles = roles.Select(role => new RoleViewModel {
                    Name = role.Name,
                    CheckingRole = userManger.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };

            return View(UserWithRoles);
        }

    }
}
