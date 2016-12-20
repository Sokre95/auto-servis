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
	    private readonly ApplicationDbContext _context;

        public KorisnikController()
        {
            _context = new ApplicationDbContext();    
        }

	    protected override void Dispose(bool disposing)
	    {
            _context.Dispose();
	    }

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
                BrojTel = user.PhoneNumber,
                Email = user.Email,
                Vozila = vozila
            };

            return View(viewModel);
        }

		public ActionResult Add()
		{

		    var tipoviVozila = _context.TipoviVozila.ToList();

		    var viewModel = new DodajVoziloViewModel
		    {
		        TipoviVozila = tipoviVozila
		    };

		    return View(viewModel);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
	    public ActionResult Add(DodajVoziloViewModel model)
	    {
	        var vozilo = new Vozilo
	        {
	            GodProizv = model.GodProizv,
	            RegOznaka = model.RegOznaka,
	            TipVozilaId = model.TipVozilaId,
	            KorisnikId = System.Web.HttpContext.Current.User.Identity.GetUserId()
	        };

	        _context.Vozila.Add(vozilo);
	        _context.SaveChanges();

            return RedirectToAction("Index", "Korisnik");
	    }
    }
}