using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thermo.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public int UserID { get; set; }

        public virtual ICollection<Zone> Zones { get; set; }
    }
}