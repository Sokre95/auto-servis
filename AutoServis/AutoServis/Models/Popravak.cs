using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace AutoServis.Models
{
    [Table("Popravak")]
    public class Popravak
    {
        public int Id { get; set; }

        public DateTime DatumVrijeme { get; set; }

        [StringLength(500)]
        public string DodatniOpis { get; set; }

        // Strani kljucevi...
        public string KorisnikId { get; set; }

        public string VoziloId { get; set; }

        public string ServiserId { get; set; }

        // Reference...
        public virtual Korisnik Korisnik { get; set; }

        public virtual Vozilo Vozilo { get; set; }

        public virtual Serviser Serviser { get; set; }

        public virtual ZamjenskoVozilo ZamjenskoVozilo { get; set; }

        public virtual ICollection<Usluga> Usluge { get; set; }
    }
}