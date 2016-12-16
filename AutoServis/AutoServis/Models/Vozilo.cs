using AutoServis.Models;

namespace AutoServis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	
    public class Vozilo
    {
        public Vozilo()
        {
            Popravak = new HashSet<Popravak>();
        }

        public int id { get; set; }

        public DateTime? godProizv { get; set; }

        [StringLength(10)]
        public string regOznaka { get; set; }

        public int id_korisnik { get; set; }

        public virtual ApplicationUser Korisnik { get; set; }

        public virtual ICollection<Popravak> Popravak { get; set; }
    }
}
