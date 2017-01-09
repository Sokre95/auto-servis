using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutoServis.ViewModels
{
    public class RepairViewModel
    {
        public IEnumerable<SelectListItem> Vozila { get; set; }

        [Required(ErrorMessage = "Odaberite vozilo za popravak")]
        [DisplayName("Odaberite vozilo")]
        public string OdabranoVozilo { get; set; }

        public IEnumerable<SelectListItem> Serviseri { get; set; }

        [DisplayName("Odaberite servisera")]
        public string OdabraniServiser { get; set; }
    }
}