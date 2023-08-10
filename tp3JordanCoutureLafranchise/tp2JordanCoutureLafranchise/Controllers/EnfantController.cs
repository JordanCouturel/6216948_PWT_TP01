using Microsoft.AspNetCore.Mvc;
using tp2JordanCoutureLafranchise.Models;
using tp2JordanCoutureLafranchise.Models.Data;
using tp2JordanCoutureLafranchise.ViewModels;

namespace tp2JordanCoutureLafranchise.Controllers
{
    public class EnfantController : Controller
    {

        public HockeyRebelsDBContext _Basedonnees { get; set; }

        public EnfantController(HockeyRebelsDBContext BD)
        {
            _Basedonnees = BD;
        }


        [Route("Enfant/Recherche")]
        [Route("Recherche")]
        public IActionResult Recherche()
        {

            var model = new PageRechercheViewModel();
            model.Criteres = new CritereRechercheViewModel();
            model.Criteres.estCanadiensDeMontreal = true;
            model.Criteres.estPenguinsDePittsburgh = true;
            model.Criteres.estCapitalsDeWashington = true;
            model.Criteres.ChoixEnVedette = "Peu Importe";
            model.Resultat = _Basedonnees.Enfants.ToList();


            return View("recherche", model);
        }

        [Route("Enfant/filtrer")]
        [Route("filtrer")]
        public IActionResult Filtrer(CritereRechercheViewModel criteres)
        {
            ViewData["titre"] = "RechercheFiltrée";
            var listenfants = _Basedonnees.Enfants.ToList();


            var model = new PageRechercheViewModel();
            model.Criteres = criteres;


            //numero de chandail
            if (criteres.ParNumeroDeChandail != null)
            {
                listenfants = listenfants.Where(x => x.NumeroDeChandail == criteres.ParNumeroDeChandail).ToList();
            }


            //Nom de joueur
            if (criteres.ParNom != null)
            {
                listenfants = listenfants.Where(x => x.Nom.ToUpper().Contains(criteres.ParNom.ToUpper())).ToList();
            }

            //En vedette ou non
            switch (criteres.ChoixEnVedette)
            {
                case "Peu importe":
                    break;

                case "Oui":
                    listenfants = listenfants.Where(x => x.EnVedette == criteres.ChoixEnVedette).ToList();
                    break;

                case "Non":
                    listenfants = listenfants.Where(x => x.EnVedette == criteres.ChoixEnVedette).ToList();
                    break;
            }

            //par equipe

            if (criteres.estPenguinsDePittsburgh == false)
            {
                listenfants = listenfants.Where(x => x.Equipe != "Penguins de Pittsburgh").ToList();
            }
            if (criteres.estCapitalsDeWashington == false)
            {
                listenfants = listenfants.Where(x => x.Equipe != "Capitals de Washington").ToList();
            }
            if (criteres.estCanadiensDeMontreal == false)
            {
                listenfants = listenfants.Where(x => x.Equipe != "Canadiens de Montréal").ToList();
            }


            model.Resultat = listenfants;


            if (model.Resultat.Count == 0)
            {

                return View("~/Views/Enfant/NotFound2.cshtml", model);
            }
            else
            {
                return View("recherche", model);
            }

        }




        [Route("Detail/{id:int}")]
        [Route("enfant/detail/{id:int}")]
        [Route("enfant/{id:int}")]
        [Route("{id:int}")]
        public IActionResult DetailParID(int id)
        {
            ViewData["titre"] = "Détails";
            var enfant = _Basedonnees.Enfants.Where(x => x.Id == id).FirstOrDefault();

            if (enfant == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
            return View("detail", enfant);
        }

        [Route("enfant/detail/{nom}")]
        [Route("enfant/{nom}")]
        [Route("{nom}")]
        public IActionResult DetailParNom(string nom)
        {
            ViewData["titre"] = "Détails";
            var enfant = _Basedonnees.Enfants.Where(x => x.Nom.Replace(" ", "-").ToUpper() == nom.ToUpper()).FirstOrDefault();

            if (enfant == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
            return View("detail", enfant);
        }




    }
}
