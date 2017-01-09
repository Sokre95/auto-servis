using System.Web.Mvc;
using AutoServis.Models;

namespace AutoServis.Controllers
{
    [Authorize(Roles = "Serviser")]
    public class ServiserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}