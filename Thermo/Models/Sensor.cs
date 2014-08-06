using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thermo.Models
{
    public class Sensor
    {
        public int SensorID { get; set; }
        public string name { get; set; }


        public virtual ICollection<Equipement> Equipements { get; set; }
    }
}