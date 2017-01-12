using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoServis.Models;

namespace AutoServis.ViewModels
{
    public class DodajVoziloViewModel
    {
        public string RegOznaka { get; set; }

        public string GodProizv { get; set; }

        public IEnumerable<TipVozila> TipoviVozila { get; set; }

        public int TipVozilaId { get; set; }
    }
}