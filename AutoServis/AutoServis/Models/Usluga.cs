namespace AutoServis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usluga")]
    public partial class Usluga
    {
        public Usluga()
        {
            Popravak = new HashSet<Popravak>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string opis { get; set; }

        public virtual ICollection<Popravak> Popravak { get; set; }
    }
}
