using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Thermo.Models
{
    public class Enregistrement
    {
        public int EnregistrementID { get; set; }
        public float Value { get; set; }
        public string Sondeid { get; set; }
        public DateTime DateTimeValue { get; set; }
    }
}