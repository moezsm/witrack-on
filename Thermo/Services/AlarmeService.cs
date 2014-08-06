using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Thermo.DAL;
using Thermo.Models;

namespace Thermo.Services
{
    public class AlarmeService
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();
        public async Task<Alarme> GetAlarmeAsync(int id)
        {
            Alarme alarme = db.Alarmes.Find(id);
            return alarme;
        }
        public async Task<IEnumerable<Alarme>> GetListAsync(int id)
        {
            IEnumerable<Alarme> alarmes = db.Alarmes.Where(alarm => alarm.EquipementID == id).ToList();
            return alarmes;
        }
    }
}