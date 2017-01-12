using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoServis.Models
{
    public class ZamjenskoVozilo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string RegOznaka { get; set; }

        public bool Dostupno { get; set; }

        public virtual ICollection<Popravak> Popravci { get; set; }
    }
}