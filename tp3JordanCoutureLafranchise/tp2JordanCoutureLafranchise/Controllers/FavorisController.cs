
//using Microsoft.AspNetCore.Mvc;
//using tp2JordanCoutureLafranchise.Extensions;
//using tp2JordanCoutureLafranchise.Models;

//namespace tp2JordanCoutureLafranchise.Controllers
//{
//    public class FavorisController : Controller
//    {

//        private BaseDeDonnees _BaseDonnees { get; set; }

//        public FavorisController(BaseDeDonnees BaseDeDonnees)
//        {
//            _BaseDonnees = BaseDeDonnees;
//        }
//        [Route("favoris/index")]
//        [Route("favoris")]
//        public IActionResult Index()
//        {
//            var enfantIDs = HttpContext.Session.Get<List<int>>("enfantIDs");

//            if (enfantIDs == null)
//            {
//                enfantIDs = new List<int>();
//            }

//            var enfantsdelabd = _BaseDonnees.Enfants.Where(x => enfantIDs.Contains(x.Id)).ToList();

//            return View(enfantsdelabd);
//        }

//        public IActionResult SupprimerUnEnfant(int id)
//        {
//            var enfantIDs = HttpContext.Session.Get<List<int>>("enfantIDs");

//            if (enfantIDs == null)
//            {
//                enfantIDs = new List<int>();
//            }

//            enfantIDs.Remove(id);
//            HttpContext.Session.Set<List<int>>("enfantIDs", enfantIDs);
//            return RedirectToAction("index");

//        }

//        public IActionResult AjouterUnEnfant(int id)
//        {
//            var enfantIDs = HttpContext.Session.Get<List<int>>("enfantIDs");


//            if (enfantIDs == null)
//            {
//                enfantIDs = new List<int>();
//            }

//            if (!enfantIDs.Contains(id))
//            {
//                enfantIDs.Add(id);
//            }
//            HttpContext.Session.Set<List<int>>("enfantIDs", enfantIDs);





//            return RedirectToAction("index");

//        }
//    }
//}