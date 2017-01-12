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
    [Authorize(Roles = "Serviser")]
    public class ServiserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var serviser = (Serviser) System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var popravci = serviser.Popravci.Where(popravak => popravak.DatumVrijeme.Date.Equals(DateTime.Today));
            var viewModel = new ServiserIndexViewModel
            {
                Ime = serviser.Ime,
                Prezime = serviser.Prezime,
                BrojTel = serviser.PhoneNumber,
                Email = serviser.Email,
                Popravci = ConvertRepairsToRepairsViewModels(popravci)
            };
            return View(viewModel);
        }

        public ActionResult IncomingRepairs()
        {
            var serviser = (Serviser) System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var popravci = serviser.Popravci.Where(popravak => DateTime.Compare(popravak.DatumVrijeme, DateTime.Now) > 0);
            var viewModel = new ServiserIncomingAndActiveRepairsViewModel
            {
                Popravci = ConvertRepairsToRepairsViewModels(popravci)
            };
            return View(viewModel);
        }

        public ActionResult ActiveRepairs()
        {
            var serviser = (Serviser) System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var popravci =
                serviser.Popravci.Where(
                    popravak =>
                            (DateTime.Compare(popravak.DatumVrijeme, DateTime.Now) < 0) & popravak.Active.Equals(true));
            _context.SaveChangesAsync();

            var viewModel = new ServiserIncomingAndActiveRepairsViewModel
            {
                Popravci = ConvertRepairsToRepairsViewModels(popravci)
            };
            return View(viewModel);
        }

        private List<PopravakZaServiseraViewModel> ConvertRepairsToRepairsViewModels(IEnumerable<Popravak> popravci)
        {
            var popravciModel = new List<PopravakZaServiseraViewModel>();
            foreach (var popravak in popravci)
            {
                var v = _context.Vozila.First(t => popravak.VoziloId.Equals(t.Id.ToString()));
                var vozilo = v.RegOznaka + " - " + v.TipVozila.Naziv;
                var popravakViewModel = new PopravakZaServiseraViewModel
                {
                    Korisnik = popravak.Korisnik.Ime + " " + popravak.Korisnik.Prezime,
                    Vozilo = vozilo,
                    Usluge = popravak.Usluge.Select(usluga => usluga.Opis).ToList(),
                    DodatniOpis = popravak.DodatniOpis,
                    Termin = popravak.DatumVrijeme,
                    Id = popravak.Id,
                    Napomena = popravak.Napomena
                };
                if (popravak.ZamjenskoVozilo != null)
                    popravakViewModel.ZamjenskoVozilo = popravak.ZamjenskoVozilo.RegOznaka;
                popravciModel.Add(popravakViewModel);
            }
            return popravciModel;
        }

        [HttpGet]
        public ActionResult EditRepair(int popravakId)
        {
            var popravak = _context.Popravci.Find(popravakId);

            var viewmodel = new EditPopravakViewmodel
            {
                OdabraneUsluge = popravak.Usluge.Select(usluga => usluga.Id.ToString()).ToList(),
                Usluge = _context.Usluge,
                DodatanOpis = popravak.DodatniOpis,
                ZamjenskaVozila = _context.ZamjenskaVozila.Where(zv => zv.Dostupno.Equals(true)).ToList(),
                IdPopravak = popravak.Id,
                Napomena = popravak.Napomena
            };
            if (popravak.ZamjenskoVozilo != null)
            {
                viewmodel.ZamjenskoVozilo = popravak.ZamjenskoVozilo.Id.ToString();
                viewmodel.ZamjenskaVozila.Add(popravak.ZamjenskoVozilo);
            }
            return View("EditRepair", viewmodel);
        }

        [HttpPost]
        public ActionResult EditRepair(EditPopravakViewmodel viewmodel)
        {
            if (ModelState.IsValid)
            {
                ICollection<Usluga> usluge =
                    _context.Usluge.Where(usluga => viewmodel.OdabraneUsluge.Contains(usluga.Id.ToString())).ToList();
                var popravak = _context.Popravci.Find(viewmodel.IdPopravak);
                popravak.Usluge.Clear();
                popravak.Usluge = usluge;
                popravak.DodatniOpis = viewmodel.DodatanOpis;
                popravak.Napomena = viewmodel.Napomena;
                if (viewmodel.ZamjenskoVozilo != null)
                {
                    popravak.ZamjenskoVozilo.Dostupno = true;
                    var zamjenskoVozilo = _context.ZamjenskaVozila.Find(int.Parse(viewmodel.ZamjenskoVozilo));
                    zamjenskoVozilo.Dostupno = false;
                    popravak.ZamjenskoVozilo = zamjenskoVozilo;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Serviser");
            }
            return View("EditRepair", viewmodel);
        }

        [HttpPost]
        public ActionResult ArchiveRepair()
        {
            var popravak = _context.Popravci.Find(int.Parse(Request["popravakId"]));
            var zamjenskoVraceno = Request["zamjenskoVraceno"];
            if (!zamjenskoVraceno.Equals("false"))
                _context.ZamjenskaVozila.Find(popravak.ZamjenskoVozilo.Id).Dostupno = true;
            _context.Popravci.Find(popravak.Id).Active = false;
            _context.SaveChanges();

            return RedirectToAction("Archive", "Serviser");
        }

        public ActionResult Archive()
        {
            var arhiviraniPopravci = _context.Popravci.Where(popravak => popravak.Active.Equals(false)).ToList();
            var arhPopViewModel = ConvertRepairsToRepairsViewModels(arhiviraniPopravci);
            return View(arhPopViewModel);
        }

        public ActionResult PrintRepairForm()
        {
            throw new NotImplementedException();
        }

        public ActionResult IndexZamjenskaVozila()
        {
            var model = new ZamjenskaVozilaViewModel
            {
                Vozila = _context.ZamjenskaVozila.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditZamjenskoVozilo(ZamjenskaVozilaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var odabranoVozilo = _context.ZamjenskaVozila.Find(viewModel.Odabrano);
                if (odabranoVozilo.Dostupno.Equals(true))
                {
                    odabranoVozilo.Dostupno = false;
                }
                else
                {
                    odabranoVozilo.Dostupno = true;
                }
                _context.SaveChanges();
            }
            return RedirectToAction("IndexZamjenskaVozila");
        }
    }
}