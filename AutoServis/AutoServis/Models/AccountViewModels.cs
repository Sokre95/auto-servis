using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoServis.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Display(Name = "Zapamti me?")]
        public bool RememberMe { get; set; }
    }

	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Unesite email.")]
		[EmailAddress(ErrorMessage = "Email adresa nije u ispravnom formatu.")]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "{0} mora biti najmanje {2} znakova.", MinimumLength = 6)]
		[DataType(DataType.Password, ErrorMessage = "Lozinka mora sadrzavati to to i to.")]
		[Display(Name = "Lozinka")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Potvrdite lozinku")]
		[Compare("Password", ErrorMessage = "Lozinka i potvrđena lozinka se ne podudaraju.")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Unesite ime.")]
		//[RegularExpression(@"[A-Z][\p{Ll}a-z]", ErrorMessage = "Prvo slovo imena mora biti veliko.")]
		[StringLength(100)]
	    public string Ime { get; set; }

		[Required(ErrorMessage = "Unesite prezime.")]
		//[RegularExpression(@"^[A-Z][\p{L}a-z]*$", ErrorMessage = "Prvo slovo prezimena mora biti veliko.")]
		[StringLength(100)]
		public string Prezime { get; set; }

		[Display(Name="Broj telefona")]
		[RegularExpression(@"[0-9]{8,12}", ErrorMessage = "Broj telefona mora sadržavati samo brojeve i biti dugačak između 8 i 12 znamenaka.")]
		public string BrTel { get; set; }
    }

	public class ServiserViewModel : RegisterViewModel
	{
	}

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
