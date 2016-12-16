using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoServis.Controllers
{
	[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult DodajServisera()
		{
			return HttpNotFound();
		}

		public ActionResult DodajKorisnika()
		{
			return HttpNotFound();
		}
	}
}