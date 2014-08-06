using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using DXWebApplication1.Reports;
using DXWebApplication1.Models;
using Thermo.Helpers;
using Thermo.Models;
using Thermo.DAL;
namespace Thermo.Controllers
{
    [Authorize()]
    public class ReportdevController : Controller
    {
        ModuleEquipementContext db = new ModuleEquipementContext();
        //
        // GET: /Reportdev/
        
        public ActionResult Index()
        {
            return View();
        }
       
        //
        // GET: /Reportdev/Report/5
        public ActionResult Report(int id = 0)
        {
            Equipement equipement = db.Equipements.Find(id);
            DetailReport detail = new DetailReport();

            detail.username = UsersinfoHelper.getFirstname(WebSecurity.CurrentUserId) + " " + UsersinfoHelper.getLastname(WebSecurity.CurrentUserId);
            detail.EquipementID = id;
            detail.location = equipement.Zones.Location.Name;
            detail.zone = equipement.Zones.Name;
            detail.numerosonde = equipement.Numero;
            detail.max = (decimal)equipement.getMax();
            detail.min = (decimal)equipement.getMin();
            detail.datereport = DateTime.Now;
            detail.datefin = DateTime.Now;
            detail.datedebut = DateTime.Now;
            ViewData["detail"] = detail;
            DXWebApplication1.Reports.XtraReport1 report = new DXWebApplication1.Reports.XtraReport1(detail);
            
            ViewData["Report"] = report;

            return View();
        }
        // GET: /Reportdev/ReportCourbe/1
        public ActionResult ReportCourbe(int id = 0)
        {
            Equipement equipement = db.Equipements.Find(id);
            DetailReport detail = new DetailReport();

            detail.username = UsersinfoHelper.getFirstname(WebSecurity.CurrentUserId) + " " + UsersinfoHelper.getLastname(WebSecurity.CurrentUserId);
            detail.EquipementID = id;
            detail.location = equipement.Zones.Location.Name;
            detail.zone = equipement.Zones.Name;
            detail.numerosonde = equipement.Numero;
            detail.max = (decimal)equipement.getMax();
            detail.min = (decimal)equipement.getMin();
            detail.datereport = DateTime.Now;
            detail.datefin = DateTime.Now;
            detail.datedebut = DateTime.Now;
            detail.haute = equipement.HighAlarm;
            detail.basse = equipement.LowAlarm;
            detail.nomsonde = equipement.Name;
            ViewData["detail"] = detail;
            DXWebApplication1.Reports.XtraReport2 report = new DXWebApplication1.Reports.XtraReport2(detail);

            ViewData["Report"] = report;

            return View();
        }


        // GET: /Reportdev/ReportAlarmes/
        public ActionResult ReportAlarmes()
        {
            IEnumerable<Alarme> listalarme = db.Alarmes.ToList();
            DetailReport detail = new DetailReport();

            detail.username = UsersinfoHelper.getFirstname(WebSecurity.CurrentUserId) + " " + UsersinfoHelper.getLastname(WebSecurity.CurrentUserId);
            detail.EquipementID = 1;
            detail.max = (decimal)listalarme.Count();
            detail.min = (decimal)listalarme.Where(a => a.closed == "No").ToList().Count();
            detail.datereport = DateTime.Now;
            ViewData["detail"] = detail;
            DXWebApplication1.Reports.XtraReport3 report = new DXWebApplication1.Reports.XtraReport3(detail);

            ViewData["Report"] = report;
            return View();
        }

        public ActionResult ReportViewerPartial(int EquipementID, string username, string location, string zone, DateTime datereport, DateTime datedebut, DateTime datefin, string numerosonde, Decimal max, Decimal min)
        {

            ViewData["EquipementID"] = EquipementID;
            ViewData["username"] = username;
            ViewData["location"] = location;
            ViewData["zone"] = zone;
            ViewData["datereport"] = datereport;
            ViewData["datedebut"] = datedebut;
            ViewData["datefin"] = datefin;
            ViewData["numerosonde"] = numerosonde;
            ViewData["max"] = max;
            ViewData["min"] = min;
            DetailReport detail = new DetailReport();
            detail.EquipementID = EquipementID;
            detail.username = username;
            detail.location = location;
            detail.numerosonde = numerosonde;
            detail.zone = zone;
            detail.min = min;
            detail.max = max;
            detail.datedebut = datedebut;
            detail.datereport = datereport;
            detail.datefin = datefin;
            DXWebApplication1.Reports.XtraReport1 report = new DXWebApplication1.Reports.XtraReport1(detail);
            report.SetReportParameter(EquipementID);
            ViewData["Report"] = report;
            return PartialView("_ReportViewerPartial", report);
        }
        public ActionResult ReportViewerPartialExport(int EquipementID, string username, string location, string zone, DateTime datereport, DateTime datedebut, DateTime datefin, string numerosonde, Decimal max, Decimal min)
        {
            ViewData["EquipementID"] = EquipementID;
            ViewData["username"] = username;
            ViewData["location"] = location;
            ViewData["zone"] = zone;
            ViewData["datereport"] = datereport;
            ViewData["datedebut"] = datedebut;
            ViewData["datefin"] = datefin;
            ViewData["numerosonde"] = numerosonde;
            ViewData["max"] = max;
            ViewData["min"] = min;
            DetailReport detail = new DetailReport();
            detail.EquipementID = EquipementID;
            detail.username = username;
            detail.location = location;
            detail.numerosonde = numerosonde;
            detail.zone = zone;
            detail.min = min;
            detail.max = max;
            detail.datedebut = datedebut;
            detail.datereport = datereport;
            detail.datefin = datefin;
            DXWebApplication1.Reports.XtraReport1 report = new DXWebApplication1.Reports.XtraReport1(detail);
            report.SetReportParameter(EquipementID);
            ViewData["Report"] = report;
            return DevExpress.Web.Mvc.ReportViewerExtension.ExportTo(report);
        }


