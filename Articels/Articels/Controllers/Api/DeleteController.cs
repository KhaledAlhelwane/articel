using Articels.Data;
using Articels.Models;
using Articels.Models.Repository;
using Microsoft.AspNetCore.Http;
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

        public DeleteController(ICRUD<Articelss> ArticelRepo, ApplicationDbContext Db)
        {
            articelRepo = ArticelRepo;
            db = Db;
        }

        [HttpDelete]
        public IActionResult DeleteArticle(int id)
        {

            articelRepo.Delete(id);
            return Ok();
        }
    }
}
