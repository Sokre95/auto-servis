using System;
using System.Data.Entity.Migrations;
using System.Linq;
using AutoServis.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AutoServis.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var passwordHasher = new PasswordHasher();

            var korisnikRole = new IdentityRole("Korisnik");
            var serviserRole = new IdentityRole("Serviser");
            var adminRole = new IdentityRole("Admin");
            roleManager.Create(korisnikRole);
            roleManager.Create(serviserRole);
            roleManager.Create(adminRole);
            //admin
            var admin = new ApplicationUser
            {
                Ime = "Marko",
                Prezime = "Horvat",
                Email = "admin@servis.com",
                UserName = "admin@servis.com",
                PhoneNumber = "0991234567",
                LockoutEnabled = true,
                PasswordHash = passwordHasher.HashPassword("123456"),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            if (!context.Users.Any(user => user.UserName.Equals("admin@servis.com")))
            {
                context.Users.AddOrUpdate(admin);
                context.SaveChanges();
                userManager.AddToRole(admin.Id, "Admin");
            }
            // kontakt
            context.Kontakti.AddOrUpdate(kontakt => kontakt.Id, new Kontakt
            {
                Id = 1,
                ImeServisa = "Najbolji mehanicar",
                Adresa = "Trg bana Josipa Jelacica 1",
                Mjesto = "10000 Zagreb",
                Email = "info@servis.com",
                BrojTel = "45555123"
            });
            // tip vozila
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Astra"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Corsa"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Zafira"
            });
            context.SaveChanges();
        }
    }
}