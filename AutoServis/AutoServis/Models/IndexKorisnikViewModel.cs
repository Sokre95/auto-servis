using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoServis.Models
{
    public class IndexKorisnikViewModel
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }

        public string BrojTel { get; set; }

        public IEnumerable<VoziloViewModel> Vozila { get; set; }
    }
}