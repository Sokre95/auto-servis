using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoServis.Models;

namespace AutoServis.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;

		public HomeController()
		{
			_context = new ApplicationDbContext();
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Contact()
		{
			var model = _context.Kontakti.First();

			return View(model);
		}
	}
}