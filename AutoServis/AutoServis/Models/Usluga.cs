using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoServis.Models
{
    public class Usluga
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Opis { get; set; }

        public virtual ICollection<Popravak> Popravci { get; set; }
    }
}