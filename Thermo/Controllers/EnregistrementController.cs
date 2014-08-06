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

namespace Thermo.Controllers
{
    public class EnregistrementController : ApiController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        // GET api/Enregistrement
        public IEnumerable<Enregistrement> GetEnregistrements()
        {
            return db.Enregistrements.AsEnumerable();
        }

        // GET api/Enregistrement/5
        public Enregistrement GetEnregistrement(int id)
        {
            Enregistrement enregistrement = db.Enregistrements.Find(id);
            if (enregistrement == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return enregistrement;
        }

        // PUT api/Enregistrement/5
        public HttpResponseMessage PutEnregistrement(int id, Enregistrement enregistrement)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != enregistrement.EnregistrementID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(enregistrement).State = EntityState.Modified;

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

        // POST api/Enregistrement
        public HttpResponseMessage PostEnregistrement(Enregistrement enregistrement)
        {
            if (ModelState.IsValid)
            {
                db.Enregistrements.Add(enregistrement);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, enregistrement);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = enregistrement.EnregistrementID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Enregistrement/5
        public HttpResponseMessage DeleteEnregistrement(int id)
        {
            Enregistrement enregistrement = db.Enregistrements.Find(id);
            if (enregistrement == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Enregistrements.Remove(enregistrement);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, enregistrement);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}