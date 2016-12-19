using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoServis.Models;
using AutoServis.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace AutoServis.Controllers
{
	[Authorize(Roles = "Korisnik")]
    public class KorisnikController : Controller
    {
        // GET: Korisnik
        public ActionResult Index()
        {
            Korisnik user = (Korisnik)System.Web.HttpContext.Current.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            List<VoziloViewModel> vozila = new List<VoziloViewModel>();

            foreach (var vozilo in user.Vozila)
            {
                vozila.Add(new VoziloViewModel
                {
                    RegOznaka = vozilo.RegOznaka,
                    GodProizv = vozilo.GodProizv,
                    Tip = vozilo.TipVozila.Naziv
                });
            }

            var viewModel = new IndexKorisnikViewModel
            {
                Ime = user.Ime,
                Prezime = user.Prezime,
                BrojTel = user.BrojTel,
                Email = user.Email,
                Vozila = vozila
            };

            return View(viewModel);
        }

		public ActionResult Add()
		{
		    return View();
		}
    }
}