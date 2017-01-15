using System;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web.Razor;
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

            if (!context.Roles.Any(r => r.Name == "Korisnik"))
            {
                roleManager.Create(korisnikRole);
            }
            if (!context.Roles.Any(r => r.Name == "Serviser"))
            {
                roleManager.Create(serviserRole);
            }
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(adminRole);
            }
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
            // korisnik
            var korisnik = new Korisnik
            {
                Ime = "Ivan",
                Prezime = "Ivic",
                Email = "user@users.com",
                UserName = "user@users.com",
                PhoneNumber = "0991234568",
                PasswordHash = passwordHasher.HashPassword("123456"),
                LockoutEnabled = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            if (!context.Users.Any(user => user.UserName.Equals("user@users.com")))
            {
                context.Users.AddOrUpdate(korisnik);
                context.SaveChanges();
                userManager.AddToRole(korisnik.Id, "Korisnik");
            }

            // serviser
            var serviser = new Serviser()
            {
                Ime = "Pero",
                Prezime = "Peric",
                Email = "serviser@servis.com",
                UserName = "serviser@servis.com",
                PhoneNumber = "0991234569",
                LockoutEnabled = true,
                PasswordHash = passwordHasher.HashPassword("123456"),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            if (!context.Users.Any(user => user.UserName.Equals("serviser@servis.com")))
            {
                context.Users.AddOrUpdate(serviser);
                context.SaveChanges();
                userManager.AddToRole(serviser.Id, "Serviser");
            }
            //kontakt
            context.Kontakti.AddOrUpdate(kontakt => kontakt.Id, new Kontakt
            {
                Id = 1,
                ImeServisa = "Najbolji mehaničar",
                Adresa = "Trg bana Josipa Jelačića 1",
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
                new Usluga {Id = 2, Opis = "Ugradnja kočionih pločica"},
                new Usluga {Id = 3, Opis = "Izmjena filtera zraka"},
                new Usluga {Id = 4, Opis = "Promjena diskova"},
                new Usluga {Id = 5, Opis = "Podešavanje paljena"},
                new Usluga {Id = 6, Opis = "Izmjena filtera ulja"},
                new Usluga {Id = 7, Opis = "Izmjena zupčastog remena i zatezača"},
                new Usluga {Id = 8, Opis = "Punjenje i kontrola klima uređaja"},
                new Usluga {Id = 9, Opis = "Dijagnostika kvarova"},
                new Usluga {Id = 10, Opis = "Provjera tekućina(hlađenje, kočenje)"},
                new Usluga {Id=11,Opis= "Pregled ispušnog sustava" },
                new Usluga {Id = 12, Opis = "Ultrazvučno čisćenje injektora"}
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
 