using AutoServis.Models;

namespace AutoServis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	
    public class Serviser
    {
        public Serviser()
        {
            Popravak = new HashSet<Popravak>();
        }

        public int id { get; set; }

        [StringLength(30)]
        public string eMail { get; set; }

        [Required]
        [StringLength(30)]
        public string lozinka { get; set; }

        [StringLength(30)]
        public string ime { get; set; }

        [StringLength(30)]
        public string prezime { get; set; }

        [StringLength(20)]
        public string brTel { get; set; }

        public virtual ICollection<Popravak> Popravak { get; set; }
    }
}
