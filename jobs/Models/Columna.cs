using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobs.Models
{
    public class Columna
    {
        public string IdColumna { get; set; }
        public string ColumnaNumber { get; set; }
        public string LedPosicion { get; set; }
        public override string ToString()
        {
            return ColumnaNumber;

        }
    }
}