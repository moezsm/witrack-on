using DoddleReport;
using DoddleReport.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thermo.DAL;

namespace Thermo.Controllers
{
    public class ReportController : BaseController
    {
        //
        // GET: /Report/
        ModuleEquipementContext db = new ModuleEquipementContext();
        public ActionResult EquipementDetail(int id)
        {
            var report = new Report(db.Values.Where(c => c.EquipementID == id).ToList().ToReportSource());
            string NameEquipement = db.Equipements.Find(id).Name;
            string NameZone = db.Zones.Find(db.Equipements.Find(id).ZoneID).Name;
            string NameLocation = db.Locations.Find(db.Equipements.Find(id).ZoneID).Name;
            var reportstyle = new ReportStyle();
            

            reportstyle.HorizontalAlignment = HorizontalAlignment.Center;
            reportstyle.VerticalAlignment = VerticalAlignment.Middle;
            reportstyle.ForeColor = System.Drawing.Color.Brown;

            // Render hints allow you to pass additional hints to the reports as they are being rendered
            report.RenderHints.BooleanCheckboxes = true;
            report.RenderHints.IncludePageNumbers = true;

            // Customize the Text Fields
            report.TextFields.Title = "Liste des équipements";
            report.TextFields.Footer = "Copyright 2014 &copy; MaySoft";
             report.TextFields.Header = string.Format(@"
            Equipement: {0}
            Zone: {1}
            Location: {2}", NameEquipement,NameZone,NameLocation);

             report.DataFields["Equipements"].Hidden = true;
             report.DataFields["EquipementID"].Hidden = true;
             
             
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
        public ReportResult ListZone()
        {
            var report = new Report(db.Zones.ToList().ToReportSource());

            var reportstyle = new ReportStyle();
            reportstyle.HorizontalAlignment = HorizontalAlignment.Center;
            reportstyle.VerticalAlignment = VerticalAlignment.Middle;
            reportstyle.ForeColor = System.Drawing.Color.Brown;

            // Customize the Text Fields
            report.TextFields.Title = "Liste des zones";
            report.TextFields.Footer = "Copyright 2014 &copy; MaySoft";
            /* report.TextFields.Header = string.Format(@"
            zone: {0}
            Location: {1}", db.Equipements.Count(),2);*/
            // Render hints allow you to pass additional hints to the reports as they are being rendered
            report.RenderHints.BooleanCheckboxes = true;
            report.RenderHints.IncludePageNumbers = true;

            report.DataFields["Location"].Hidden = true;
            report.DataFields["Equipements"].Hidden = true;
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
