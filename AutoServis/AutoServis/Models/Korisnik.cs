using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoServis.Models
{
    public class Korisnik : ApplicationUser
    {
        public virtual ICollection<Popravak> Popravak { get; set; }

        public virtual ICollection<Vozilo> Vozilo { get; set; }
    }
}