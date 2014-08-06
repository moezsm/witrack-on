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
    public class EvenementController : BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        //
        // GET: /Evenement/

        public ActionResult Index()
        {
            return View(db.Audits.ToList());

            ViewData["user"] = User.Identity.Name;
        }

        //
        // GET: /Evenement/Details/5

        public ActionResult Details(int id = 0)
        {
            Evenement evenement = db.Evenements.Find(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }

            ViewData["user"] = User.Identity.Name;
            return View(evenement);
        }

        //
        // GET: /Evenement/Create

        public ActionResult Create()
        {

            ViewData["user"] = User.Identity.Name;
            return View();
        }

        //
        // POST: /Evenement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evenement evenement)
        {
            if (ModelState.IsValid)
            {
                db.Evenements.Add(evenement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["user"] = User.Identity.Name;
            return View(evenement);
        }

        //
        // GET: /Evenement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Evenement evenement = db.Evenements.Find(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }

            ViewData["user"] = User.Identity.Name;
            return View(evenement);
        }

        //
        // POST: /Evenement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evenement evenement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evenement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["user"] = User.Identity.Name;
            return View(evenement);
        }

        //
        // GET: /Evenement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Evenement evenement = db.Evenements.Find(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }

            ViewData["user"] = User.Identity.Name;
            return View(evenement);
        }

        //
        // POST: /Evenement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evenement evenement = db.Evenements.Find(id);
            db.Evenements.Remove(evenement);
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