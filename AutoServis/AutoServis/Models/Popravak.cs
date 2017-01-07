using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoServis.Models
{
    public class Popravak
    {
        public int Id { get; set; }

        public DateTime DatumVrijeme { get; set; }

        [StringLength(500)]
        public string DodatniOpis { get; set; }

        // Strani kljucevi...
        public int KorisnikId { get; set; }

        public int VoziloId { get; set; }

        public int ServiserId { get; set; }

        public int ZamjenskoVoziloId { get; set; }

        // Reference...
        public virtual Korisnik Korisnik { get; set; }

        public virtual Vozilo Vozilo { get; set; }

        public virtual Serviser Serviser { get; set; }

        public virtual ZamjenskoVozilo ZamjenskoVozilo { get; set; }

        public virtual ICollection<Usluga> Usluge { get; set; }
    }
}