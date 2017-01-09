
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

        [StringLength(500)]
        public string Opis { get; set; }

        public virtual ICollection<Popravak> Popravci { get; set; }
    }
}
