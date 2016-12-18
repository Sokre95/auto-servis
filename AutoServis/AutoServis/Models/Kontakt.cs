using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoServis.Models
{
	public class Kontakt
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		[Display(Name = "Ime servisa")]
		public string ImeServisa { get; set; }

		[Required]
		[Display(Name = "Broj telefona")]
		[RegularExpression(@"^[0-9]{8,12}", ErrorMessage = "Broj telefona mora sadržavati samo brojeve i biti dugačak između 8 i 12 znamenaka.")]
		public string BrojTel { get; set; }

		[Required(ErrorMessage = "Unesite adresu.")]
		public string Adresa { get; set; }

		[Required(ErrorMessage = "Unesite mjesto i poštanski broj.")]
		public string Mjesto { get; set; }

		[Required]
		[Display(Name = "Kontakt email")]
		[EmailAddress(ErrorMessage = "Email adresa nije u ispravnom formatu.")]
		public string Email { get; set; }
	}
}