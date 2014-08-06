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
    public class NoteController : BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        //
        // GET: /Note/

        public ActionResult Index()
        {
            return View(db.Notes.ToList());
        }

        //
        // GET: /Note/Details/5

        public ActionResult Details(int id = 0)
        {
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }
        //
        // GET: /Note/Liste

        public ActionResult Liste()
        {

            return PartialView("ListePartial");
        }
        //
        // GET: /Note/Create/5

        public ActionResult Create(int id = 0)
        {
            /*if (db.Alarmes.Where(a => a.AlarmeID == id).Any())
            {
                Alarme alarme = db.Alarmes.Find(id);
                if (alarme.NoteId == null)
                {
                    Note note = new Note();
                    db.Notes.Add(note);
                    note.AlarmeID = id;
                    note.Author = WebSecurity.CurrentUserName;
                    note.Datecreation = DateTime.Now;
                    db.SaveChanges();
                    if (db.Alarmes.Where(a => a.AlarmeID == note.AlarmeID).Any())
                    {
                        Alarme alarme2 = db.Alarmes.Find(note.AlarmeID);
                        alarme2.NoteId = note.NoteID;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Edit", new { id = alarme.NoteId });
                }
                return RedirectToAction("Edit", new { id = alarme.NoteId });
            }*/
            ViewData["id"] = id;
            return View();
        }

        //
        // POST: /Note/Create/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(note); 
                note.Author = WebSecurity.CurrentUserName;
                note.Datecreation = DateTime.Now;
                db.SaveChanges();
                if (db.Alarmes.Where(a => a.AlarmeID == note.AlarmeID).Any())
                {
                    Alarme alarme = db.Alarmes.Find(note.AlarmeID);
                    alarme.NoteId = note.NoteID;
                    db.SaveChanges();
                }
                return RedirectToAction("Acquiter", "Alarme", new { idAlarme = note.AlarmeID });
            }

            return View(note);
        }

        //
        // GET: /Note/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        //
        // POST: /Note/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Msg"] = "Les données ont été sauvegardées avec succès";
                return RedirectToAction("Acquiter", "Alarme", new { idAlarme = note.AlarmeID });
            }
            return View(note);
        }

        //
        // GET: /Note/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        //
        // POST: /Note/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
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