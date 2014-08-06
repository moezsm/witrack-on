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
    public class ServiceController : BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();
       
        //
        // GET: /Service/

        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }

        //
        // GET: /Service/Details/5

        public ActionResult Details(int id = 0)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        //
        // GET: /Service/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Service/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service);
        }

        //
        // GET: /Service/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        //
        // POST: /Service/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        //
        // GET: /Service/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        //
        // POST: /Service/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        private MultiSelectList GetUsers(string[] selectedValues)
        {
            IEnumerable<Groupe> listegroupe = db.Groupes.ToList();
            return new MultiSelectList(listegroupe, "GroupeID", "Name", selectedValues);
        }    
        //
        // GET: /Service/addgroupe/5

        public ActionResult addgroupe(int id = 0)
        {
            

            IEnumerable<Groupe> groupes = db.Groupes.Where(c => c.Services.Any(s => s.ServiceID == id)).ToList();

            int i = 0;
            string[] selectedValues = new string[50];
            foreach (var groupe in groupes)
            {
                selectedValues[i] = groupe.GroupeID.ToString();
                i++;
            }
            ViewData["id"] = selectedValues;
            ViewBag.Userlist = GetUsers(selectedValues);
            return View();
        }


        //
        // POST: /Service/addgroupe/5
        [HttpPost]
        public ActionResult addgroupe(FormCollection form, int id = 0)
        {
            ViewBag.YouSelected = form["listuser"];
            
            string selectedValues = form["listuser"];

            string[] listslected = new string[100];
            int groupeid = 0;
            if (selectedValues != null)
            {
                listslected = selectedValues.Split(',');
                foreach (string val in listslected)
                {
                    groupeid = Convert.ToInt32(val);
                    if (!db.Services.Where(c => c.ServiceID == id && c.Groupes.Any(g => g.GroupeID == groupeid)).Any())
                    {
                        Groupe groupe = db.Groupes.Where(p => p.GroupeID == groupeid).First();
                        Service service = db.Services.Find(id);
                        service.Groupes.Add(groupe);
                        db.SaveChanges();
                    }
                }
                IEnumerable<Groupe> groupeservice = db.Groupes.Where(c => c.Services.Any(g => g.ServiceID == id)).ToList();

                foreach (Groupe groupe in groupeservice)
                {
                    bool test = false;
                    foreach (string val in listslected)
                    {
                        groupeid = Convert.ToInt32(val);
                        if (groupe.GroupeID == groupeid)
                        {
                            test = true;
                        }
                    }
                    if (!test)
                    {
                        Service service = db.Services.Find(id);
                        groupe.Services.Remove(service);
                        db.SaveChanges();
                    }
                }
                ViewBag.Userlist = GetUsers(selectedValues.Split(','));
            }
            else
            {
                Service service = db.Services.Find(id);
                IEnumerable<Groupe> listegroupe = db.Groupes.Where(g => g.Services.Any(s => s.ServiceID == id)).ToList();
                foreach (Groupe groupe in listegroupe)
                {
                    service.Groupes.Remove(groupe);
                    db.SaveChanges();
                }
                ViewBag.Userlist = GetUsers(null);
            }
            return View();
        }
    }
}