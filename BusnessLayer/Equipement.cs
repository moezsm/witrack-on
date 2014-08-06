using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer
{
    public class Equipement
    {
        public int EquipementID { get; set; }
        public string Name { get; set; }
        public int ZoneID { get; set; }
        public DateTime DateCreation { get; set; }
        public int SensorID { get; set; }
        public int? HighAlarm { get; set; }

    }
}
