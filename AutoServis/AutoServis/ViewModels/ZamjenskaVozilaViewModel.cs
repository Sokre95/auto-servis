using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoServis.Models;

namespace AutoServis.ViewModels
{
    public class ZamjenskaVozilaViewModel
    {
        public IEnumerable<ZamjenskoVozilo> Vozila { get; set; }

        public int Odabrano { get; set; }
    }
}