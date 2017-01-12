using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoServis.Models;

namespace AutoServis.ViewModels
{
    public class KorisnikViewModel : RegisterViewModel
    {
        [RegularExpression("^[0-9]*$", ErrorMessage = "Godina proizvodnje smije sadržavati samo brojeve")]
        [Range(1920, 2017, ErrorMessage = "Unesite godinu proizvodnje između 1920. i 2017. godine.")]
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