using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoServis.Models;

namespace AutoServis.ViewModels
{
    public class DodajVoziloViewModel
    {
        [StringLength(10, ErrorMessage = "Registarska oznaka moze sadrzavati najvise 10 znakova")]
        [Required(ErrorMessage = "Unesite registarsku oznaku vozila")]
        [Display(Name = "Registarska oznaka")]
        public string RegOznaka { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Godina proizvodnje smije sadržavati samo brojeve")]
        [Required(ErrorMessage = "Unesite godinu proizvodnje vozila")]
        [Range(1920, 2017, ErrorMessage = "Unesite godinu proizvodnje između 1920. i 2017. godine")]
        [Display(Name = "Godina proizvodnje")]
        public string GodProizv { get; set; }

        public IEnumerable<TipVozila> TipoviVozila { get; set; }

        [Required(ErrorMessage = "Odaberite tip vozila")]
        [Display(Name = "Tip vozila")]
        public int TipVozilaId { get; set; }
    }
}