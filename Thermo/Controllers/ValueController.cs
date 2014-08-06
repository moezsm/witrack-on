using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Thermo.Models;
using Thermo.DAL;
using System.Xml.Linq;
using System.Xml;
using System.Globalization;

namespace Thermo.Controllers
{
    [Authorize()]
    public class ValueController : BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        //
        // GET: /Value/

        public ActionResult Index()
        {
            return View(db.Values.ToList());
        }

        //
        // GET: /Value/Details/5

        public ActionResult Details(int id = 0)
        {
            Value value = db.Values.Find(id);
            if (value == null)
            {
                return HttpNotFound();
            }
            return View(value);
        }

        //
        // GET: /Value/Xml

        public ActionResult Xml()
        {
            XDocument xdoc = XDocument.Load("http://192.168.1.2/details.xml");
            //var temperature = from item in xdoc.Descendants("owd_DS18S20") select item.Element("Name");
            var temperature = xdoc.Element("{http://www.embeddeddatasystems.com/schema/owserver}Devices-Detail-Response").Descendants("{http://www.embeddeddatasystems.com/schema/owserver}owd_DS18S20");
            //ViewData["temperature"] = temperature.ToString();
            int i = temperature.Count();
            Enregistrement value = new Enregistrement();
            foreach (var temp in temperature)
            {



                var val = temp.Element("{http://www.embeddeddatasystems.com/schema/owserver}Temperature").Value;
                // ViewData["temperature"] = temp.Element("{http://www.embeddeddatasystems.com/schema/owserver}Temperature").Value;
                db.Enregistrements.Add(value);
                value.Sondeid = temp.Element("{http://www.embeddeddatasystems.com/schema/owserver}ROMId").Value;
                value.Value = float.Parse(val, CultureInfo.InvariantCulture.NumberFormat);
                db.SaveChanges();



            }
            ViewData["i"] = i;
            return View();
        } 
        
        //
        // GET: /Value/Create

        public ActionResult Create()
        {
            ViewBag.EquipementID = new SelectList(db.Equipements, "EquipementID", "Name");
            return View();
        }

        //
        // POST: /Value/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Value value)
        {
            if (ModelState.IsValid)
            {
                db.Values.Add(value);
                value.DateCreation = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipementID = new SelectList(db.Equipements, "EquipementID", "Name", value.EquipementID);
            return View(value);
        }

        //
        // GET: /Value/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Value value = db.Values.Find(id);
            if (value == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipementID = new SelectList(db.Equipements, "EquipementID", "Name", value.EquipementID);
            return View(value);
        }

        //
        // POST: /Value/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Value value)
        {
            if (ModelState.IsValid)
            {
                db.Entry(value).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipementID = new SelectList(db.Equipements, "EquipementID", "Name", value.EquipementID);
            return View(value);
        }

        //
        // GET: /Value/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Value value = db.Values.Find(id);
            if (value == null)
            {
                return HttpNotFound();
            }
            return View(value);
        }

        //
        // POST: /Value/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Value value = db.Values.Find(id);
            db.Values.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //
        // GET: /Value/iprequest
        public ActionResult Iprequest()
        {
            return View();
        }

        //
        // GET : /Value/ipresult/5
        private ActionResult Ipresult(int temp)
        {
            ViewData["temp"] = temp;
            return null;
        }
    }
}