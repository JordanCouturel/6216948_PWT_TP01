using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tp2JordanCoutureLafranchise.Models.Data;
using tp3JordanCoutureLafranchise.Models;
using tp3JordanCoutureLafranchise.ViewModels;

namespace tp3JordanCoutureLafranchise.Controllers
{
    public class DirecteurGeneralsController : Controller
    {
        private readonly HockeyRebelsDBContext _context;

        public DirecteurGeneralsController(HockeyRebelsDBContext context)
        {
            _context = context;
        }

        // GET: DirecteurGenerals
        public async Task<IActionResult> Index()
        {
            var hockeyRebelsDBContext = _context.DG.Include(d => d.Equipe);
            return View(await hockeyRebelsDBContext.ToListAsync());
        }

        // GET: DirecteurGenerals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DG == null)
            {
                return NotFound();
            }

            var directeurGeneral = await _context.DG
                .Include(d => d.Equipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directeurGeneral == null)
            {
                return NotFound();
            }

            return View(directeurGeneral);
        }

        // GET: DirecteurGenerals/Create
        public IActionResult Create()
        {
            ViewData["EquipeID"] = new SelectList(_context.Parents.Where(x => x.DirecteurGeneral == null), "ParentId", "Nom");
            return View();
        }

        // POST: DirecteurGenerals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prénom,EquipeID")] DirecteurGeneral directeurGeneral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directeurGeneral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeID"] = new SelectList(_context.Parents, "ParentId", "Nom", directeurGeneral.EquipeID);
            return View(directeurGeneral);
        }

        // GET: DirecteurGenerals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DG == null)
            {
                return NotFound();
            }

            var directeurGeneral = await _context.DG.FindAsync(id);
            if (directeurGeneral == null)
            {
                return NotFound();
            }
            ViewData["EquipeID"] = new SelectList(_context.Parents.Where(x=>x.DirecteurGeneral==null), "ParentId", "Nom", directeurGeneral.EquipeID);
            return View(directeurGeneral);
        }

        // POST: DirecteurGenerals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prénom,EquipeID")] DirecteurGeneral directeurGeneral)
        {
            if (id != directeurGeneral.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directeurGeneral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirecteurGeneralExists(directeurGeneral.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeID"] = new SelectList(_context.Parents, "ParentId", "Description", directeurGeneral.EquipeID);
            return View(directeurGeneral);
        }

        // GET: DirecteurGenerals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DG == null)
            {
                return NotFound();
            }

            var directeurGeneral = await _context.DG
                .Include(d => d.Equipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directeurGeneral == null)
            {
                return NotFound();
            }

            return View(directeurGeneral);
        }

        // POST: DirecteurGenerals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DG == null)
            {
                return Problem("Entity set 'HockeyRebelsDBContext.DG'  is null.");
            }
            var directeurGeneral = await _context.DG.FindAsync(id);
            if (directeurGeneral != null)
            {
                _context.DG.Remove(directeurGeneral);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirecteurGeneralExists(int id)
        {
          return (_context.DG?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        [Authorize(Roles ="Admin")]
        public IActionResult StatistiqueEntraineur()
        {

            var entraineursStats = _context.Entraineur.Include(e=>e.Joueurs)
                    .Select(e => new StatistiquesVM
                    {
                        entraineur = e,
                        NbJoueurs = e.Joueurs.Count

                    })
                    .ToList();

            var moyenneEnfantsParEntraineur = entraineursStats.Average(s => s.NbJoueurs);

            ViewData["MoyenneEnfantsParEntraineur"] = moyenneEnfantsParEntraineur;

            return View(entraineursStats);
        }
        [Authorize(Roles = "User" )]
        public IActionResult StatistiqueJoueur(StatistiquesVM statsVM)
        {
            var entraineursStats = _context.Enfants
          .Select(e => new StatistiquesVM
          {
              Joueur = e,
              NbEntraineurs = e.Entraineurs.Count
          })
          .ToList();

            var moyenneEnfantsParEntraineur = entraineursStats.Average(s => s.NbEntraineurs);

            ViewData["MoyenneEntraineurParEnfants"] = moyenneEnfantsParEntraineur;

            return View(entraineursStats);
        }
    }
}
