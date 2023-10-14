using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jobs.Models
{
    public class drop
    {

        public string SectorSeleccionadoName { get; set; }
        public List<SelectListItem> SectorSeleccionado { get; set; }
        public List<SelectListItem> NaveSeleccionada { get; set; }
    }
}