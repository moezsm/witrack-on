using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models
{
    public class DetailReport
    {
        public int EquipementID { get; set; }
        public string username { get; set; }
        public string location { get; set; }
        public string zone { get; set; }
        public DateTime datereport { get; set; }
        public DateTime datedebut { get; set; }
        public DateTime datefin { get; set; }
        public string numerosonde { get; set; }
        public Decimal max { get; set; }
        public Decimal min { get; set; }
        public int? haute { get; set; }
        public int? basse { get; set; }
        public string nomsonde { get; set; }

    }
}