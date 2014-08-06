using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thermo.Models;
using Thermo.DAL;

namespace Thermo.Controllers
{
    [Authorize()]
    public class SensorController : BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        //
        // GET: /Sensor/

        public ActionResult Index()
        {
            return View(db.Sensors.ToList());
        }

        //
        // GET: /Sensor/Details/5

        public ActionResult Details(int id = 0)
        {
            Sensor sensor = db.Sensors.Find(id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
            return View(sensor);
        }

        //
        // GET: /Sensor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sensor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                db.Sensors.Add(sensor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sensor);
        }

        //
        // GET: /Sensor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sensor sensor = db.Sensors.Find(id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
            return View(sensor);
        }

        //
        // POST: /Sensor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sensor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Validate", "Home");
            }
            return View(sensor);
        }

        //
        // GET: /Sensor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sensor sensor = db.Sensors.Find(id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
            return View(sensor);
        }

        //
        // POST: /Sensor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sensor sensor = db.Sensors.Find(id);
            db.Sensors.Remove(sensor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}