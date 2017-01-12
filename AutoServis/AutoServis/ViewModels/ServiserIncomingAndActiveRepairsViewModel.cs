using System.Collections.Generic;
using AutoServis.Models;

namespace AutoServis.ViewModels
{
    public class ServiserIncomingAndActiveRepairsViewModel
    {
        public List<PopravakZaServiseraViewModel> Popravci { get; set; }

        public bool ZamjenskoVraceno { get; set; }

        public string Popravak { get; set; }
    }
}