using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Thermo.Models
{
    public class Profil
    {
        public int ProfilID { get; set; }
        public int UserID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Mailweekend { get; set; }
        public string Mail3 { get; set; }
        public int? numero { get; set; }
        public int? numero2 { get; set; }
        public int? numero3 { get; set; }

        public virtual ICollection<Groupe> Groupes { get; set; }
    }

   
}