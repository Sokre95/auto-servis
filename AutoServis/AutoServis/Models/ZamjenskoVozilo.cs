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
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string RegOznaka { get; set; }

        public bool Dostupno { get; set; }

        public virtual ICollection<Popravak> Popravak { get; set; }
    }
}
