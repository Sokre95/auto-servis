using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoServis.Models
{
    public class Korisnik : ApplicationUser
    {
        public virtual ICollection<Popravak> Popravci { get; set; }

        public virtual ICollection<Vozilo> Vozila { get; set; }
    }
}