using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thermo.Models;
using Thermo.DAL;

using System.Collections;
using Thermo.Form;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;

namespace Thermo.Controllers
{
    [Authorize()]
    public class GroupeController : BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();
        private UsersContext db2 = new UsersContext();

        //
        // GET: /Groupe/

        public ActionResult Index()
        {
            return View(db.Groupes.ToList());
        }

        //
        // GET: /Groupe/Details/5

        public ActionResult Details(int id = 0)
        {
            Groupe groupe = db.Groupes.Find(id);
            if (groupe == null)
            {
                return HttpNotFound();
            }
            return View(groupe);
        }

        //
        // GET: /Groupe/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Groupe/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Groupe groupe)
        {
            if (ModelState.IsValid)
            {
                db.Groupes.Add(groupe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupe);
        }

        //
        // GET: /Groupe/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Groupe groupe = db.Groupes.Find(id);
            if (groupe == null)
            {
                return HttpNotFound();
            }
            return View(groupe);
        }

        //
        // POST: /Groupe/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Groupe groupe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupe);
        }

        //
        // GET: /Groupe/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Groupe groupe = db.Groupes.Find(id);
            if (groupe == null)
            {
                return HttpNotFound();
            }
            return View(groupe);
        }

        //
        // POST: /Groupe/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Groupe groupe = db.Groupes.Find(id);
            db.Groupes.Remove(groupe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private MultiSelectList GetUsers(string[] selectedValues)
        {
            IEnumerable<UserProfile> listuser = db2.UserProfiles.ToList();
            return new MultiSelectList(listuser, "UserId", "UserName", selectedValues );
        }
        //
        // GET: /Groupe/adduser/5

        public ActionResult adduser(int id = 0)
        {
            IEnumerable<UserProfile> listuser = db2.UserProfiles.ToList();
           
            IEnumerable<Profil> profils = db.Profils.Where(c => c.Groupes.Any(g => g.GroupeID == id)).ToList();

            int i = 0;
            string[] selectedValues = new string[50] ;
            foreach (var profil in profils)
            {
                selectedValues[i] = profil.UserID.ToString();
                i++;
            }
            ViewData["id"] = selectedValues;
            ViewBag.Userlist = GetUsers(selectedValues);
            return View();
        }

        //
        // POST: /Groupe/adduser/5
        [HttpPost]
        public ActionResult adduser(FormCollection form, int id = 0)
        {
            ViewBag.YouSelected = form["listuser"];
            string[] listslected = new string[100];
            int profilid = 0;
            string selectedValues = form["listuser"];
            if (selectedValues != null)
            {
                listslected = selectedValues.Split(',');
                foreach (string val in listslected)
                {
                    profilid = Convert.ToInt32(val);
                    if (!db.Groupes.Where(c => c.GroupeID == id && c.Profils.Any(p => p.UserID == profilid)).Any())
                    {
                        Profil profil = db.Profils.Where(p => p.UserID == profilid).First() ;
                        Groupe groupe = db.Groupes.Find(id);
                        groupe.Profils.Add(profil);
                        db.SaveChanges();
                    }
                }
                IEnumerable<Groupe> groupeprofil = db.Groupes.Where(c => c.GroupeID == id && c.Profils.Any()).ToList();
                IEnumerable<Profil> profilgroupe = db.Profils.Where(c => c.Groupes.Any(g => g.GroupeID == id)).ToList();

                foreach (Profil profil in profilgroupe)
                {
                    bool test = false;
                    foreach (string val in listslected)
                    {
                        profilid = Convert.ToInt32(val);
                        if (profil.UserID == profilid)
                        {
                            test = true;
                        }
                    }
                    if (!test)
                    {
                        Groupe groupe = db.Groupes.Find(id);
                        profil.Groupes.Remove(groupe);
                        db.SaveChanges();
                    }
                }
                ViewBag.Userlist = GetUsers(selectedValues.Split(','));
            }
            else
            {
                
                    Groupe groupe = db.Groupes.Find(id);
                    IEnumerable<Profil> listprofile = db.Profils.Where(p => p.Groupes.Any(g => g.GroupeID == id)).ToList();
                    foreach (Profil profil in listprofile)
                    {
                        groupe.Profils.Remove(profil);
                        db.SaveChanges();
                    }
                
                ViewBag.Userlist = GetUsers(null);
            }
            return View();
        }

        //
        // Get: /Groupe/sms

        public ActionResult sms()
        {

            /*string accountSid = "AC74710f48b09d6a1d3049fda3cc6cfcb3";
            string authToken = "a35fbb3e1d38b238cca74d7eed1539e5";
            var twilio = new TwilioRestClient(accountSid, authToken);
            var account = twilio.GetAccount(accountSid);
            var message = twilio.SendMessage("+14199389406", "+21620605420", "Hello world");
             Hashtable h = new Hashtable();
             h.Add("Form", "+4199389406");
             h.Add("To", "+21620605420");
             h.Add("Body", "Hello world");
             var account = T
            ViewData["acount"] = message.Sid;*/
           WebClient client = new WebClient ();
            // Add a user agent header in case the requested URI contains a query.

           /* client.Headers.Add ("user-agent", "Mozilla/4.0(compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.QueryString.Add("AccountId", "maysoft");
            client.QueryString.Add("SubAccountId", "maysoft_std");
            client.QueryString.Add("Password", "tresore1");
            client.QueryString.Add("Destination", "55605422");
            client.QueryString.Add("Source", "moez");
            client.QueryString.Add("Body", "test");
            client.QueryString.Add("Encoding", "ASCII");
            client.QueryString.Add("ScheduledDateTime", "");
            client.QueryString.Add("UMID", "");*/

            //********work ******//
              /*client.Headers.Add("user-agent", "Mozilla/4.0(compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
              client.QueryString.Add("app", "webservices");
              client.QueryString.Add("ta", "pv");
              client.QueryString.Add("u", "user122");
              client.QueryString.Add("p", "user122pass");
              client.QueryString.Add("to", "21620605420");
              client.QueryString.Add("msg", "Message+de+test+de+la+sosciété+tunisienne+vasysms+moez");
            string baseurl = "http://portal.vazysms.com/index.php";
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader (data);
            string s = reader.ReadToEnd ();
            data.Close ();
            reader.Close();*/

           MailMessage message = new MailMessage();
           message.To.Add("+21620605420@txt.bell.ca");
           message.From = new MailAddress("maysoft.jerba@gmail.com", "App"); //See the note afterwards...
           message.Body = "This is your cell phone. How was your day?";


           SmtpClient smtp = new SmtpClient("smtp.gmail.com");
           smtp.EnableSsl = true;
           smtp.Port = 587;
           smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
           smtp.Credentials = new NetworkCredential("maysoft.jerba@gmail.com", "maysoft02");

           try
           {
               smtp.Send(message);

           }
           catch (Exception ex)
           {
               return View();
           }

            return View();
        }

        //
        // Get: /Groupe/Xml

        public ActionResult Xml()
        {

            new XDocument(
            new XElement("root",
             new XElement("someNode", "someValue")
             )
            )
            .Save("foo.xml");
            return View();
        } 
        
        //
        // Get: /Groupe/test

        public ActionResult test()
        {


            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}