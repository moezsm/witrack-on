using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Thermo.DAL;
using Thermo.Models;

namespace Thermo.Services
{
    public class EquipementService
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();
        public async Task<Value> GetFirsvalueAsync(int id)
        {
            Value values = db.Values.Where(equi => equi.EquipementID == id).First();
            return values;
        }

        public async Task<Equipement> GetEquipementAsync(int id)
        {
            Equipement equipement = db.Equipements.Find(id);
            return equipement;
        }
        public async Task<IEnumerable<Value>> GetListvalueAsync(int id)
        {
            IEnumerable<Value> listvalues = db.Values.Where(equi => equi.EquipementID == id).ToList();
           return listvalues;
        }

        public async Task<IEnumerable<Value>> GetListvaluedecendAsync(int id)
        {
            IEnumerable<Value> listvalues = db.Values.Where(equi => equi.EquipementID == id).OrderByDescending(c => c.DateCreation).ToList();
            return listvalues;
        }
        public async Task<IEnumerable<Alarme>> GetListalarmeAsync(int id)
        {

            IEnumerable<Alarme> alarme = db.Alarmes.Where(alarm => alarm.EquipementID == id).ToList();
            return alarme;
        }
    }
}