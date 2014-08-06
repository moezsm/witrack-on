using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thermo.Models;
using Thermo.DAL;
using System.Web.Script.Serialization;
using WebMatrix.WebData;
using DoddleReport.Web;
using DoddleReport;
using DoddleReport.iTextSharp;
using Thermo.Helpers;
using Thermo.Controllers.Api;
using Thermo.Services;
using System.Threading.Tasks;
using Thermo.Filters;

namespace Thermo.Controllers
{
    [Authorize()]
    public class EquipementController : BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();

        //
        // GET: /Equipement/

        public ActionResult Index()
        {
            var equipements = db.Equipements.Include(e => e.Zones).Include(e => e.Sensors);
            ViewData["user"] = User.Identity.Name;
            return View(equipements.ToList());
            
        }

        //
        // GET: /Equipement/Creategenerale/5

        public ActionResult Creategenerale(int id)
        {
            ViewData["id"] = id;
            ViewBag.ZoneID = new SelectList(db.Zones, "ZoneID", "Name");
            if (id == 2)
            {
                return PartialView("CreateThsensor");
            }
            if (id == 1)
            {
                return PartialView("Createtemperature");
            }
            else
            {
                return PartialView("Createtemperature");
            }
        }
       

        //
        // GET: /Equipement/graph

        public async Task<ActionResult> Graph(int id)
        {

            EquipementService equipementservice = new EquipementService();

            Task<Value> value = equipementservice.GetFirsvalueAsync(id) ;
            Task<Equipement> equipement = equipementservice.GetEquipementAsync(id);
            Task < IEnumerable < Value >> listvalues = equipementservice.GetListvalueAsync(id);

            await Task.WhenAll(value, equipement, listvalues);
            int n = listvalues.Result.Count();
            float[] url = new float[n];
            int i = 0;
            foreach (Value val in listvalues.Result)
            {
                url[i] = val.Val;
                i++;
            }
            ViewData["Name"] = equipement.Result.Name;
            ViewData["Numero"] = equipement.Result.Numero;
            ViewData["Max"] = equipement.Result.HighAlarm.ToString();
            ViewData["Location"] = equipement.Result.Zones.Location.Name;
            ViewData["Zone"] = equipement.Result.Zones.Name;
            ViewData["Min"] = equipement.Result.LowAlarm.ToString();
            ViewData["start"] = value.Result.DateCreation.ToString("yyyy,MM,dd,HH");
            ViewData["id"] = id;
            ViewData["Date"] = DateTime.Now.ToString("yyyy/MM/dd");
            ViewData["listvalues"] = listvalues;
            ViewData["user"] = UsersinfoHelper.getFirstname(WebSecurity.CurrentUserId) + " " + UsersinfoHelper.getLastname(WebSecurity.CurrentUserId);
            return View(equipement);
        }

        //
        // GET: /Equipement/graphth

        public async Task<ActionResult> graphth(int id)
        {

            EquipementService equipementservice = new EquipementService();

            Task<Value> value = equipementservice.GetFirsvalueAsync(id);
            Task<Equipement> equipement = equipementservice.GetEquipementAsync(id);
            Task<IEnumerable<Value>> listvalues = equipementservice.GetListvalueAsync(id);

            await Task.WhenAll(value, equipement, listvalues);
            int n = listvalues.Result.Count();
            float[] url = new float[n];
            int i = 0;
            foreach (Value val in listvalues.Result)
            {
                url[i] = val.Val;
                i++;
            }
            ViewData["Name"] = equipement.Result.Name;
            ViewData["Numero"] = equipement.Result.Numero;
            ViewData["Max"] = equipement.Result.HighAlarm.ToString();
            ViewData["Location"] = equipement.Result.Zones.Location.Name;
            ViewData["Zone"] = equipement.Result.Zones.Name;
            ViewData["Min"] = equipement.Result.LowAlarm.ToString();
            ViewData["start"] = value.Result.DateCreation.ToString("yyyy,MM,dd,HH");
            ViewData["id"] = id;
            ViewData["Date"] = DateTime.Now.ToString("yyyy/MM/dd");
            ViewData["listvalues"] = listvalues;
            ViewData["user"] = UsersinfoHelper.getFirstname(WebSecurity.CurrentUserId) + " " + UsersinfoHelper.getLastname(WebSecurity.CurrentUserId);
            return View(equipement);
        }

        //
        // GET: /Equipement/Details/5

