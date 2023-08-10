using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tp2JordanCoutureLafranchise.Models;

namespace tp2JordanCoutureLafranchise.Controllers
{
    public class HomeController : Controller
    {

        private BaseDeDonnees _BaseDonnees { get; set; }

        public HomeController(BaseDeDonnees BaseDeDonnees)
        {
            _BaseDonnees = BaseDeDonnees;
        }



        public IActionResult Index()
        {
            ViewData["titre"] = "Accueil";
            var listeparents = _BaseDonnees.Parents.ToList();


            return View(listeparents);
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