using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobs.Models
{
    public class Nave
    {
        public string IdNave { get; set; }
        public string NameNave { get; set; }
        public string ColumnaNumber { get; set; }
        public override string ToString()
        {
            return NameNave;

        }
    }

}