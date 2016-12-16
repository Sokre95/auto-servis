using AutoServis.Models;

namespace AutoServis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	
    public class Korisnik
    {
        public Korisnik()
        {
            Popravak = new HashSet<Popravak>();
            Vozilo = new HashSet<Vozilo>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string eMail { get; set; }

        [StringLength(30)]
        public string ime { get; set; }

        [StringLength(30)]
        public string prezime { get; set; }

        [Required]
        [StringLength(30)]
        public string lozinka { get; set; }

        [StringLength(20)]
        public string brTel { get; set; }

        public virtual ICollection<Popravak> Popravak { get; set; }

        public virtual ICollection<Vozilo> Vozilo { get; set; }
    }
}
