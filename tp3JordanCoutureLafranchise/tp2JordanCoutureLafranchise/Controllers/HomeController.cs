using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using tp2JordanCoutureLafranchise.Models;
using tp2JordanCoutureLafranchise.Models.Data;
using tp2JordanCoutureLafranchise.ViewModels;
using tp3JordanCoutureLafranchise.Services;
using tp3JordanCoutureLafranchise.ViewModels;

namespace tp2JordanCoutureLafranchise.Controllers
{
    public class HomeController : Controller
    {
        private IParentService _parentService { get; set; }
        private HockeyRebelsDBContext _BaseDonnees { get; set; }
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(/*HockeyRebelsDBContext BaseDonnees,*/ IParentService parentService, IStringLocalizer<HomeController> localizer)
        {
            //_BaseDonnees = BaseDonnees;
            _localizer = localizer;
            _parentService= parentService;
        }


        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = this._localizer["HomeIndexTitle"];
            //var listeparents = _BaseDonnees.Parents.ToList();
            IEnumerable<Parent> ParentsList = await _parentService.GetAllAsync();


            return View(ParentsList);
        }



        public async  Task<ActionResult> Delete(int id)
        {
            Parent equipe =  await _parentService.GetByIdAsync(id);

            return View(equipe);
        }

        // POST: GestionEnfantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            Parent parent =  await _parentService.GetByIdAsync(id);
            //supprimer l'enfant avec l'id passé en parametre de la
            // BD et de la liste des enfants de son parent

            if (ModelState.IsValid)
            {
               await _parentService.DeleteAsync(id);
                return RedirectToAction("Index", "Home");
            }
            return View(parent);

        }



        public IActionResult Create()
        {
            ViewData["titre"] = "Ajouter une équipe";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(Parent parent)
        {
            if (ModelState.IsValid)
            {
                ViewData["titre"] = "Ajouter une équipe";
               await _parentService.CreateAsync(parent);
                
                return RedirectToAction("index", "Home");
            }
            return View(parent);


        }

       
        public async Task<IActionResult> Update(int id)
        {
            Parent? parent = await _parentService.GetByIdAsync(id);
            ViewData["titre"] = "Modifier une équipe";
            return View(parent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Parent parent)
        {
            if (ModelState.IsValid)
            {
                ViewData["titre"] = "Modifier une équipe";
                await _parentService.EditAsync(parent);
                return RedirectToAction("index", "Home");
            }
            return View(parent);
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            var cookie = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture));
            var name = CookieRequestCultureProvider.DefaultCookieName;

            Response.Cookies.Append(name, cookie, new CookieOptions
            {
                Path = "/",
                Expires = DateTimeOffset.UtcNow.AddYears(1),
            });

            return LocalRedirect(returnUrl);
        }

        //public IActionResult Details(int id)
        //{
        //    var detailparentvm = new DetailParentVM
        //    {
        //        Parent = _BaseDonnees.Parents.Where(x => x.ParentId == id).FirstOrDefault(),
        //        enfants = _BaseDonnees.Enfants.Where(x => x.ParentId == id).ToList()

        //    };

        //    return View(detailparentvm);
        //}




    }
}