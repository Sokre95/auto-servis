using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoServis.Controllers
{
	[Authorize(Roles = "Korisnik")]
    public class KorisnikController : Controller
    {
        // GET: Korisnik
        public ActionResult Index()
        {
            return View();
        }
    }
}