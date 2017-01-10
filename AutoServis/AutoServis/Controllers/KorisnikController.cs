using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using AutoServis.Models;
using AutoServis.Services;
using AutoServis.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            var korisnik = (Korisnik) System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var vozila = new List<VoziloViewModel>();
            foreach (var vozilo in korisnik.Vozila)
                vozila.Add(new VoziloViewModel
                {
                    RegOznaka = vozilo.RegOznaka,
                    GodProizv = vozilo.GodProizv,
                    Tip = vozilo.TipVozila.Naziv
                });
            var popravciModel = new List<PopravakViewModel>();
            var popravci = _context.Popravci.Where(popravak => popravak.KorisnikId.Equals(korisnik.Id)).ToList();
            foreach (var popravak in popravci)
            {
                var s = _context.Users.First(user => popravak.ServiserId.Equals(user.Id));
                var serviser = s.Ime + " " + s.Prezime;
                var v = _context.Vozila.First(t => popravak.VoziloId.Equals(t.Id.ToString()));
                var vozilo = v.RegOznaka + " - " + v.TipVozila.Naziv;
                popravciModel.Add(new PopravakViewModel
                {
                    Serviser = serviser,
                    Vozilo = vozilo,
                    Usluge = popravak.Usluge.Select(usluga => usluga.Opis).ToList(),
                    DodatniOpis = popravak.DodatniOpis
                });
            }

            var viewModel = new IndexKorisnikViewModel
            {
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                BrojTel = korisnik.PhoneNumber,
                Email = korisnik.Email,
                Vozila = vozila,
                Popravci = popravciModel
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
            if (ModelState.IsValid)
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
            }
            return RedirectToAction("Index", "Korisnik");
        }

        public ActionResult Repair()
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var vozila =
                _context.Vozila.Where(
                    vozilo => vozilo.KorisnikId.Equals(userId)).ToList();
            var viewModel = new RepairViewModel
            {
                Vozila = vozila.Select(vozilo => new SelectListItem
                {
                    Value = vozilo.Id.ToString(),
                    Text = vozilo.TipVozila.Naziv + " - " + vozilo.RegOznaka
                }).ToList(),
                Serviseri = DohvatiSlobodneServisere().Select(serviser => new SelectListItem
                {
                    Text = serviser.Ime + " " + serviser.Prezime,
                    Value = serviser.Id.ToString()
                }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Repair(RepairViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<DateTime> dostupniTermini;
                if (viewModel.OdabraniServiser != null)
                    dostupniTermini =
                        DohvatiSlobodneTermine(viewModel.OdabraniServiser);
                else
                    dostupniTermini = DohvatiSlobodneTermine();
                var model = new RepairOptionsViewModel
                {
                    OdabranoVozilo = viewModel.OdabranoVozilo,
                    OdabraniServiser = viewModel.OdabraniServiser,
                    DostupniTermini = dostupniTermini.Select(datetime => new SelectListItem
                    {
                        Value = datetime.ToString(),
                        Text = datetime.ToString()
                    }).ToList(),
                    Usluge = _context.Usluge,
                    ZamjenskaVozila = _context.ZamjenskaVozila.Where(vozilo => vozilo.Dostupno.Equals(true))
                };
                return PartialView("_OpcijaPopravka", model);
            }
            return View("Repair", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRepair(RepairOptionsViewModel viewModel)
        {
            if (viewModel.OdabraneUsluge.Count(usluga => !usluga.Equals("false")).Equals(0))
                ModelState.AddModelError("odabraneUslugeError", "Odaberite barem jednu uslugu");
            if (ModelState.IsValid)
            {
                ICollection<string> odabraneUsluge = viewModel.OdabraneUsluge.ToList();
                ICollection<Usluga> usluge =
                    _context.Usluge.Where(usluga => odabraneUsluge.Contains(usluga.Id.ToString())).ToList();
                string serviserId;
                if (viewModel.OdabraniServiser != null)
                    serviserId = viewModel.OdabraniServiser;
                else
                    serviserId = DohvatiSlobodneServisere().FirstOrDefault().Id;
                var korisnikId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                var popravak = new Popravak
                {
                    KorisnikId = korisnikId,
                    VoziloId = viewModel.OdabranoVozilo,
                    ServiserId = serviserId,
                    DatumVrijeme = DateTime.Parse(viewModel.OdabraniTermin),
                    Usluge = usluge,
                    DodatniOpis = viewModel.DodatanOpis
                };

                if (viewModel.ZamjenskoVozilo.Equals(true))
                {
                    var zamjenskoVozilo = _context.ZamjenskaVozila.First();
                    zamjenskoVozilo.Dostupno = false;
                    popravak.ZamjenskoVozilo = zamjenskoVozilo;
                }
                _context.Popravci.Add(popravak);
                _context.SaveChanges();

                return RedirectToAction("RepairInfo", popravak);
            }
            return PartialView("_OpcijaPopravka", viewModel);
        }

        public ActionResult RepairInfo(Popravak p)
        {
            var popravak = _context.Popravci.Find(p.Id);
            var serviser = _context.Users.First(u => u.Id.Equals(popravak.ServiserId));
            var vozilo = _context.Vozila.First(v => popravak.VoziloId.Equals(v.Id.ToString()));
            string zamjensko = null;
            if (popravak.ZamjenskoVozilo != null)
                zamjensko = popravak.ZamjenskoVozilo.RegOznaka;
            var infoModel = new RepairInfoViewModel
            {
                Serviser = serviser.Ime + " " + serviser.Prezime,
                Vozilo = vozilo.TipVozila.Naziv + " " + vozilo.RegOznaka,
                Usluge = popravak.Usluge.Select(usluga => usluga.Opis).ToList(),
                OdabraniTermin = popravak.DatumVrijeme.ToString(),
                DodatanOpis = popravak.DodatniOpis,
                ZamjenskoVozilo = zamjensko,
                Kontakt = _context.Kontakti.First()
            };
            var message = new MailMessage();
            message.To.Add(new MailAddress(_context.Users.Find(popravak.KorisnikId).Email));
            message.From = new MailAddress("najbolji.mehanicar.noreply@gmail.com");
            message.Subject = "Prijavili ste termin popravka";
            message.Body = PartialToStringRenderer.RenderViewToString(ControllerContext,
                "~/Views/Korisnik/PopravakInfoMail.cshtml", infoModel);
            message.IsBodyHtml = true;

            var mailer = Mailer.Create("smtp.gmail.com", 587, "serviserinfo1@gmail.com", "serviser123", true);
            mailer.SendMail(message);
            return PartialView("PopravakInfoWeb", infoModel);
        }

        private IEnumerable<Serviser> DohvatiSlobodneServisere()
        {
            var roleManager =
                new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var roleId = roleManager.FindByName("Serviser").Id;
            // korisniku ne smijemo za odabair ponuditi sve servisere vec samo dostupne....             
            // serviser je zauzet samo ako je zauzet za sve moguce termine
            var serviseri =
                _context.Users.Where(user => user.Roles.Any(role => role.RoleId.Equals(roleId))).AsEnumerable();
            IEnumerable<DateTime> sviMoguciTermini = generirajTermine();
            IEnumerable<Popravak> popravci =
                _context.Popravci.Where(popravak => popravak.DatumVrijeme.Day > DateTime.Today.Day).ToList();
            var zauzetiServiseri =
                serviseri.Where(
                    serviser => popravci
                        .Count(popravak => popravak.Serviser.Equals(serviser))
                        .Equals(sviMoguciTermini.Count()));
            serviseri = serviseri.Except(zauzetiServiseri).ToList();
            var serviseriModel = serviseri.Select(u => new Serviser
            {
                Ime = u.Ime,
                Prezime = u.Prezime,
                Id = u.Id
            }).ToList();
            return serviseriModel;
        }

        private IEnumerable<DateTime> DohvatiSlobodneTermine(string serviserId)
        {
            IEnumerable<DateTime> zauzetiTermini =
                _context.Popravci
                    .Where(
                        popravak =>
                            popravak.ServiserId.ToString().Equals(serviserId) &
                            (popravak.DatumVrijeme.Day > DateTime.Today.Day))
                    .Select(popravak => popravak.DatumVrijeme);
            var termini = generirajTermine().Except(zauzetiTermini).AsEnumerable();
            return termini;
        }

        private IEnumerable<DateTime> DohvatiSlobodneTermine()
        {
            var roleManager =
                new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var roleId = roleManager.FindByName("Serviser").Id;
            var serviseri =
                _context.Users.Where(user => user.Roles.Any(role => role.RoleId.Equals(roleId))).ToList();
            var termini = new List<DateTime>();
            serviseri.ForEach(
                serviser => termini.AddRange(DohvatiSlobodneTermine(serviser.Id).ToList()));
            return termini.Distinct();
        }

        private List<DateTime> generirajTermine()
        {
            // generira termine svakih 20 minuta od 07:00 do 10:00 za 10 dana unaprijed
            var termini = new List<DateTime>();
            var terminPeriod = 20; // po 20 minuta su periodi
            var dateBorder = 10;
            var termin = DateTime.Today.AddHours(7);
            for (var day = 0; day < dateBorder; day++)
            {
                termin = termin.AddDays(1);
                if (termin.DayOfWeek.Equals(DayOfWeek.Sunday))
                {
                    dateBorder++;
                    continue;
                }
                for (var minutes = 0; minutes < 9; minutes++)
                {
                    termini.Add(termin);
                    termin = termin.AddMinutes(terminPeriod);
                }
                termin = termin.AddMinutes(-180);
            }
            return termini;
        }
    }
}