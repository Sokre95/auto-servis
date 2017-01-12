using System.Collections.Generic;

namespace AutoServis.ViewModels
{
    public class PopravakViewModel
    {
        public string Vozilo { get; set; }

        public string Serviser { get; set; }

        public ICollection<string> Usluge { get; set; }

        public string DodatniOpis { get; set; }

        public string Termin { get; set; }

        public string Napomena { get; set; }

        public string ZamjenskoVozilo { get; set; }
    }
}