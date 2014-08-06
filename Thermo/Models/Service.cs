using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thermo.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Groupe> Groupes { get; set; }
    }
}