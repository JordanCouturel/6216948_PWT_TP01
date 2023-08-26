using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tp2JordanCoutureLafranchise.Models.Data;
using tp2JordanCoutureLafranchise.Models;
using tp3JordanCoutureLafranchise.Models;

namespace tp3JordanCoutureLafranchise.Controllers
{
    public class EntraineursController : Controller
    {
        private readonly HockeyRebelsDBContext _context;

        public EntraineursController(HockeyRebelsDBContext context)
        {
            _context = context;
        }

        // GET: Entraineurs
        public async Task<IActionResult> Index()
        {
              return _context.Entraineur != null ? 
                          View(await _context.Entraineur.ToListAsync()) :
                          Problem("Entity set 'HockeyRebelsDBContext.Entraineur'  is null.");
        }

        // GET: Entraineurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Entraineur == null)
            {
                return NotFound();
            }

            var entraineur = await _context.Entraineur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entraineur == null)
            {
                return NotFound();
            }

            return View(entraineur);
        }

        // GET: Entraineurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entraineurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomComplet,Specialite")] Entraineur entraineur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entraineur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entraineur);
        }

        // GET: Entraineurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Entraineur == null)
            {
                return NotFound();
            }

            var entraineur = await _context.Entraineur.FindAsync(id);
            if (entraineur == null)
            {
                return NotFound();
            }
            return View(entraineur);
        }

        // POST: Entraineurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomComplet,Specialite")] Entraineur entraineur)
        {
            if (id != entraineur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entraineur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntraineurExists(entraineur.Id))
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
            return View(entraineur);
        }

        // GET: Entraineurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Entraineur == null)
            {
                return NotFound();
            }

            var entraineur = await _context.Entraineur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entraineur == null)
            {
                return NotFound();
            }

            return View(entraineur);
        }

        // POST: Entraineurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Entraineur == null)
            {
                return Problem("Entity set 'HockeyRebelsDBContext.Entraineur'  is null.");
            }
            var entraineur = await _context.Entraineur.FindAsync(id);
            if (entraineur != null)
            {
                _context.Entraineur.Remove(entraineur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntraineurExists(int id)
        {
          return (_context.Entraineur?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    
    }
}
