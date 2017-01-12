using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AutoServis.Models;

namespace AutoServis.ViewModels
{
    public class RepairOptionsViewModel
    {
        [Required(ErrorMessage = "Odaberite zeljeni termin u kojem vozilo zelite dopremiti na servis")]
        [DisplayName("Termin")]
        public string OdabraniTermin { get; set; }

        public IEnumerable<SelectListItem> DostupniTermini { get; set; }

        public IEnumerable<Usluga> Usluge { get; set; }

        [Required(ErrorMessage = "Odaberite najmanje jednu uslugu")]
        [DisplayName("Odaberite usluge")]
        public IEnumerable<string> OdabraneUsluge { get; set; }

        public IEnumerable<ZamjenskoVozilo> ZamjenskaVozila { get; set; }

        [DisplayName("Zamjensko vozilo")]
        public bool ZamjenskoVozilo { get; set; }

        [StringLength(500, ErrorMessage = "Maksimalno 500 znakova")]
        [DisplayName("Dodatan opis")]
        public string DodatanOpis { get; set; }

        public string OdabranoVozilo { get; set; }

        public string OdabraniServiser { get; set; }
    }
}