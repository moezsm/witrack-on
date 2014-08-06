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
    public class ListeValueController : ApiController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        // GET api/ListeValue
        public IEnumerable<Value> GetValues(string romid)
        {
            int id = 0;
            if (db.Equipements.Where(c => c.Numero == romid).Any())
            {
                id = db.Equipements.Where(c => c.Numero == romid).First().EquipementID;
            }

            return db.Values.Where(v => v.EquipementID == id).OrderByDescending( v => v.DateCreation).AsEnumerable();
        }

        

        // PUT api/ListeValue/5
        public HttpResponseMessage PutValue(int id, Value value)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != value.ValueId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(value).State = EntityState.Modified;

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

        // POST api/ListeValue
        public HttpResponseMessage PostValue(Value value)
        {
            if (ModelState.IsValid)
            {
                db.Values.Add(value);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, value);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = value.ValueId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ListeValue/5
        public HttpResponseMessage DeleteValue(int id)
        {
            Value value = db.Values.Find(id);
            if (value == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Values.Remove(value);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}