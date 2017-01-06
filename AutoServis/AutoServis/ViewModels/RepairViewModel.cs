using System;
using System.Collections.Generic;
using System.Web.WebPages.Html;
using AutoServis.Models;
using SelectListItem = System.Web.Mvc.SelectListItem;

namespace AutoServis.ViewModels
{
    public class RepairViewModel
    {
        public IEnumerable<Vozilo> vozila { get; set; }
        public Vozilo odabranoVozilo { get; set; }
        public IEnumerable<Serviser> serviseri { get; set; }
        public Serviser odabraniServiser { get; set; }
        public IEnumerable<SelectListItem> dostupniTermini { get; set; }
        public DateTime odabraniTermin { get; set; }
    }
}