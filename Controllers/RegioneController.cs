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

        //USAGE SERILOG
        private readonly ILogger<HomeController> _logger;


        //Dependency Injection

        public RegioneController(CorsoAcademyContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Regione
        // GET: Regione
        public async Task<IActionResult> Index()
        {
            // USAGE SERILOG
            List<TRegione> listRegioni = null;
            try
            {
                // https://learn.microsoft.com/en-us/ef/core/querying/sql-queries
                // listRegioni = await _context.TRegiones.FromSql($"EXECUTE dbo.getAllRegioni").ToListAsync(); PER LA STORED PROCEDURE
                listRegioni = await _context.TRegiones.ToListAsync();
                _logger.LogDebug("Regioni presenti {0}", listRegioni.Count);
                _logger.LogInformation("Lista delle regioni");
                //throw new Exception("Errore"); //Generare Errore per controllare se SERILOG funziona
            }
            catch (Exception ex)
            {
                string sErr = string.Empty;
                if (ex.InnerException != null)
                {
                    sErr = string.Format("Source : {0}{4}Message : {1}{4}StackTrace: {2}{4}InnerException: {3}{4}", ex.Source, ex.Message, ex.StackTrace, ex.InnerException.Message, System.Environment.NewLine);
                }
                else
                {
                    sErr = string.Format("Source : {0}{3}Message : {1}{3}StackTrace: {2}{3}", ex.Source, ex.Message, ex.StackTrace, System.Environment.NewLine);

                }
                _logger.LogError(sErr);
                throw;
            }
            return View(listRegioni);
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
