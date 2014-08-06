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
    public class NombreAlarmeController : ApiController
    {
        ModuleEquipementContext db = new ModuleEquipementContext();

        // GET api/nombrealarme/5
        public IEnumerable<int> Get(int id = 0)
        {
            int responsableID = db.Clients.Where(c => c.UserID == id).First().AdminID;
            int nombrealarme = 0;
            IEnumerable<Equipement> listeequipement = db.Equipements.Where(c => c.UserID == responsableID).ToList();
            foreach (Equipement equipement in listeequipement)
            {
                IEnumerable<Alarme> listealarme = db.Alarmes.Where(c => c.EquipementID == equipement.EquipementID && c.closed == "No").ToList();
                nombrealarme += listealarme.Count();
            }
            return new int[] { nombrealarme };
        }

       

        // POST api/nombrealarme
        public void Post([FromBody]string value)
        {
        }

        // PUT api/nombrealarme/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/nombrealarme/5
        public void Delete(int id)
        {
        }
    }
}
