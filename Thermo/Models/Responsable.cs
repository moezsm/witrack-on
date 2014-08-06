using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thermo.Models
{
    public class Responsable
    {
        public int ResponsableID { get; set; }
        public int EquipementID { get; set; }
        public int UserID { get; set; }

        public virtual Equipement Equipements { get; set; }
    }
}