using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thermo.Models
{
    public class Groupe
    {
        public int GroupeID { get; set; }
        public String Name { get; set; }

        public virtual ICollection<Profil> Profils { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}