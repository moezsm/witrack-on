using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thermo.Models
{
    public class Audit
    {
        //Audit Properties
        public Guid AuditID { get; set; }
        public string UserName { get; set; }
        public string IPAddress { get; set; }
        public string AreaAccessed { get; set; }
        public DateTime Timestamp { get; set; }
        public string action { get; set; }
        public string Field { get; set; }
        public string Oldvalue { get; set; }
        public string Newvalue { get; set; }

        //Default Constructor
        public Audit() { }
    }
}