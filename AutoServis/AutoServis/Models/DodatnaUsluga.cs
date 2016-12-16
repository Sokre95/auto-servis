using AutoServis.Models;

namespace AutoServis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DodatnaUsluga")]
    public partial class DodatnaUsluga
    {
        public int id { get; set; }

        public int id_popravak { get; set; }

        [StringLength(500)]
        public string opis { get; set; }

        public virtual Popravak Popravak { get; set; }
    }
}
