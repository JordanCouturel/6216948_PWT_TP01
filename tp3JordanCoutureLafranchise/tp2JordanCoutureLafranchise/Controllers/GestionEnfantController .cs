using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using tp2JordanCoutureLafranchise.Models;
using tp2JordanCoutureLafranchise.ViewModels;
using tp2JordanCoutureLafranchise.Models.Data;
using tp3JordanCoutureLafranchise.Models;
using tp3JordanCoutureLafranchise.ViewModels;
using tp3JordanCoutureLafranchise.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace tp2JordanCoutureLafranchise.Controllers
{
    public class GestionEnfantController : Controller
    {
        private ILogger<GestionEnfantController> _logger;
        private HockeyRebelsDBContext _BaseDonnees { get; set; }
        public GestionEnfantController(HockeyRebelsDBContext BaseDeDonnees, ILogger<GestionEnfantController> logger)
        {
            _BaseDonnees = BaseDeDonnees;
            _logger = logger;
        }




        public ActionResult Delete(int id)
        {
            Enfant joueur = _BaseDonnees.Enfants.Where(x => x.Id == id).FirstOrDefault();
            if(joueur.ImageURL==null)
            {
                joueur.ImageURL = "Equipe";
            }

            return View(joueur);
        }

        // POST: GestionEnfantController/Delete/5
        [HttpPost]
        [Authorize(Roles = "User")]
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

        public IActionResult Create()
        {
            ViewData["titre"] = "Ajouter un joueur";
            var availableEntraineurs = _BaseDonnees.Entraineur.Select(t=>new SelectListItem
            {
                Text = t.NomComplet,
                Value = t.Id.ToString()
            } );
            var enfantVM = new EnfantVM
            {
                Enfant = new Enfant(), // Create a new Enfant instance with default values
                AvailableEntraineurs = availableEntraineurs
            };
            enfantVM.ParentSelectList = _BaseDonnees.Parents.Select(t => new SelectListItem
            {
                Text = t.Nom,
                Value = t.ParentId.ToString()
            }).OrderBy(t => t.Text);

            
          
            return View(enfantVM);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EnfantVM enfantVM)
        {

            if (ModelState.IsValid)
            {

                enfantVM.Enfant.Equipe = _BaseDonnees.Parents.FirstOrDefault(p => p.ParentId == enfantVM.Enfant.ParentId)?.Nom;
                if (enfantVM.Enfant.Entraineurs == null)
                    enfantVM.Enfant.Entraineurs = new List<Entraineur>();


                foreach (var item in enfantVM.SelectedEntraineurIds)
                {
                    var Entraineur = _BaseDonnees.Entraineur.Where(e => enfantVM.SelectedEntraineurIds.Contains(e.Id)).ToList();

                    if (Entraineur != null)
                    {
                        foreach (var item1 in Entraineur)
                        {
                            enfantVM.Enfant.Entraineurs.Add(item1);
                        }

                    }
                }

                _BaseDonnees.Add(enfantVM.Enfant);
                _BaseDonnees.SaveChanges();

                // Enregistrement de l'action dans le ILogger
                _logger.LogInformation($"{enfantVM.Enfant.Nom} ajouté avec succès");

                return RedirectToAction("index", "Home");
            }
         


            return View(enfantVM);

        }

        public IActionResult Update(int id)
        {

            ViewData["titre"] = "Modifier un joueur";
           
            var availableEntraineurs = _BaseDonnees.Entraineur.Select(t => new SelectListItem
            {
                Text = t.NomComplet,
                Value = t.Id.ToString()
            });
            var enfantVM = new EnfantVM
            {
                Enfant = _BaseDonnees.Enfants.Where(t => t.Id == id).SingleOrDefault(),
                AvailableEntraineurs = availableEntraineurs
            };
         
            enfantVM.ParentSelectList = _BaseDonnees.Parents.Select(t => new SelectListItem
            {
                Text = t.Nom,
                Value = t.ParentId.ToString()
            }).OrderBy(t => t.Text);



            return View(enfantVM);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EnfantVM enfantVM)
        {
     
                  if (ModelState.IsValid)
            {

                enfantVM.Enfant.Equipe = _BaseDonnees.Parents.FirstOrDefault(p => p.ParentId == enfantVM.Enfant.ParentId)?.Nom;
                if (enfantVM.Enfant.Entraineurs == null)
                    enfantVM.Enfant.Entraineurs = new List<Entraineur>();


                foreach (var item in enfantVM.SelectedEntraineurIds)
                {
                    var Entraineur = _BaseDonnees.Entraineur.Where(e => enfantVM.SelectedEntraineurIds.Contains(e.Id)).ToList();

                    if (Entraineur != null)
                    {
                        foreach (var item1 in Entraineur)
                        {
                            enfantVM.Enfant.Entraineurs.Add(item1);
                        }

                    }
                }

                _BaseDonnees.Update(enfantVM.Enfant);
                _BaseDonnees.SaveChanges();

                // Enregistrement de l'action dans le ILogger
                _logger.LogInformation($"{enfantVM.Enfant.Nom} ajouté avec succès");

                return RedirectToAction("index", "Home");
            }
         


            return View(enfantVM);

        }

     

    }


}
