using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoServis.Models;

namespace AutoServis.ViewModels
{
    public class DodajVoziloViewModel
    {
        [Required(ErrorMessage = "unesite registarsku oznaku vozila.")]
        [Display(Name = "Registarska oznaka")]
        public string RegOznaka { get; set; }

        [Required(ErrorMessage = "Unesite godinu proizvodnje vozila.")]
        [Display(Name = "Godina proizvodnje")]
        public string GodProizv { get; set; }

        public IEnumerable<TipVozila> TipoviVozila { get; set; }

        [Required(ErrorMessage = "Odaberite tip vozila")]
        [Display(Name = "Tip vozila")]
        public int TipVozilaId { get; set; }
    }
}