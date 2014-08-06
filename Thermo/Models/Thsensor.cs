using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thermo.Models
{
    public class Thsensor : Equipement
    {
        public int ThsensorID { get; set; }
        public int? HumidityHighAlarm { get; set; }
        public int? HumidityLowAlarm { get; set; }
    }
}