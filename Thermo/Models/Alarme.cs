using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Thermo.Models
{
    public class Alarme
    {
        public int AlarmeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public float Values { get; set; }
        public int EquipementID { get; set; }
        public string closed { get; set; }
        public int? NoteId { get; set; }
        public string fin { get; set; }

        public virtual Equipement Equipements { get; set; }
    }
}