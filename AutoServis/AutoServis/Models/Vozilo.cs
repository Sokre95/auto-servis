using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoServis.Models
{
    public class Vozilo
    {
        public int Id { get; set; }

        public string GodProizv { get; set; }

        [StringLength(10)]
        public string RegOznaka { get; set; }

        // Strani kljucevi...
        public string KorisnikId { get; set; }

        public int TipVozilaId { get; set; }

        // Navigacija...
        public virtual Korisnik Korisnik { get; set; }

        public virtual TipVozila TipVozila { get; set; }

        public virtual ICollection<Popravak> Popravci { get; set; }
    }
}