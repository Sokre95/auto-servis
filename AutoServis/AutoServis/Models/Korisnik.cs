using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoServis.Models
{
    [Table("Korisnik")]
    public class Korisnik : ApplicationUser
    {
        public virtual ICollection<Popravak> Popravci { get; set; }

        public virtual ICollection<Vozilo> Vozila { get; set; }
    }
}