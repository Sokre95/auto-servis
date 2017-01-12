using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoServis.Models
{
    public class TipVozila
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public ICollection<Vozilo> Vozila { get; set; }
    }
}