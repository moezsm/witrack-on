using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thermo.Models;
using Thermo.DAL;
using System.Web.Security;
using WebMatrix.WebData;

namespace Thermo.Controllers
{
    [Authorize()]
    public class ProfilController : BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();
        private UsersContext db2 = new UsersContext();
        //
        // GET: /Profil/

        public ActionResult Index()
        {
            IEnumerable<Profil> listprofil ;
            if (Roles.IsUserInRole("super_admin"))
            {
                listprofil = db.Profils.ToList();
            }
            else
            {
                listprofil = db.Profils.Where( c => c.UserID == WebSecurity.CurrentUserId).ToList();
            }
            return View(listprofil);
        }

        //
        // GET: /Profil/Details/5

        public ActionResult Details(int id = 0)
        {
            Profil profil = db.Profils.Find(id);
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        //
        // GET: /Profil/Create

        public ActionResult Create(string username)
        {
            
            var account = db2.UserProfiles.Where(acc => acc.UserName == username).ToList();
            int userid = 0;
            foreach (var ac in account)
            {
                userid = ac.UserId;
            }
            ViewData["id"] = userid;
            Profil profil = new Profil();
            
            db.Profils.Add(profil);
            profil.UserID = userid;
            profil.Nom = username;
            db.SaveChanges();
             Client client = new Client();
                    db.Clients.Add(client);
                    client.AdminID = WebSecurity.CurrentUserId;
                    client.UserID = userid;
                    db.SaveChanges();
            Profil profiledit = db.Profils.Find(profil.ProfilID);
            return RedirectToAction("Edit", new { id = profil.ProfilID });
        }

        //
        // POST: /Profil/Create
/*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profil profil)
        {
            if (ModelState.IsValid)
            {
                db.Profils.Add(profil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profil);
        }
            */
        //
        // GET: /Profil/Edit/5

        public ActionResult Edit(int id )
        {
            Profil profil = db.Profils.Find(id);
            if (profil == null)
            {
                return HttpNotFound();
            }
            ViewData["id"] = profil.UserID;
            return View(profil);
        }

        //
        // POST: /Profil/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Profil profil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profil);
        }

        //
        // GET: /Profil/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Profil profil = db.Profils.Find(id);
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        //
        // POST: /Profil/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profil profil = db.Profils.Find(id);
            var account = db2.UserProfiles.Where(acc => acc.UserId == profil.UserID).First();
            
            string username = "" ;
            
                username = account.UserName;

                string[] roles = Roles.GetRolesForUser(username);
                foreach (string role in roles)
                {
                    Roles.RemoveUserFromRole(username, role);
                }
            db.Profils.Remove(profil);
            Membership.DeleteUser(username, true);
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