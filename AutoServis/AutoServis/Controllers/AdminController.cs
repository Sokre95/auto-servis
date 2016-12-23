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
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
	        var roleId = roleManager.FindByName("Serviser").Id;

            // Dohvati servisere iz baze po ulozi servisera
            var serviseri = _context.Users
                .Where(x => x.Roles.Any(role => role.RoleId == roleId))
                .ToList().Cast<Serviser>().ToList();

            var listaServisera = new List<KorisniciZaAdminaViewModel>();

            foreach(var serviser in serviseri)
            {
                listaServisera.Add(new KorisniciZaAdminaViewModel
                {
                    Id = serviser.Id,
                    Ime = serviser.Ime,
                    Prezime = serviser.Prezime,
                    BrojTel = serviser.PhoneNumber,
                    Email = serviser.Email
                });
            }

            return View(listaServisera);
	    }

	    public ActionResult Korisnici()
	    {
	        return View();
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
	        //var serviser = (Serviser)_context.Users.FirstOrDefault(u => u.Id == Id);

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

		public ActionResult DodajKorisnika()
		{
			return HttpNotFound();
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

        public ActionResult Osvjezi()
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var roleId = roleManager.FindByName("Serviser").Id;

            // Dohvati servisere iz baze po ulozi servisera
            var serviseri = _context.Users
                .Where(x => x.Roles.Any(role => role.RoleId == roleId))
                .ToList().Cast<Serviser>().ToList();

            var listaServisera = new List<KorisniciZaAdminaViewModel>();

            foreach (var serviser in serviseri)
            {
                listaServisera.Add(new KorisniciZaAdminaViewModel
                {
                    Id = serviser.Id,
                    Ime = serviser.Ime,
                    Prezime = serviser.Prezime,
                    BrojTel = serviser.PhoneNumber,
                    Email = serviser.Email
                });
            }

            return PartialView("_Korisnici", listaServisera);
        }
	}
}