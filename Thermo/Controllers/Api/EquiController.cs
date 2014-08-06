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

namespace Thermo.Controllers.Api
{
    public class EquiController : ApiController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        // GET api/Default1
        public IEnumerable<Equipement> GetEquipementsAsync()
        {
            var equipements = db.Equipements.Include(e => e.Zones).Include(e => e.Sensors);
            return equipements.AsEnumerable();
        }

        // GET api/Equi/5
        public Equipement GetEquipement(int id)
        {
            Equipement equipement = db.Equipements.Find(id);
            if (equipement == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return equipement;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutEquipement(int id, Equipement equipement)
        {
            if (ModelState.IsValid && id == equipement.EquipementID)
            {
                db.Entry(equipement).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Default1
        public HttpResponseMessage PostEquipement(Equipement equipement)
        {
            if (ModelState.IsValid)
            {
                db.Equipements.Add(equipement);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, equipement);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = equipement.EquipementID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteEquipement(int id)
        {
            Equipement equipement = db.Equipements.Find(id);
            if (equipement == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Equipements.Remove(equipement);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, equipement);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}