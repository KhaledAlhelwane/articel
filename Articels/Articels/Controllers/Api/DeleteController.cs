using Articels.Data;
using Articels.Models;
using Articels.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Articels.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly ICRUD<Articelss> articelRepo;
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManger;

        public DeleteController(ICRUD<Articelss> ArticelRepo, ApplicationDbContext Db,UserManager<ApplicationUser> userManger)
        {
            articelRepo = ArticelRepo;
            db = Db;
            this.userManger = userManger;
        }

        [HttpDelete]
        public IActionResult DeleteArticle(int id)
        {
            var aritcl = articelRepo.find(id);
            var user = userManger.GetUserAsync(User).Result;
            if (aritcl.ApplicationUser == user)
            {
                articelRepo.Delete(id);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
