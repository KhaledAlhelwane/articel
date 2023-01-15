using Articels.Models;
using Articels.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.Protocol;
using System.Net.WebSockets;

namespace Articels.Controllers.Blogger
{
    public class ArticelsController : Controller
    {
        private readonly ICRUD<Articelss> articelsRepo;

        public UserManager<ApplicationUser> UserManager { get; }

        public ArticelsController(ICRUD<Articelss> ArticelsRepo, UserManager<ApplicationUser> userManager)
        {
            articelsRepo = ArticelsRepo;
            UserManager = userManager;
        }
        // GET: ArticelsController
        public ActionResult Index()
        {
            var user = UserManager.GetUserAsync(User).Result;
            var ListOfArticels = articelsRepo.List().Where(i => i.ApplicationUser == user);

            if (ListOfArticels.Count() == 0)
            {
                ViewBag.success = "false";
                return View();
            }
            return View(ListOfArticels);
        }



        // GET: ArticelsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticelsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Articelss collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("information", "please reach all requirment");
                    return View();
                }


                else
                {
                    //   var user = UserManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
                    var user = UserManager.GetUserAsync(User).Result;
                    var image = Request.Form.Files.FirstOrDefault();

                    var articel = new Articelss
                    {
                        Title = collection.Title,
                        ArticelBody = collection.Title,
                        // ImageOfArticel = collection.ImageOfArticel,
                        ApplicationUser = user
                    };
                    using (var datastream = new MemoryStream())
                    {
                        await image.CopyToAsync(datastream);
                        articel.ImageOfArticel = datastream.ToArray();
                    }
                    articelsRepo.Add(articel);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
        }
        // GET: ArticelsController/Details/5
        public ActionResult Details(int id)
        {
            var articel = articelsRepo.find(id);

            return View(articel);
        }
        // GET: ArticelsController/Edit/5
        public ActionResult Edit(int id)
        {
            var articel = articelsRepo.find(id);
            return View(articel);
        }

        // POST: ArticelsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Articelss collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var articel = articelsRepo.find(id);
                articel.ImageOfArticel = collection.ImageOfArticel;
                articel.Title = collection.Title;
                articel.ArticelBody = collection.ArticelBody;
                articelsRepo.Update(articel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticelsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticelsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult like(int id)
        {
            //var the_articel = articelsRepo.find(id);
            //the_articel

            return View();

        }
    }
}
