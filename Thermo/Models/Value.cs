using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thermo.DAL;

namespace Thermo.Models
{
    public class Value
    {
        public int ValueId { get; set; }
        public float Val { get; set; }
        public Decimal humidity { get; set; }
        public DateTime DateCreation { get; set; }
        public int EquipementID { get; set; }




        
    }
}