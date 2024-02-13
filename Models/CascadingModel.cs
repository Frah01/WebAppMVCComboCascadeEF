using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppMVCComboCascadeEF.Models
{
    public class CascadingModel
    {
        public CascadingModel()
        {
            this.Regioni = new List<SelectListItem>();
            this.Province = new List<SelectListItem>();
            this.Comuni = new List<SelectListItem>();
        }

        public List<SelectListItem> Regioni { get; set; }
        public List<SelectListItem> Province { get; set; }
        public List<SelectListItem> Comuni { get; set; }

        public int IdRegione { get; set; }
        public int IdProvincia { get; set; }
        public int IdComune { get; set; }
    }
}

