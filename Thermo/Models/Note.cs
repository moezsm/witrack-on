using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thermo.Models
{
    public class Note
    {
        public int NoteID { get; set; }
        public string Author { get; set; }
        public DateTime Datecreation { get; set; }
        public string text { get; set; }
        public int AlarmeID { get; set; }

    }
}