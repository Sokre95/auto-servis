using AutoServis.Models;

namespace AutoServis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Usluga
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Opis { get; set; }

        public virtual ICollection<Popravak> Popravak { get; set; }
    }
}
