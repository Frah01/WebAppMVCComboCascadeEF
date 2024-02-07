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
    public class RegioneController : Controller
    {
        private readonly CorsoAcademyContext _context;

        public RegioneController(CorsoAcademyContext context)
        {
            _context = context;
        }

        // GET: Regione
        public async Task<IActionResult> Index()
        {
            return View(await _context.TRegiones.ToListAsync());
        }

        // GET: Regione/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tRegione = await _context.TRegiones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tRegione == null)
            {
                return NotFound();
            }

            return View(tRegione);
        }

        // GET: Regione/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regione/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,IsAutonoma,NumAbitanti")] TRegione tRegione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tRegione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tRegione);
        }

        // GET: Regione/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tRegione = await _context.TRegiones.FindAsync(id);
            if (tRegione == null)
            {
                return NotFound();
            }
            return View(tRegione);
        }

        // POST: Regione/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,IsAutonoma,NumAbitanti")] TRegione tRegione)
        {
            if (id != tRegione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tRegione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TRegioneExists(tRegione.Id))
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
            return View(tRegione);
        }

        // GET: Regione/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tRegione = await _context.TRegiones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tRegione == null)
            {
                return NotFound();
            }

            return View(tRegione);
        }

        // POST: Regione/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tRegione = await _context.TRegiones.FindAsync(id);
            if (tRegione != null)
            {
                _context.TRegiones.Remove(tRegione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TRegioneExists(int id)
        {
            return _context.TRegiones.Any(e => e.Id == id);
        }
    }
}
