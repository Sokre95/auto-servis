using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AutoServis.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

	    public string Ime { get; set; }

		public string Prezime { get; set; }

		[Display(Name="Broj telefona")]
		public string BrojTel { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

	    public DbSet<Administrator> Administratori { get; set; }
		public DbSet<DodatnaUsluga> DodatneUsluge { get; set; }
		public DbSet<Korisnik> Korisnici { get; set; }
		public DbSet<Popravak> Popravci { get; set; }
		public DbSet<Serviser> Serviseri { get; set; }
		public DbSet<Usluga> Usluge { get; set; }
		public DbSet<Vozilo> Vozila { get; set; }
		public DbSet<ZamjenskoVozilo> ZamjenskaVozila { get; set; }
	}
}