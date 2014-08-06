using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thermo.Models;
using Thermo.DAL;
using WebMatrix.WebData;

namespace Thermo.Controllers
{
    public class ThsensorController : Controller
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        //
        // GET: /Thsensor/

        public ActionResult Index()
        {
            var equipements = db.Thsensors.Include(t => t.Zones).Include(t => t.Sensors);
            return View(equipements.ToList());
        }

        //
        // GET: /Thsensor/Details/5

        public ActionResult Details(int id = 0)
        {
            Thsensor thsensor = db.Thsensors.Find(id);
            if (thsensor == null)
            {
                return HttpNotFound();
            }
            return View(thsensor);
        }

        //
        // GET: /Thsensor/Create

        public ActionResult Create()
        {
            ViewBag.ZoneID = new SelectList(db.Zones, "ZoneID", "Name");
            ViewBag.SensorID = new SelectList(db.Sensors, "SensorID", "name");
            return View();
        }

        //
        // POST: /Thsensor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Thsensor thsensor)
        {
            if (ModelState.IsValid)
            {
                db.Thsensors.Add(thsensor);
                thsensor.DateCreation = DateTime.Now;
                thsensor.UserID = WebSecurity.CurrentUserId;
                thsensor.SensorID = 2;
                db.SaveChanges();
                TempData["Success"] = "Element created with succsess.!";
                return RedirectToAction("Index", "Equipement");
            }

            ViewBag.ZoneID = new SelectList(db.Zones, "ZoneID", "Name", thsensor.ZoneID);
            ViewBag.SensorID = new SelectList(db.Sensors, "SensorID", "name", thsensor.SensorID);
            return View(thsensor);
        }

        //
        // GET: /Thsensor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Thsensor thsensor = db.Thsensors.Find(id);
            if (thsensor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZoneID = new SelectList(db.Zones, "ZoneID", "Name", thsensor.ZoneID);
            ViewBag.SensorID = new SelectList(db.Sensors, "SensorID", "name", thsensor.SensorID);
            return View(thsensor);
        }

        //
        // POST: /Thsensor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Thsensor thsensor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thsensor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZoneID = new SelectList(db.Zones, "ZoneID", "Name", thsensor.ZoneID);
            ViewBag.SensorID = new SelectList(db.Sensors, "SensorID", "name", thsensor.SensorID);
            return View(thsensor);
        }

        //
        // GET: /Thsensor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Thsensor thsensor = db.Thsensors.Find(id);
            if (thsensor == null)
            {
                return HttpNotFound();
            }
            return View(thsensor);
        }

        //
        // POST: /Thsensor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thsensor thsensor = db.Thsensors.Find(id);
            db.Equipements.Remove(thsensor);
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