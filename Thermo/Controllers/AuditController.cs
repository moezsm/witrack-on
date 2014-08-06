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
    public class AuditController : Controller
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        //
        // GET: /Audit/

        public ActionResult Index()
        {
            return View(db.Audits.ToList());
        }

       

        //
        // GET: /Audit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Audit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Audit audit)
        {
            if (ModelState.IsValid)
            {
                audit.AuditID = Guid.NewGuid();
                db.Audits.Add(audit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(audit);
        }

      

        //
        // POST: /Audit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Audit audit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(audit);
        }

       
        //
        // POST: /Audit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Audit audit = db.Audits.Find(id);
            db.Audits.Remove(audit);
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