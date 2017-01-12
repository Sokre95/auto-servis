using System;
using System.Collections.Generic;

namespace AutoServis.ViewModels
{
    public class PopravakZaServiseraViewModel
    {
        public string Vozilo { get; set; }

        public string Korisnik { get; set; }

        public ICollection<string> Usluge { get; set; }

        public string DodatniOpis { get; set; }

        public DateTime Termin { get; set; }

        public int Id { get; set; }

        public string ZamjenskoVozilo { get; set; }

        public string Napomena { get; set; }
    }
}