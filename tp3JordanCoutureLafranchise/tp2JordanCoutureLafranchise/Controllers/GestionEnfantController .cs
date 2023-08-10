using Microsoft.AspNetCore.Mvc;
using tp2JordanCoutureLafranchise.Models;

namespace tp2JordanCoutureLafranchise.Controllers
{
    public class GestionEnfantController : Controller
    {

        private BaseDeDonnees _BaseDonnees { get; set; }

        public GestionEnfantController(BaseDeDonnees BaseDeDonnees)
        {
            _BaseDonnees = BaseDeDonnees;
        }


        // GET: GestionEnfantController/Delete/5
        [Route("GestionEnfant/Delete/{id}")]
        [Route("Delete/{id}")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Enfant? joueur = _BaseDonnees.Enfants.Where(x => x.Id == id).Single();

            if (joueur == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
            return View(joueur);
        }

        // POST: GestionEnfantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var enfantasuprimmer= _BaseDonnees.Enfants.Where(x=>x.Id == id).Single();
            //supprimer l'enfant avec l'id passé en parametre de la
            // BD et de la liste des enfants de son parent
            _BaseDonnees.Enfants.Remove(enfantasuprimmer);
            enfantasuprimmer.Parent.Enfants.Remove(enfantasuprimmer);

            return RedirectToAction("Index", "Home");
       
        }
    }
}
