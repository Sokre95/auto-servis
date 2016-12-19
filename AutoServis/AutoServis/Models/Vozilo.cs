
namespace AutoServis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	
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
        public virtual ApplicationUser Korisnik { get; set; }

        public virtual TipVozila TipVozila { get; set; }

        public virtual ICollection<Popravak> Popravci { get; set; }
    }
}
