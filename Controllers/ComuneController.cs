using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMVCComboCascadeEF.Models;

namespace WebAppMVCComboCascadeEF.Controllers
{
    public class ComuneController : Controller
    {
        private readonly CorsoAcademyContext _context;

        public ComuneController(CorsoAcademyContext context)
        {
            _context = context;
        }

        // GET: Comune
        public async Task<IActionResult> Index()
        {
            var corsoAcademyContext = _context.TComunes.Include(t => t.IdProvinciaNavigation);
            return View(await corsoAcademyContext.ToListAsync());
        }

        // GET: Comune/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tComune = await _context.TComunes
                .Include(t => t.IdProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tComune == null)
            {
                return NotFound();
            }

            return View(tComune);
        }

        // GET: Comune/Create
        public IActionResult Create()
        {
            ViewData["IdProvincia"] = new SelectList(_context.TProvincia, "Id", "Nome");
            return View();
        }

        // POST: Comune/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,IdProvincia,NumAbitanti")] TComune tComune)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tComune);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProvincia"] = new SelectList(_context.TProvincia, "Id", "Nome", tComune.IdProvincia);
            return View(tComune);
        }

        // GET: Comune/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tComune = await _context.TComunes.FindAsync(id);
            if (tComune == null)
            {
                return NotFound();
            }
            ViewData["IdProvincia"] = new SelectList(_context.TProvincia, "Id", "Nome", tComune.IdProvincia);
            return View(tComune);
        }

        // POST: Comune/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,IdProvincia,NumAbitanti")] TComune tComune)
        {
            if (id != tComune.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tComune);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TComuneExists(tComune.Id))
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
            ViewData["IdProvincia"] = new SelectList(_context.TProvincia, "Id", "Id", tComune.IdProvincia);
            return View(tComune);
        }

        // GET: Comune/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tComune = await _context.TComunes
                .Include(t => t.IdProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tComune == null)
            {
                return NotFound();
            }

            return View(tComune);
        }

        // POST: Comune/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tComune = await _context.TComunes.FindAsync(id);
            if (tComune != null)
            {
                _context.TComunes.Remove(tComune);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TComuneExists(int id)
        {
            return _context.TComunes.Any(e => e.Id == id);
        }
    }
}
