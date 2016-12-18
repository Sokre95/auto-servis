using AutoServis.Models;

namespace AutoServis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DodatnaUsluga
    {
        public int Id { get; set; }

        public int IdPopravak { get; set; }

        [StringLength(500)]
        public string Opis { get; set; }

        public virtual Popravak Popravak { get; set; }
    }
}
