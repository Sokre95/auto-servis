using AutoServis.Models;

namespace AutoServis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	
    public class ZamjenskoVozilo
    {
        public ZamjenskoVozilo()
        {
            Popravak = new HashSet<Popravak>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string regOznaka { get; set; }

        public bool dostupno { get; set; }

        public virtual ICollection<Popravak> Popravak { get; set; }
    }
}
