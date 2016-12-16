using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoServis.Controllers
{
	[Authorize(Roles = "Serviser")]
    public class ServiserController : Controller
    {
        // GET: Serviser
        public ActionResult Index()
        {
            return View();
        }
    }
}