using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Thermo.DAL;
using Thermo.Models;

namespace Thermo.Controllers
{
    public class AlarmeTechniqueController : ApiController
    {
        //
        // POST : api/AlarmeTechnique
        ModuleEquipementContext db = new ModuleEquipementContext();
        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage PostAlarmeTechnique([FromBody] Enregistrement enreg)
        {
            Enregistrement value = new Enregistrement();
            Alarme alarme = new Alarme();
            db.Alarmes.Add(alarme);
            alarme.Values = 0;
            alarme.Status = "Equipement non détecté";
            alarme.StartDate = DateTime.Now;
            alarme.EquipementID = 1;
            alarme.EndDate = DateTime.Now;
            alarme.closed = "No";
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }
    }
}
