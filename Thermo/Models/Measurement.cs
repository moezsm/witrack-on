using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thermo.Models
{
    public class Measurement
    {
        public int MeasurementID { get; set; }
        public DateTime Date { get; set; }
        public float value { get; set; }
    }
}