        public ActionResult ReportViewerPartial2(int EquipementID, string username, string location, string zone, DateTime datereport, DateTime datedebut, DateTime datefin, string numerosonde, Decimal max, Decimal min, int haute, int basse, string nomsonde)
        {

            ViewData["EquipementID"] = EquipementID;
            ViewData["username"] = username;
            ViewData["location"] = location;
            ViewData["zone"] = zone;
            ViewData["datereport"] = datereport;
            ViewData["datedebut"] = datedebut;
            ViewData["datefin"] = datefin;
            ViewData["numerosonde"] = numerosonde;
            ViewData["max"] = max;
            ViewData["min"] = min;
            ViewData["haute"] = haute;
            ViewData["basse"] = basse;

            ViewData["nom"] = nomsonde;
            DetailReport detail = new DetailReport();
            detail.EquipementID = EquipementID;
            detail.username = username;
            detail.location = location;
            detail.numerosonde = numerosonde;
            detail.zone = zone;
            detail.min = min;
            detail.max = max;
            detail.datedebut = datedebut;
            detail.datereport = datereport;
            detail.datefin = datefin;
            detail.haute = haute;
            detail.basse = basse;
            detail.nomsonde = nomsonde;
            DXWebApplication1.Reports.XtraReport2 report = new DXWebApplication1.Reports.XtraReport2(detail);
            report.SetReportParameter(EquipementID, haute, basse);
            ViewData["Report"] = report;
            return PartialView("_ReportViewerPartial2", report);
        }
        public ActionResult ReportViewerPartialExport2(int EquipementID, string username, string location, string zone, DateTime datereport, DateTime datedebut, DateTime datefin, string numerosonde, Decimal max, Decimal min, int haute, int basse, string nomsonde)
        {

            ViewData["EquipementID"] = EquipementID;
            ViewData["username"] = username;
            ViewData["location"] = location;
            ViewData["zone"] = zone;
            ViewData["datereport"] = datereport;
            ViewData["datedebut"] = datedebut;
            ViewData["datefin"] = datefin;
            ViewData["numerosonde"] = numerosonde;
            ViewData["max"] = max;
            ViewData["min"] = min;
            ViewData["haute"] = haute;
            ViewData["basse"] = basse;
            ViewData["nom"] = nomsonde;

            DetailReport detail = new DetailReport();
            detail.EquipementID = EquipementID;
            detail.username = username;
            detail.location = location;
            detail.numerosonde = numerosonde;
            detail.zone = zone;
            detail.min = min;
            detail.max = max;
            detail.datedebut = datedebut;
            detail.datereport = datereport;
            detail.datefin = datefin;
            detail.haute = haute;
            detail.basse = basse;
            detail.nomsonde = nomsonde;
            DXWebApplication1.Reports.XtraReport2 report = new DXWebApplication1.Reports.XtraReport2(detail);
            report.SetReportParameter(EquipementID, haute, basse);
            ViewData["Report"] = report;
            return DevExpress.Web.Mvc.ReportViewerExtension.ExportTo(report);
        }

        public ActionResult ReportViewerPartial3(int EquipementID, string username, string location, string zone, DateTime datereport, DateTime datedebut, DateTime datefin, string numerosonde, Decimal max, Decimal min)
        {
            ViewData["EquipementID"] = EquipementID;
            ViewData["username"] = username;
            ViewData["location"] = location;
            ViewData["zone"] = zone;
            ViewData["datereport"] = datereport;
            ViewData["datedebut"] = datedebut;
            ViewData["datefin"] = datefin;
            ViewData["numerosonde"] = numerosonde;
            ViewData["max"] = max;
            ViewData["min"] = min;
            DetailReport detail = new DetailReport();
            detail.EquipementID = EquipementID;
            detail.username = username;
            detail.location = location;
            detail.numerosonde = numerosonde;
            detail.zone = zone;
            detail.min = min;
            detail.max = max;
            detail.datedebut = datedebut;
            detail.datereport = datereport;
            detail.datefin = datefin;
            DXWebApplication1.Reports.XtraReport3 report = new DXWebApplication1.Reports.XtraReport3(detail);
            ViewData["Report"] = report;
            return PartialView("_ReportViewerPartial3", report);
        }
        public ActionResult ReportViewerPartialExport3(int EquipementID, string username, string location, string zone, DateTime datereport, DateTime datedebut, DateTime datefin, string numerosonde, Decimal max, Decimal min)
        {
            ViewData["EquipementID"] = EquipementID;
            ViewData["username"] = username;
            ViewData["location"] = location;
            ViewData["zone"] = zone;
            ViewData["datereport"] = datereport;
            ViewData["datedebut"] = datedebut;
            ViewData["datefin"] = datefin;
            ViewData["numerosonde"] = numerosonde;
            ViewData["max"] = max;
            ViewData["min"] = min;
            DetailReport detail = new DetailReport();
            detail.EquipementID = EquipementID;
            detail.username = username;
            detail.location = location;
            detail.numerosonde = numerosonde;
            detail.zone = zone;
            detail.min = min;
            detail.max = max;
            detail.datedebut = datedebut;
            detail.datereport = datereport;
            detail.datefin = datefin;
            DXWebApplication1.Reports.XtraReport3 report = new DXWebApplication1.Reports.XtraReport3(detail);
            ViewData["Report"] = report;
            return DevExpress.Web.Mvc.ReportViewerExtension.ExportTo(report);
        }
        
    }
}
