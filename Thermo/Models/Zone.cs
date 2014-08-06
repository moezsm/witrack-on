using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thermo.Models
{
    public class Zone
    {
        public int ZoneID { get; set; }
        public string Name { get; set; }
        public int LocationID { get; set; }
        public DateTime DateCreation { get; set; }
        public int UserID { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Equipement> Equipements { get; set; }
    }
}