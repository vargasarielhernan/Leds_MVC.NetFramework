using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jobs.Models
{
    public class Sector
    {
        public string IdSector {  get; set; }
        public string Name { get; set; } 
        public string nave { get; set; }
        public string columna { get; set; }
        public string led { get; set; }
    }
}
