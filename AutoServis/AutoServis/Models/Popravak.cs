namespace AutoServis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	
    public class Popravak
    {
        public Popravak()
        {
            DodatnaUsluga = new HashSet<DodatnaUsluga>();
            Usluga = new HashSet<Usluga>();
            ZamjenskoVozilo = new HashSet<ZamjenskoVozilo>();
        }

        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime datumVrijeme { get; set; }

        [StringLength(500)]
        public string dodatniOpis { get; set; }

        public int id_korisnik { get; set; }

        public int id_Vozilo { get; set; }

        public int id_serviser { get; set; }

        public virtual ICollection<DodatnaUsluga> DodatnaUsluga { get; set; }

        public virtual ApplicationUser Korisnik { get; set; }

        public virtual Vozilo Vozilo { get; set; }

        public virtual Serviser Serviser { get; set; }

        public virtual ICollection<Usluga> Usluga { get; set; }

        public virtual ICollection<ZamjenskoVozilo> ZamjenskoVozilo { get; set; }
    }
}
