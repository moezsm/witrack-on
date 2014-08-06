using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Thermo.DAL;
using Thermo.Models;

namespace Thermo.Services
{
    public class DashbordService
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();
        public async Task<IEnumerable<Location>> GetLocationAsync(int clientid)
        {
            IEnumerable<Location> locations = db.Locations.Where(equi => equi.UserID == clientid).ToList();
            return locations;
        }
        public async Task<IEnumerable<Zone>> GetZoneAsync(int clientid)
        {
            IEnumerable<Zone> zones = db.Zones.Where(equi => equi.UserID == clientid).ToList();
            return zones;
        }
        public async Task<IEnumerable<Equipement>> GetEquipementAsync(int clientid)
        {
            IEnumerable<Equipement> equipements = db.Equipements.Where(equi => equi.UserID == clientid).ToList();
            return equipements;
        }
    }
}