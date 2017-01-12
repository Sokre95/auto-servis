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
            AutomaticMigrationsEnabled = true;
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
                Prezime = "Markovic",
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
            //kontakt
            context.Kontakti.AddOrUpdate(kontakt => kontakt.Id, new Kontakt
            {
                Id = 1,
                ImeServisa = "Najbolji mehanilar",
                Adresa = "Trg bana Josipa Jela�i�a 1",
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
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Agila"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Tigra"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Insignia"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Kaddet"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Ampera"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Ascona"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Vectra"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Calibra"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Cascada"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Omega"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Meriva"
            });
            context.TipoviVozila.AddOrUpdate(v => v.Naziv, new TipVozila
            {
                Naziv = "Vivaro"
            });
            // usluge
            Usluga[] usluge =
            {
                new Usluga {Id = 1, Opis = "Izmjena ulja motora"},
                new Usluga {Id = 2, Opis = "Ugradnja ko�ionih plo�ica"},
                new Usluga {Id = 3, Opis = "Izmjena filtera zraka"},
                new Usluga {Id = 4, Opis = "Promjena diskova"},
                new Usluga {Id = 5, Opis = "Pode�avanje paljena"},
                new Usluga {Id = 6, Opis = "Izmjena filtera ulja"},
                new Usluga {Id = 7, Opis = "Izmjena zup�astog remena i zateza�a"},
                new Usluga {Id = 8, Opis = "Punjenje i kontrola klima ure�aja"},
                new Usluga {Id = 9, Opis = "Dijagnostika kvarova"},
                new Usluga {Id = 10, Opis = "Provjera teku�ina(hla�enje, ko�enje)"},
                new Usluga {Id = 11, Opis = "Izmjena zup�astog remena i zateza�a"},
                new Usluga {Id = 12, Opis = "Ultrazvu�no �i��enje injektora"}
            };
            context.Usluge.AddOrUpdate(usluge);
            // zamjenska vozila
            context.ZamjenskaVozila.AddOrUpdate(vozilo => vozilo.Id, new ZamjenskoVozilo
            {
                Id = 1,
                Dostupno = true,
                RegOznaka = "ZG-1000-ZV"
            });
            context.ZamjenskaVozila.AddOrUpdate(vozilo => vozilo.Id, new ZamjenskoVozilo
            {
                Id = 2,
                Dostupno = true,
                RegOznaka = "ZG-1001-ZV"
            });
            context.ZamjenskaVozila.AddOrUpdate(vozilo => vozilo.Id, new ZamjenskoVozilo
            {
                Id = 3,
                Dostupno = true,
                RegOznaka = "ZG-1002-ZV"
            });
            context.ZamjenskaVozila.AddOrUpdate(vozilo => vozilo.Id, new ZamjenskoVozilo
            {
                Id = 4,
                Dostupno = true,
                RegOznaka = "ZG-1003-ZV"
            });
            context.ZamjenskaVozila.AddOrUpdate(vozilo => vozilo.Id, new ZamjenskoVozilo
            {
                Id = 5,
                Dostupno = true,
                RegOznaka = "ZG-1004-ZV"
            });
            context.ZamjenskaVozila.AddOrUpdate(vozilo => vozilo.Id, new ZamjenskoVozilo
            {
                Id = 6,
                Dostupno = true,
                RegOznaka = "ZG-1005-ZV"
            });
            context.ZamjenskaVozila.AddOrUpdate(vozilo => vozilo.Id, new ZamjenskoVozilo
            {
                Id = 7,
                Dostupno = true,
                RegOznaka = "ZG-1006-ZV"
            });
            context.ZamjenskaVozila.AddOrUpdate(vozilo => vozilo.Id, new ZamjenskoVozilo
            {
                Id = 8,
                Dostupno = true,
                RegOznaka = "ZG-1007-ZV"
            });
            context.ZamjenskaVozila.AddOrUpdate(vozilo => vozilo.Id, new ZamjenskoVozilo
            {
                Id = 9,
                Dostupno = true,
                RegOznaka = "ZG-1008-ZV"
            });
            context.ZamjenskaVozila.AddOrUpdate(vozilo => vozilo.Id, new ZamjenskoVozilo
            {
                Id = 10,
                Dostupno = true,
                RegOznaka = "ZG-1009-ZV"
            });
            context.SaveChanges();
        }
    }
}