        public async Task<ActionResult> Details(int id = 0)
        {
            EquipementService equipementservice = new EquipementService();
            Task<Equipement> equipement = equipementservice.GetEquipementAsync(id);

            Task < IEnumerable < Value >> value = equipementservice.GetListvaluedecendAsync(id);
            Task<IEnumerable<Alarme>> alarme = equipementservice.GetListalarmeAsync(id);
            await Task.WhenAll(value, equipement, alarme);
           // Array value = db.Values.Fi.Where(p => p.EquipementID == id);
            if (equipement == null)
            {
                return HttpNotFound();
            }
           
            ViewData["alarme"] = alarme.Result;
            ViewData["id"] = id;
            ViewData["value"] = value.Result;
            ViewData["user"] = User.Identity.Name;
            return View(equipement.Result);
        }

        //
        // GET: /Equipement/Create

        public ActionResult Create()
        {
            ViewBag.ZoneID = new SelectList(db.Zones, "ZoneID", "Name");
            ViewBag.SensorID = new SelectList(db.Sensors, "SensorID", "name");
            ViewData["user"] = User.Identity.Name;
            return View();
        }

        //
        // POST: /Equipement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipement equipement)
        {
            if (ModelState.IsValid)
            {
                db.Equipements.Add(equipement);

                equipement.DateCreation = DateTime.Now;
                equipement.UserID = WebSecurity.CurrentUserId;
                equipement.SensorID = 1;
                Audit audit = new Audit()
                {
                    //Your Audit Identifier     
                    AuditID = Guid.NewGuid(),
                    //Our Username (if available)
                    UserName = WebSecurity.CurrentUserName,
                    //The IP Address of the Request
                    IPAddress = Request.ServerVariables["REMOTE_ADDR"],
                    //The URL that was accessed
                    AreaAccessed = "Equipement/Create",
                    //Creates our Timestamp
                    Timestamp = DateTime.UtcNow,
                    //type action 
                    action = "creation d'un equipement",
                    Oldvalue = "--",
                    Newvalue = "--",
                    Field = equipement.Name
                };
                db.Audits.Add(audit);

                db.SaveChanges();
                TempData["Success"] = "Element created with succsess.!";
                return RedirectToAction("Index", "Equipement");
            }

            ViewBag.ZoneID = new SelectList(db.Zones, "ZoneID", "Name", equipement.ZoneID);
            ViewBag.SensorID = new SelectList(db.Sensors, "SensorID", "name", equipement.SensorID);
            ViewData["user"] = User.Identity.Name;
            return View(equipement);
        }

