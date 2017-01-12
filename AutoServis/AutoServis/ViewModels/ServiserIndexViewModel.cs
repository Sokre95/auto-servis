using System.Collections.Generic;

namespace AutoServis.ViewModels
{
    public class ServiserIndexViewModel
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }

        public string BrojTel { get; set; }

        public List<PopravakZaServiseraViewModel> Popravci { get; set; }
    }
}