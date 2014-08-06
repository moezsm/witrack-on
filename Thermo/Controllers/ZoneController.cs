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
    [Authorize()]
    public class ZoneController : BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        //
        // GET: /Zone/

        public ActionResult Index()
        {
            var zones = db.Zones.Include(z => z.Location);
            ViewData["user"] = User.Identity.Name;
            return View(zones.ToList());
        }
        
        //
        // GET: /Zone/Details/5

        public ActionResult Details(int id = 0)
        {
            Zone zone = db.Zones.Find(id);
            if (zone == null)
            {
                return HttpNotFound();
            }
            ViewData["user"] = User.Identity.Name;
            return View(zone);
        }

        //
        // GET: /Zone/Create

        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Name");
            ViewData["user"] = User.Identity.Name;
            return View();
        }

        //
        // POST: /Zone/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Zone zone)
        {
            if (ModelState.IsValid)
            {
                db.Zones.Add(zone);
                zone.DateCreation = DateTime.Now;
                zone.UserID = WebSecurity.CurrentUserId;
                db.SaveChanges();
                TempData["Msg"] = "Les données ont été sauvegardées avec succès";
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Name", zone.LocationID);
            ViewData["user"] = User.Identity.Name;
            return View(zone);
        }

        //
        // GET: /Zone/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Zone zone = db.Zones.Find(id);
            if (zone == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Name", zone.LocationID);
            ViewData["user"] = User.Identity.Name;
            return View(zone);
        }

        //
        // POST: /Zone/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Zone zone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zone).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Msg"] = "Les données ont été sauvegardées avec succès";
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Name", zone.LocationID);
            ViewData["user"] = User.Identity.Name;
            return View(zone);
        }

        //
        // GET: /Zone/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Zone zone = db.Zones.Find(id);
            if (zone == null)
            {
                return HttpNotFound();
            }
            return View(zone);
        }

        //
        // POST: /Zone/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zone zone = db.Zones.Find(id);
            db.Zones.Remove(zone);
            db.SaveChanges();
            ViewData["user"] = User.Identity.Name;
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}