        //
        // GET: /Equipement/Edit/5

     
        public ActionResult Edit(int id = 0)
        {
            Equipement equipement = db.Equipements.Find(id);
            if (equipement == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZoneID = new SelectList(db.Zones, "ZoneID", "Name", equipement.ZoneID);
            ViewBag.SensorID = new SelectList(db.Sensors, "SensorID", "name", equipement.SensorID);
            ViewData["user"] = User.Identity.Name;
            return View(equipement);
        }

        //
        // POST: /Equipement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Equipement equipement)
        {
            if (ModelState.IsValid)
            {


               

                var equientry = db.Equipements.Single(e => e.EquipementID == equipement.EquipementID);
                db.Entry(equientry).CurrentValues.SetValues(equipement);
                foreach (var propertyname in db.Entry(equientry).OriginalValues.PropertyNames)
                {

                    var Ov = db.Entry(equientry).OriginalValues.GetValue<Object>(propertyname).ToString();
                    var Nv = db.Entry(equientry).CurrentValues.GetValue<Object>(propertyname).ToString();
                    if (!(Ov == Nv ))
                    {
                        Audit audit = new Audit()
                        {
                            //Your Audit Identifier     
                            AuditID = Guid.NewGuid(),
                            //Our Username (if available)
                            UserName = WebSecurity.CurrentUserName,
                            //The IP Address of the Request
                            IPAddress = Request.ServerVariables["REMOTE_ADDR"],
                            //The URL that was accessed
                            AreaAccessed = "Equipement/Edit",
                            //Creates our Timestamp
                            Timestamp = DateTime.UtcNow,
                            //type action 
                            action = "Edition équipement",
                            Oldvalue = Ov.ToString(),
                            Newvalue = Nv.ToString(),
                            Field = propertyname
                        };
                        db.Audits.Add(audit);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZoneID = new SelectList(db.Zones, "ZoneID", "Name", equipement.ZoneID);
            ViewBag.SensorID = new SelectList(db.Sensors, "SensorID", "name", equipement.SensorID);
            ViewData["user"] = User.Identity.Name;
            return View(equipement);
        }

        //
        // GET: /Equipement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Equipement equipement = db.Equipements.Find(id);
            if (equipement == null)
            {
                return HttpNotFound();
            }
            ViewData["user"] = User.Identity.Name;
            return View(equipement);
        }

        //
        // POST: /Equipement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipement equipement = db.Equipements.Find(id);


            Audit audit = new Audit()
            {
                //Your Audit Identifier     
                AuditID = Guid.NewGuid(),
                //Our Username (if available)
                UserName = WebSecurity.CurrentUserName,
                //The IP Address of the Request
                IPAddress = Request.ServerVariables["REMOTE_ADDR"],
                //The URL that was accessed
                AreaAccessed = "Equipement/Create",
                //Creates our Timestamp
                Timestamp = DateTime.UtcNow,
                //type action 
                action = "suppression d'un equipement",
                Oldvalue = "--",
                Newvalue = "--",
                Field = equipement.Name
            };
            db.Audits.Add(audit);
            db.Equipements.Remove(equipement);
            db.SaveChanges();
            ViewData["user"] = User.Identity.Name;
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            ViewData["user"] = User.Identity.Name;
            base.Dispose(disposing);
        }

        //
        // GET: /Equipement/Json
        public string Json(int id)
        {
            Equipement equipement = db.Equipements.Find(id);
            
            
            IEnumerable<Value> value = db.Values.Where(equi => equi.EquipementID == id).OrderBy(equi => equi.DateCreation).ToList();
            int n = value.Count();
            DateTime[] url = new DateTime[n];
            
            int i = 0;
            
            List<object[]> liste = new List<object[]>();
            foreach (Value val in value)
            {
                var date = (long)(val.DateCreation - new DateTime(1970, 1, 1)).TotalMilliseconds; 
                liste.Add( new object[] { date, val.Val });
                url[i] = val.DateCreation;
                i++;
            }
            
            JavaScriptSerializer js = new JavaScriptSerializer();
            
            string json = js.Serialize(liste);
            return json;
        }


        //
        // GET: /Equipement/Jsonhum
        public string Jsonhum(int id)
        {
            Equipement equipement = db.Equipements.Find(id);


            IEnumerable<Value> value = db.Values.Where(equi => equi.EquipementID == id).OrderBy(equi => equi.DateCreation).ToList();
            int n = value.Count();
            DateTime[] url = new DateTime[n];

            int i = 0;

            List<object[]> liste = new List<object[]>();
            foreach (Value val in value)
            {
                var date = (long)(val.DateCreation - new DateTime(1970, 1, 1)).TotalMilliseconds;
                liste.Add(new object[] { date, val.humidity });
                url[i] = val.DateCreation;
                i++;
            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            string json = js.Serialize(liste);
            return json;
        }
        public ReportResult EquipementReport()
        {
            var report = new Report(db.Equipements.ToList().ToReportSource());
            
            var reportstyle = new ReportStyle();
            reportstyle.HorizontalAlignment = HorizontalAlignment.Center;
            reportstyle.VerticalAlignment = VerticalAlignment.Middle;
            reportstyle.ForeColor = System.Drawing.Color.Brown;
            
            // Customize the Text Fields
            report.TextFields.Title = "Liste des équipements";
            report.TextFields.Footer = "Copyright 2014 &copy; MaySoft";
            report.DataFields["Notes"].Hidden = true;
            /* report.TextFields.Header = string.Format(@"
            zone: {0}
            Location: {1}", db.Equipements.Count(),2);*/
            // Render hints allow you to pass additional hints to the reports as they are being rendered
            report.RenderHints.BooleanCheckboxes = true;
            report.RenderHints.IncludePageNumbers = true;
            report.RenderHints["HtmlStyle"] = ".htmlReport .title{}";
            report.RenderHints["PdfStyle"] = ".pdfReport .title{font: 21px Verdana;}";
            report.DataFields["Zones"].Hidden = true;
            report.DataFields["Sensors"].Hidden = true;
            report.DataFields["Values"].Hidden = true;
            report.DataFields["Responsables"].Hidden = true;
            foreach (var dataField in report.DataFields)
            {
                dataField.HeaderStyle.BackColor = System.Drawing.Color.CadetBlue;
                dataField.HeaderStyle.ForeColor = System.Drawing.Color.White;
                dataField.DataStyle.BackColor = System.Drawing.Color.MintCream;
                dataField.HeaderStyle.VerticalAlignment = reportstyle.VerticalAlignment;
                dataField.HeaderStyle.Underline = false;
            }
            // Return the ReportResult
            // the type of report that is rendered will be determined by the extension in the URL (.pdf, .xls, .html, etc)
            return new ReportResult(report);
        }
    }
}