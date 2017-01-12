using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoServis.Models;

namespace AutoServis.ViewModels
{
    public class RepairInfoViewModel
    {
        public string Serviser { get; set; }
        public string Vozilo { get; set; }
        public string OdabraniTermin { get; set; }
        public string DodatanOpis { get; set; }
        public ICollection<string> Usluge { get; set; }
        public string ZamjenskoVozilo { get; set; }
        public Kontakt Kontakt { get; set; }
    }
}