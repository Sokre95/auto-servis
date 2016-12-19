using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoServis.Models
{
    public class KorisnikViewModel : RegisterViewModel
    {
        [Required(ErrorMessage = "Unesite godinu proizvodnje vozila.")]
        [Display(Name = "Godina proizvodnje")]
        public string GodProizv { get; set; }
        
        [Required(ErrorMessage = "unesite registarsku oznaku vozila.")]
        [Display(Name = "Registarska oznaka")]
        public string RegOznaka { get; set; }

        public ICollection<TipVozila> TipoviVozila { get; set; }

        [Display(Name = "Tip vozila")]
        public int TipVozilaId { get; set; }
    }
}