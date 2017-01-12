using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoServis.Models;

namespace AutoServis.ViewModels
{
    public class EditPopravakViewmodel
    {
        public IEnumerable<Usluga> Usluge { get; set; }

        [Required(ErrorMessage = "Odaberite najmanje jednu uslugu")]
        [DisplayName("Odaberite usluge")]
        public ICollection<string> OdabraneUsluge { get; set; }

        public ICollection<ZamjenskoVozilo> ZamjenskaVozila { get; set; }

        [DisplayName("Zamjensko vozilo")]
        public string ZamjenskoVozilo { get; set; }

        [StringLength(500,ErrorMessage = "Maksimalno 500 znakova")]
        [DisplayName("Dodatan opis")]
        public string DodatanOpis { get; set; }

        [StringLength(500, ErrorMessage = "Maksimalno 500 znakova")]
        [DisplayName("Napomena korisniku")]
        public string Napomena { get; set; }

        public int IdPopravak { get; set; }
    }
}