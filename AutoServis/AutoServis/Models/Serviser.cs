using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoServis.Models
{
    [Table("Serviser")]
    public class Serviser : ApplicationUser
    {
        public virtual ICollection<Popravak> Popravci { get; set; }
    }
}