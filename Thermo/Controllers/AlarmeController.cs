using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Thermo.DAL;
using Thermo.Filters;
using Thermo.Models;
using WebMatrix.WebData;

namespace Thermo.Controllers
{
    [Authorize()]
    public class AlarmeController : BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        //
        // GET: /Alarme/

        public ActionResult Index()
        {
            return View(db.Alarmes.ToList());
        }

        //
        // GET: /Alarme/Liste/5

        public ActionResult Liste(int id)
        {
            ViewData["listenotes"] = "null";
            if (db.Alarmes.Any(a => a.AlarmeID == id))
            {
                if (db.Notes.Any(n => n.AlarmeID == id))
                {
                    IEnumerable<Note> notes = db.Notes.Where(n => n.AlarmeID == id).ToList();
                    ViewData["listenotes"] = notes;
                }
            }
            Alarme alarme = db.Alarmes.Find(id);
            return PartialView("ListePartial", alarme);
        }

        //
        // GET: /Alarme/acquiter/5

        public ActionResult Acquiter(int idAlarme )
        {
            Alarme alarme = db.Alarmes.Find(idAlarme);
            string equipement = db.Equipements.Find(alarme.EquipementID).Name;
            ViewData["Equipement"] = equipement;
            ViewData["listenotes"] = "null";
            if (db.Alarmes.Any(a => a.AlarmeID == idAlarme))
            {
                if (db.Notes.Any(n => n.AlarmeID == idAlarme))
                {
                    IEnumerable<Note> notes = db.Notes.Where(n => n.AlarmeID == idAlarme).ToList();
                    ViewData["listenotes"] = notes;
                }
            }
            return View(alarme);
        }
        //
        // GET: /Alarme/close/5

        public ActionResult Close(int idAlarme)
        {
            Alarme alarme = db.Alarmes.Find(idAlarme);
            alarme.closed = "Yes";
            alarme.EndDate = DateTime.Now;
            db.SaveChanges();
            string equipement = db.Equipements.Find(alarme.EquipementID).Name;
            ViewData["Equipement"] = equipement;
            return RedirectToAction("Acquiter", new { idAlarme = idAlarme });
        }

        //
        // GET: /Alarme/Details/5

        public ActionResult Details(int id = 0)
        {
            Alarme alarme = db.Alarmes.Find(id);
            if (alarme == null)
            {
                return HttpNotFound();
            }
            return View(alarme);
        }

        //
        // GET: /Alarme/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Alarme/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alarme alarme)
        {
            if (ModelState.IsValid)
            {
                db.Alarmes.Add(alarme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alarme);
        }

        //
        // GET: /Alarme/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Alarme alarme = db.Alarmes.Find(id);
            if (alarme == null)
            {
                return HttpNotFound();
            }
            return View(alarme);
        }

        //
        // POST: /Alarme/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Alarme alarme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alarme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alarme);
        }

        //
        // GET: /Alarme/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Alarme alarme = db.Alarmes.Find(id);
            if (alarme == null)
            {
                return HttpNotFound();
            }
            return View(alarme);
        }

        //
        // POST: /Alarme/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alarme alarme = db.Alarmes.Find(id);
            db.Alarmes.Remove(alarme);
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