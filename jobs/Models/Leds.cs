using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobs.Models
{
    public class Leds
    {
        public string IdLed { get; set; }
        public string LedPosicion { get; set; }
        public override string ToString()
        {
            return LedPosicion;

        }
    }
}