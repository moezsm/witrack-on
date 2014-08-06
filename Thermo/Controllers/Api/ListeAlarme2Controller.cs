using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Thermo.Models;
using Thermo.DAL;
using WebMatrix.WebData;
using System.Web.Security;

namespace Thermo.Controllers.Api
{

    public class Alarmeapi
    {
        public int AlarmeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public float Values { get; set; }
        public int EquipementID { get; set; }
        public string closed { get; set; }
        public int? NoteId { get; set; }
        public string SondeName { get; set; }
        public string SondeId { get; set; }
    }
    [Authorize()]
    public class ListeAlarme2Controller : ApiController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();
        private UsersContext dbuser = new UsersContext();
        // GET api/ListeAlarme2
        public IEnumerable<Alarmeapi> GetAlarmes()
        {
            IEnumerable<Alarme> alarmes = new List<Alarme>();
            Equipement equipement = new Equipement();
            int userid = WebSecurity.CurrentUserId;
            string SondeName = "";
            string SondeId = "";


           if (Roles.IsUserInRole("super_admin"))
            {
               alarmes =  db.Alarmes.Where(c => c.fin == "No").ToList();

               List<Alarmeapi> alarmeapilist = new List<Alarmeapi>();
               foreach (Alarme alarme in alarmes )
               {
                   Alarmeapi alarmeapi = new Alarmeapi();
                   equipement = db.Equipements.Find(alarme.EquipementID);
                   SondeId = equipement.Numero;
                   SondeName = equipement.Name;
                   alarmeapi.AlarmeID = alarme.AlarmeID;
                   alarmeapi.closed = alarme.fin;
                   alarmeapi.EndDate = alarme.EndDate;
                   alarmeapi.EquipementID = alarme.EquipementID;
                   alarmeapi.NoteId = alarme.NoteId;
                   alarmeapi.StartDate = alarme.StartDate;
                   alarmeapi.Status = alarme.Status;
                   alarmeapi.Values = alarme.Values;
                   alarmeapi.SondeId = SondeId;
                   alarmeapi.SondeName = SondeName;
                   alarmeapilist.Add(alarmeapi);
               }
               return alarmeapilist.AsEnumerable();
            }
            else if (db.Responsables.Where(r => r.UserID == userid).Any())
            {
                IEnumerable<Responsable> responsables = db.Responsables.Where(r => r.UserID == userid).ToList();

                List<Alarmeapi> alarmeapilist = new List<Alarmeapi>();
                foreach (Responsable responsable in responsables)
                {
                    alarmes = db.Alarmes.Where(c => c.fin == "No" & c.EquipementID == responsable.EquipementID).ToList();

                    foreach (Alarme alarme in alarmes)
                    {
                        Alarmeapi alarmeapi = new Alarmeapi();
                        SondeId = db.Equipements.Find(alarme.EquipementID).Numero;
                        SondeName = db.Equipements.Find(alarme.EquipementID).Name;
                        alarmeapi.AlarmeID = alarme.AlarmeID;
                        alarmeapi.closed = alarme.fin;
                        alarmeapi.EndDate = alarme.EndDate;
                        alarmeapi.EquipementID = alarme.EquipementID;
                        alarmeapi.NoteId = alarme.NoteId;
                        alarmeapi.StartDate = alarme.StartDate;
                        alarmeapi.Status = alarme.Status;
                        alarmeapi.Values = alarme.Values;
                        alarmeapi.SondeId = SondeId;
                        alarmeapi.SondeName = SondeName;
                        alarmeapilist.Add(alarmeapi);
                    }
                    
                   
                }
                return alarmeapilist.AsEnumerable();
            }
            
            return null;
        }

        // GET api/ListeAlarme2/5
        public Alarme GetAlarme(int id)
        {
            Alarme alarme = db.Alarmes.Find(id);
            if (alarme == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return alarme;
        }

        // PUT api/ListeAlarme2/5
        public HttpResponseMessage PutAlarme(int id, Alarme alarme)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != alarme.AlarmeID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(alarme).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/ListeAlarme2
        public HttpResponseMessage PostAlarme(Alarme alarme)
        {
            if (ModelState.IsValid)
            {
                db.Alarmes.Add(alarme);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, alarme);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = alarme.AlarmeID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ListeAlarme2/5
        public HttpResponseMessage DeleteAlarme(int id)
        {
            Alarme alarme = db.Alarmes.Find(id);
            if (alarme == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Alarmes.Remove(alarme);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, alarme);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}