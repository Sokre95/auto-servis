namespace AutoServis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	
    public class Popravak
    {
        public int Id { get; set; }
        
        public DateTime DatumVrijeme { get; set; }

        [StringLength(500)]
        public string DodatniOpis { get; set; }

        public int IdKorisnik { get; set; }

        public int IdVozilo { get; set; }

        public int IdServiser { get; set; }

        public virtual ICollection<DodatnaUsluga> DodatnaUsluga { get; set; }

        public virtual ApplicationUser Korisnik { get; set; }

        public virtual Vozilo Vozilo { get; set; }

        public virtual Serviser Serviser { get; set; }

        public virtual ICollection<Usluga> Usluga { get; set; }

        public virtual ICollection<ZamjenskoVozilo> ZamjenskoVozilo { get; set; }
    }
}
