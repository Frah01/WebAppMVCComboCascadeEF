using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebAppMVCComboCascadeEF.Models;

namespace WebAppMVCComboCascadeEF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CorsoAcademyContext _context;
        public HomeController(CorsoAcademyContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public ActionResult Index()
        {
            CascadingModel model = new CascadingModel();
            foreach (var country in _context.TRegiones)
            {
                model.Regioni.Add(new SelectListItem { Text = country.Nome, Value = country.Id.ToString() });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int? IdRegione, int? IdProvincia, int? IdComune)
        {
            CascadingModel model = new CascadingModel();

            // Popolamento delle dropdown Regioni
            foreach (var regione in _context.TRegiones)
            {
                model.Regioni.Add(new SelectListItem { Text = regione.Nome, Value = regione.Id.ToString() });
            }

            // Se è stato selezionato un paese, popola le dropdown Province
            if (IdRegione.HasValue)
            {
                var province = _context.TProvincia.Where(provincia => provincia.IdRegione == IdRegione.Value).ToList();
                foreach (var provincia in province)
                {
                    model.Province.Add(new SelectListItem { Text = provincia.Nome, Value = provincia.Id.ToString() });
                }

                // Imposta il valore selezionato per la dropdown Regione
                model.IdRegione = IdRegione.Value;

                // Se è stato selezionato uno stato, popola le dropdown Comuni
                if (IdComune.HasValue)
                {
                    var cities = _context.TComunes.Where(city => city.IdProvincia == IdComune.Value).ToList();
                    foreach (var city in cities)
                    {
                        model.Comuni.Add(new SelectListItem { Text = city.Nome, Value = city.Id.ToString() });
                    }

                    // Imposta il valore selezionato per la dropdown Provincia
                    model.IdComune = IdComune.Value;
                }
            }

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
