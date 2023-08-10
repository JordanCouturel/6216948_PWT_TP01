using Microsoft.AspNetCore.Mvc;
using tp2JordanCoutureLafranchise.Models;
using tp2JordanCoutureLafranchise.Models.Data;

namespace tp2JordanCoutureLafranchise.Controllers
{
    public class GestionEnfantController : Controller
    {

        private HockeyRebelsDBContext _BaseDonnees { get; set; }

        public GestionEnfantController(HockeyRebelsDBContext BaseDeDonnees)
        {
            _BaseDonnees = BaseDeDonnees;
        }


        public ActionResult Delete(int id)
        {
            Enfant joueur = _BaseDonnees.Enfants.Where(x => x.Id == id).FirstOrDefault();


            return View(joueur);
        }

        // POST: GestionEnfantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var enfantasuprimmer = _BaseDonnees.Enfants.Where(x => x.Id == id).Single();
            //supprimer l'enfant avec l'id passé en parametre de la
            // BD et de la liste des enfants de son parent
            if (ModelState.IsValid)
            {
                _BaseDonnees.Enfants.Remove(enfantasuprimmer);
                _BaseDonnees.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(enfantasuprimmer);
        }
    }
}
