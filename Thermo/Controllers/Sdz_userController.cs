using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace Thermo.Controllers
{
    public class Sdz_userController : Controller
    {
        //
        // GET: /Sdz_user/

        public ActionResult Index()
        {
            Sdz_userBusinessLayer sdz_user = new Sdz_userBusinessLayer();
            List<Sdz_user> sdz_uzers = sdz_user.Sdz_users.ToList();

            return View(sdz_uzers);
        }
        [HttpGet]
        [ActionName("Create")]
        // GET : /Sdz_user/create
        public ActionResult Create_get()
        {

            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_post()
        {

            Sdz_user sdz_user = new Sdz_user();
            UpdateModel(sdz_user);

            if (ModelState.IsValid)
            {
                Sdz_userBusinessLayer sdz_userBusinessLayer = new Sdz_userBusinessLayer();
                sdz_userBusinessLayer.AddSdz_user(sdz_user);
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
