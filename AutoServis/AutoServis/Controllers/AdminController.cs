﻿using System;
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
		
        public ActionResult Index()
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
				var user = new ApplicationUser
				{
					UserName = model.Email,
					Email = model.Email,
					Ime = model.Ime,
					Prezime = model.Prezime,
					BrojTel = model.BrojTel
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
	}
}