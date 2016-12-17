using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoServis.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

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
			return View();  // Vrati formu
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DodajServisera(ServiserViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser
				{
					UserName = model.Email,
					Email = model.Email,
					Ime = model.Ime,
					Prezime = model.Prezime,
					BrojTel = model.BrTel
				};

				var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

				var result = await userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user.Id, "Serviser");

					return RedirectToAction("Index");
				}
			}

			return View(model);
		}

		public ActionResult PodaciOServisu()
		{
			return HttpNotFound();
		}

		public ActionResult KontakServisa()
		{
			return HttpNotFound();
		}

		public ActionResult DodajKorisnika()
		{
			return HttpNotFound();
		}
	}
}