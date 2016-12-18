using AutoServis.Models;

namespace AutoServis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	
    public class Serviser : ApplicationUser
    {
        public virtual ICollection<Popravak> Popravak { get; set; }
    }
}
