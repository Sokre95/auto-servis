using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoServis.Models;
using AutoServis.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SelectListItem = System.Web.Mvc.SelectListItem;

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
            var user = (Korisnik) System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var vozila = new List<VoziloViewModel>();

            foreach (var vozilo in user.Vozila)
                vozila.Add(new VoziloViewModel
                {
                    RegOznaka = vozilo.RegOznaka,
                    GodProizv = vozilo.GodProizv,
                    Tip = vozilo.TipVozila.Naziv
                });

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

        public ActionResult Repair()
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var roleId = roleManager.FindByName("Serviser").Id;
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var vozila =
                _context.Vozila.Where(
                    vozilo => vozilo.KorisnikId.Equals(userId));
            var users =
                _context.Users.Where(user => user.Roles.Any(role => role.RoleId.Equals(roleId))).ToList();
            var serviseri = users.AsEnumerable().Select(s => new Serviser
            {
                Ime = s.Ime,
                Prezime = s.Prezime,
                Id = s.Id
            }).ToList();
            var viewModel = new RepairViewModel
            {
                vozila = vozila,
                serviseri = serviseri,
                dostupniTermini = dohvatiSlobodneTermine().Select(datetime => new SelectListItem
                {
                   Value = datetime.ToString(),
                   Text = datetime.ToString()
                })
            };
            return View(viewModel);
        }

        private IEnumerable<DateTime> dohvatiSlobodneTermine()
        {
            var zauzetiTermini =
                _context.Popravci
                    .Where(popravak => popravak.DatumVrijeme > DateTime.Now)
                    .Select(popravak => popravak.DatumVrijeme)
                    .Distinct()
                    .ToList();
            // generiraj termine svakih 20 minuta od 07:00 do 10:00 za 10 dana unaprijed
            
            List<DateTime> termini = new List<DateTime>();
            int terminPeriod = 20; // po 20 minuta su periodi
            int dateBorder = 10;
            DateTime termin = DateTime.Today.AddHours(7);
            for (int day = 0; day < dateBorder; day++)
            {
                termin = termin.AddDays(1);
                if (termin.DayOfWeek.Equals(DayOfWeek.Sunday))
                {
                    dateBorder++;
                    continue;
                }
                for (int minutes = 0; minutes < 9; minutes++)
                {
                    termin = termin.AddMinutes(terminPeriod);
                    termini.Add(termin);
                }
            }
            // termini.RemoveAll(time => zauzetiTermini.Contains(time));
            return termini;
        }
    }
}