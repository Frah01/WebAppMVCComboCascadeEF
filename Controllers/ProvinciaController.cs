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
    public class ProvinciaController : Controller
    {
        private readonly CorsoAcademyContext _context;

        public ProvinciaController(CorsoAcademyContext context)
        {
            _context = context;
        }

        // GET: Provincia
        public async Task<IActionResult> Index()
        {
            var corsoAcademyContext = _context.TProvincia.Include(t => t.IdRegioneNavigation);
            return View(await corsoAcademyContext.ToListAsync());
        }

        // GET: Provincia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tProvincium = await _context.TProvincia
                .Include(t => t.IdRegioneNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tProvincium == null)
            {
                return NotFound();
            }

            return View(tProvincium);
        }

        // GET: Provincia/Create
        public IActionResult Create()
        {
            ViewData["IdRegione"] = new SelectList(_context.TRegiones, "Id", "Id");
            return View();
        }

        // POST: Provincia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,IdRegione,NumAbitanti,IsCapoluogo")] TProvincium tProvincium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tProvincium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRegione"] = new SelectList(_context.TRegiones, "Id", "Id", tProvincium.IdRegione);
            return View(tProvincium);
        }

        // GET: Provincia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tProvincium = await _context.TProvincia.FindAsync(id);
            if (tProvincium == null)
            {
                return NotFound();
            }
            ViewData["IdRegione"] = new SelectList(_context.TRegiones, "Id", "Id", tProvincium.IdRegione);
            return View(tProvincium);
        }

        // POST: Provincia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,IdRegione,NumAbitanti,IsCapoluogo")] TProvincium tProvincium)
        {
            if (id != tProvincium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tProvincium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TProvinciumExists(tProvincium.Id))
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
            ViewData["IdRegione"] = new SelectList(_context.TRegiones, "Id", "Id", tProvincium.IdRegione);
            return View(tProvincium);
        }

        // GET: Provincia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tProvincium = await _context.TProvincia
                .Include(t => t.IdRegioneNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tProvincium == null)
            {
                return NotFound();
            }

            return View(tProvincium);
        }

        // POST: Provincia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tProvincium = await _context.TProvincia.FindAsync(id);
            if (tProvincium != null)
            {
                _context.TProvincia.Remove(tProvincium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TProvinciumExists(int id)
        {
            return _context.TProvincia.Any(e => e.Id == id);
        }
    }
}
