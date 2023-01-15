using Articels.Models;
using Articels.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Articels.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICRUD<Articelss> articelsRepo;

        public HomeController(ILogger<HomeController> logger, ICRUD<Articelss> ArticelsRepo)
        {
            _logger = logger;
            articelsRepo = ArticelsRepo;
        }

        public IActionResult Index()
        {
           var rng = new Random();
            var articelss = articelsRepo.List().OrderBy(x => x.Title);
            return View(articelss);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}