using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using Thermo.Controllers.Api;
using Thermo.DAL;
using Thermo.Filters;
using Thermo.Mailers;
using Thermo.Models;
using Thermo.Services;
using WebMatrix.WebData;
namespace Thermo.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController :  BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext(); 
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewData["user"] = User.Identity.Name;


            return RedirectToAction("Login", "Account", new { returnUrl = "../Home/Dashbord" }); 
        }
        public ActionResult Validate()
        {
            //ViewData["query"] = query;
            return View();
        }
        [Authorize() ]
        public async Task<ActionResult> Dashbord()
        {

            int clientid = 0;
            DashbordService dashbordservice = new DashbordService();
            LocationService locationservice = new LocationService();
            if (db.Clients.Where(c => c.UserID == WebSecurity.CurrentUserId).Any())
            {
                clientid = db.Clients.Where(c => c.UserID == WebSecurity.CurrentUserId).First().AdminID;
            }

            Task<IEnumerable<Location>> locations = dashbordservice.GetLocationAsync(clientid);
            Task<IEnumerable<Zone>> zones = dashbordservice.GetZoneAsync(clientid);
            Task<IEnumerable<Equipement>> equipement = dashbordservice.GetEquipementAsync(clientid);

            await Task.WhenAll(locations, zones, equipement);
            ViewData["location"] = locations.Result;
            ViewData["zone"] = zones.Result;
            ViewData["equipement"] = equipement.Result;
            ViewData["user"] = User.Identity.Name;



            return View();
        }

        //
        //Get: /Test/5
        [Audit(AuditingLevel = 1) ]
        public ActionResult test(int id=0)
        {
            DashbordService dashbordservice = new DashbordService();
            int clientid = 0;


            if (db.Clients.Where(c => c.UserID == WebSecurity.CurrentUserId).Any())
            {
                clientid = db.Clients.Where(c => c.UserID == WebSecurity.CurrentUserId).First().AdminID;
            }


            Task<IEnumerable<Equipement>> equipement = dashbordservice.GetEquipementAsync(clientid);

            ViewData["equipement"] = equipement.Result;
            Random rnd = new Random();
            ViewData["random"] = rnd.Next(1, 5);

            return View();
        }


        [OutputCache(NoStore = true, Location = OutputCacheLocation.Client, Duration = 3)] // every 3 sec

        public ActionResult GetOverview()
        {
            DashbordService dashbordservice = new DashbordService();
            int clientid = 0;


            if (db.Clients.Where(c => c.UserID == WebSecurity.CurrentUserId).Any())
            {
                clientid = db.Clients.Where(c => c.UserID == WebSecurity.CurrentUserId).First().AdminID;
            }


            Task<IEnumerable<Equipement>> equipement = dashbordservice.GetEquipementAsync(clientid);

            ViewData["equipement"] = equipement.Result;
            Random rnd = new Random();
            ViewData["random"] = rnd.Next(1, 5);

            return PartialView("Overview", ViewData["equipement"]);



        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            ViewData["user"] = User.Identity.Name;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewData["user"] = User.Identity.Name;

            return View();
        }
    }
}
