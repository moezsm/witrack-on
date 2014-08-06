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
    public class GetAlarmController : ApiController
    {
        ModuleEquipementContext db = new ModuleEquipementContext();
        // GET api/getalarm
        public IEnumerable<int> Get()
        {
            Alarme alarme = new Alarme();
            int AlarmeId = 0;
            int EquipementId = 0;
            List<Alarme> listAlarme = db.Alarmes.ToList();
            foreach(Alarme item in listAlarme )
            {
                if (item.closed == "No")
                {
                    AlarmeId = item.AlarmeID;
                    EquipementId = item.EquipementID;

                }
            }
            return new int[] { AlarmeId, EquipementId };
        }

        // GET api/getalarm/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/getalarm
        public void Post([FromBody]string value)
        {
        }

        // PUT api/getalarm/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/getalarm/5
        public void Delete(int id)
        {
        }
    }
}
