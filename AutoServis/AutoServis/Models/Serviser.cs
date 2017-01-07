using AutoServis.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace AutoServis.Models
{
    [Table("Serviser")]
    public class Serviser : ApplicationUser
    {
        public virtual ICollection<Popravak> Popravci { get; set; }
    }
}