using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoServis.Models;
using AutoServis.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AutoServis.Controllers
{
	[Authorize(Roles = "Admin")]
    public class AdminController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AdminController()
		{
			_context = new ApplicationDbContext();
		}

	    protected override void Dispose(bool disposing)
	    {
            _context.Dispose();
	    }

	    public ActionResult Index()
        {
            return View();
        }

	    public ActionResult Serviseri()
	    {
            return View(DohvatiKorisnikePoUlozi("serviser"));
	    }

	    public ActionResult Korisnici()
	    {
	        return View(DohvatiKorisnikePoUlozi("Korisnik"));
	    }

        public ActionResult DodajServisera()
        {
            return View();
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DodajServisera(ServiserViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new Serviser
				{
					UserName = model.Email,
					Email = model.Email,
					Ime = model.Ime,
					Prezime = model.Prezime,
					PhoneNumber = model.BrojTel
				};

				var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

				var result = await userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user.Id, "Serviser");

					return RedirectToAction("Serviseri");
				}
			}

			return View(model);
		}

        public ActionResult DodajKorisnika()
        {
            var tipoviVozila = _context.TipoviVozila.ToList();

            var viewModel = new KorisnikViewModel
            {
                TipoviVozila = tipoviVozila
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DodajKorisnika(KorisnikViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Korisnik
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    PhoneNumber = model.BrojTel
                };

                var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var result = await userManager.CreateAsync(user, model.Password);

                var vozilo = new Vozilo
                {
                    GodProizv = model.GodProizv,
                    RegOznaka = model.RegOznaka,
                    TipVozilaId = model.TipVozilaId,
                    KorisnikId = user.Id
                };

                _context.Vozila.Add(vozilo);
                await _context.SaveChangesAsync();

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user.Id, "Korisnik");

                    return RedirectToAction("Korisnici");
                }
            }

            return View(model);
        }

        public ActionResult Izmjeni(string Id)
        {
            var korisnik = _context.Users.FirstOrDefault(u => u.Id == Id);

            var uloge = korisnik.Roles;

            foreach(var uloga in uloge)
            {
                var imeUloge = _context.Roles.FirstOrDefault(r => r.Id == uloga.RoleId).Name;

                if (imeUloge.Equals("Serviser"))
                {
                    return RedirectToAction("IzmjeniServisera", (Serviser)korisnik);
                }
                else if (imeUloge.Equals("Korisnik"))
                {
                    return RedirectToAction("IzmjeniKorisnika", (Korisnik)korisnik);
                }
            }

            return RedirectToAction("Serviseri");
        }

        public void IzmjeniKorisnika(Korisnik korisnik)
        {

        }

	    public ActionResult IzmjeniServisera(Serviser serviser)
	    {
	        var viewModel = new ServiserViewModel
	        {
                Email = serviser.Email,
                Ime = serviser.Ime,
                Prezime = serviser.Prezime,
                BrojTel = serviser.PhoneNumber
	        };

	        return View(viewModel);
	    }

		public ActionResult KontaktServisa()
		{
		    var model = _context.Kontakti.First();

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult KontaktServisa(Kontakt model)
		{
		    if (ModelState.IsValid)
		    {
		        var dataFromDB = _context.Kontakti.First();

		        dataFromDB.Adresa = model.Adresa;
		        dataFromDB.BrojTel = model.BrojTel;
		        dataFromDB.Email = model.Email;
		        dataFromDB.ImeServisa = model.ImeServisa;
		        dataFromDB.Mjesto = model.Mjesto;

                _context.SaveChanges();

                return RedirectToAction("Contact", "Home");
            }

		    return View(model);
		}

        [HttpPost]
        public ActionResult Izbrisi(string Id)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Id == Id);

            try
            {
                _context.Users.Remove(userInDb);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                return Json(new { success = false });
            }

            return Json(new { success = true });
        }

        public ActionResult OsvjeziServisere()
        {
            return PartialView("_Korisnici", DohvatiKorisnikePoUlozi("Serviser"));
        }

        public ActionResult OsvjeziKorisnike()
        {
            return PartialView("_Korisnici", DohvatiKorisnikePoUlozi("Korisnik"));
        }

        private IEnumerable<KorisniciZaAdminaViewModel> DohvatiKorisnikePoUlozi(string uloga)
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var roleId = roleManager.FindByName(uloga).Id;

            IEnumerable<ApplicationUser> korisnici = _context.Users
                        .Where(u => u.Roles.Any(r => r.RoleId == roleId))
                        .ToList();

            //if(uloga.Equals("Korisnik"))
            //{
            //    korisnici = korisnici.Cast<Korisnik>().ToList();
            //}
            //else if(uloga.Equals("Korisnik"))
            //{
            //    korisnici = korisnici.Cast<Serviser>().ToList();
            //}

            var listaKorisnika = new List<KorisniciZaAdminaViewModel>();

            foreach (var korisnik in korisnici)
            {
                listaKorisnika.Add(new KorisniciZaAdminaViewModel
                {
                    Id = korisnik.Id,
                    Ime = korisnik.Ime,
                    Prezime = korisnik.Prezime,
                    BrojTel = korisnik.PhoneNumber,
                    Email = korisnik.Email
                });
            }

            return listaKorisnika;
        }
	}
}