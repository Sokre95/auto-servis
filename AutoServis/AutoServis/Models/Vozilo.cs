namespace AutoServis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vozilo")]
    public partial class Vozilo
    {
        public Vozilo()
        {
            Popravak = new HashSet<Popravak>();
        }

        public int id { get; set; }

        public DateTime? godProizv { get; set; }

        [StringLength(10)]
        public string regOznaka { get; set; }

        public int id_korisnik { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        public virtual ICollection<Popravak> Popravak { get; set; }
    }
}
