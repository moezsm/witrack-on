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
    public class NombreEquipementController : ApiController
    {

        ModuleEquipementContext db = new ModuleEquipementContext();
        // GET api/nombreequipement
        public IEnumerable<int> Get(int id)
        {
            int responsableID = db.Clients.Where(c => c.UserID == id).First().AdminID;
            int nombreequipement = 0;
            IEnumerable<Equipement> listeequipement = db.Equipements.Where(c => c.UserID == responsableID).ToList();
            nombreequipement += listeequipement.Count();
            return new int[] { nombreequipement };
        }

        

        // POST api/nombreequipement
        public void Post([FromBody]string value)
        {
        }

        // PUT api/nombreequipement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/nombreequipement/5
        public void Delete(int id)
        {
        }
    }
}
