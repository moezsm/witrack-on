using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Thermo.DAL;
using Thermo.Models;

namespace Thermo.Controllers.Api
{
    public class ListAlarmeController : ApiController
    {
        ModuleEquipementContext db = new ModuleEquipementContext();

        // GET api/listalarme/5
        public IEnumerable<Object> Get(int id = 0)
        {
            int responsableID = db.Clients.Where(c => c.UserID == id).First().AdminID;
            IEnumerable<Equipement> listeequipement = db.Equipements.Where(c => c.UserID == responsableID).ToList();
            int nombrealarme = 0;
            foreach (Equipement equipement in listeequipement)
            {
                IEnumerable<Alarme> listealarme2 = db.Alarmes.Where(c => c.EquipementID == equipement.EquipementID && c.closed == "No").ToList();
                nombrealarme += listealarme2.Count();
            }
            Object[] array = new Object[nombrealarme];
            int i = 0;
            IEnumerable<Alarme> listealarme = new List<Alarme>();
            foreach( Equipement equipement in listeequipement)
            {
                 listealarme = db.Alarmes.Where(c => c.EquipementID == equipement.EquipementID && c.closed == "No").ToList();
                 foreach (Alarme alarme in listealarme)
                 {
                     Object[] o = { equipement.EquipementID, alarme.AlarmeID, "/Equipement/Details/"+equipement.EquipementID };
                     array[i] = o;
                     i++;
                 }
            }
            
            return new Object[] {array };
        }

       

        // POST api/listalarme
        public void Post([FromBody]string value)
        {
        }

        // PUT api/listalarme/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/listalarme/5
        public void Delete(int id)
        {
        }
    }
}
