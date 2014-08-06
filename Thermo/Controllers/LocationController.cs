﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thermo.Models;
using Thermo.DAL;
using WebMatrix.WebData;
using Thermo.Helpers;
using System.Threading.Tasks;
using Thermo.Services;

namespace Thermo.Controllers
{

    [Authorize()]
    public class LocationController : BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        //
        // GET: /Location/

        public ActionResult Index()
        {
            ViewData["user"] = User.Identity.Name;
            return View(db.Locations.ToList());
        }
        
        //
        // GET: /Location/Details/5

        public ActionResult Details(int id = 0)
        {
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewData["user"] = User.Identity.Name;
            return View(location);
        }

        //
        // GET: /Location/Create

        public ActionResult Create()
        {

            ViewData["user"] = User.Identity.Name;
            return View();
        }

        //
        // POST: /Location/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                location.DateCreation = DateTime.Now;
                location.UserID = WebSecurity.CurrentUserId;
                db.SaveChanges();
                TempData["Msg"] = "Les données ont été sauvegardées avec succès";
                return RedirectToAction("Index");
            }

            ViewData["user"] = User.Identity.Name;
            return View(location);
        }

        //
        // GET: /Location/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewData["user"] = User.Identity.Name;
            return View(location);
        }

        //
        // POST: /Location/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["user"] = User.Identity.Name;
            return View(location);
        }

        //
        // GET: /Location/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewData["user"] = User.Identity.Name;
            return View(location);
        }

        //
        // POST: /Location/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
            db.SaveChanges();
            ViewData["user"] = User.Identity.Name;
            return RedirectToAction("Index");
        }

        //
        // GET: /Location/SetCulture

        public ActionResult SetCulture()
        {

            ViewData["user"] = User.Identity.Name;
            return View();
        }

        public ActionResult SetCulture2(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            RouteData.Values["culture"] = culture;
            return RedirectToAction("SetCulture");
        } 

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}