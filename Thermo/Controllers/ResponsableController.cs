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
    [Authorize()]
    public class ResponsableController : BaseController
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();
        private UsersContext dbuser = new UsersContext();

        //
        // GET: /Responsable/

        public ActionResult Index()
        {
            var responsables = db.Responsables.Include(r => r.Equipements);
            var users = db.Equipements.ToList();
            return View(users);
        }

        //
        // GET: /Responsable/Details/5

        public ActionResult Details(int id = 0)
        {
            Responsable responsable = db.Responsables.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            return View(responsable);
        }
        private MultiSelectList GetUsers(string[] selectedValues)
        {
            IEnumerable<UserProfile> listuser = dbuser.UserProfiles.ToList();
            return new MultiSelectList(listuser, "UserId", "UserName", selectedValues);
        }
        //
        // GET: /Responsable/Create/5

        public ActionResult Create(int id)
        {
            IEnumerable<UserProfile> listuser = dbuser.UserProfiles.ToList();

            IEnumerable<Responsable> responsables = db.Responsables.Where(c => c.EquipementID == id).ToList();

            int i = 0;
            string[] selectedValues = new string[50];
            foreach (var profil in responsables)
            {
                selectedValues[i] = profil.UserID.ToString();
                i++;
            }
            ViewData["id"] = selectedValues;
            ViewBag.Userlist = GetUsers(selectedValues);
            return View();
        }

        //
        // POST: /Responsable/Create/5

        [HttpPost]
        public ActionResult Create(FormCollection form, int id)
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
                    if (!db.Responsables.Where(c => c.EquipementID == id && c.UserID == profilid).Any())
                    {
                        Responsable responsable = new Responsable();
                        responsable.UserID = profilid;
                        responsable.EquipementID = id;
                        db.Responsables.Add(responsable);
                        db.SaveChanges();
                    }
                }
                IEnumerable<Responsable> responsables = db.Responsables.Where(c => c.EquipementID == id).ToList();
                foreach (Responsable responsable in responsables)
                {
                    listslected = selectedValues.Split(',');
                    bool test = false;
                    foreach (string val in listslected)
                    {
                        profilid = Convert.ToInt32(val);
                        if (responsable.UserID == profilid)
                        {
                            test = true;
                        }
                    }
                    if (!test)
                    {
                        db.Responsables.Remove(responsable);
                        db.SaveChanges();
                    }
                }

                ViewBag.Userlist = GetUsers(selectedValues.Split(','));
            }
            else
            {
                IEnumerable<Responsable> responsables = db.Responsables.Where(c => c.EquipementID == id).ToList();
                foreach (Responsable responsable in responsables)
                {
                    db.Responsables.Remove(responsable);
                    db.SaveChanges();
                }
                ViewBag.Userlist = GetUsers(null);
            }
            return View();
        }

        /// <summary>
        /// for setup view model, after post the user selected fruits data
        /// </summary>
        private FruitViewModel GetFruitsModel(PostedFruits postedFruits, int id)
        {
            // setup properties
            var model = new FruitViewModel();
            var selectedFruits = new List<Fruit>();
            var postedFruitIds = new string[0];
            if (postedFruits == null) postedFruits = new PostedFruits();

            // if a view model array of posted fruits ids exists
            // and is not empty,save selected ids
            if (postedFruits.FruitIds != null && postedFruits.FruitIds.Any())
            {
                postedFruitIds = postedFruits.FruitIds;
            }

            // if there are any selected ids saved, create a list of fruits
            if (postedFruitIds.Any())
            {
                selectedFruits = FruitRepository.GetAll()
                 .Where(x => postedFruitIds.Any(s => x.Id.ToString().Equals(s)))
                 .ToList();
            }
            foreach (var selected in selectedFruits)
            {
                Responsable responsable = new Responsable();
                db.Responsables.Add(responsable);
                responsable.EquipementID = selected.Id;
                responsable.UserID = id;
                db.SaveChanges();
            }
                //setup a view model
            model.AvailableFruits = FruitRepository.GetAll().ToList();
            model.SelectedFruits = selectedFruits;
            model.PostedFruits = postedFruits;
            return model;
        }

        /// <summary>
        /// for setup initial view model for all fruits
        /// </summary>
        private FruitViewModel GetFruitsInitialModel()
        {
            //setup properties
            var model = new FruitViewModel();
            var selectedFruits = new List<Fruit>();

            //setup a view model
            model.AvailableFruits = FruitRepository.GetAll().ToList();
            model.SelectedFruits = selectedFruits;
            return model;
        }

        //
        // GET: /Responsable/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Responsable responsable = db.Responsables.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipementID = new SelectList(db.Equipements, "EquipementID", "Name", responsable.EquipementID);
            return View(responsable);
        }

        //
        // POST: /Responsable/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipementID = new SelectList(db.Equipements, "EquipementID", "Name", responsable.EquipementID);
            return View(responsable);
        }

        //
        // GET: /Responsable/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Responsable responsable = db.Responsables.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            return View(responsable);
        }

        //
        // POST: /Responsable/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Responsable responsable = db.Responsables.Find(id);
            db.Responsables.Remove(responsable);
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