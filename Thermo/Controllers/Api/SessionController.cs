using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using Thermo.DAL;
using Thermo.Filters;
using Thermo.Models;
using WebMatrix.WebData;

namespace Thermo.Controllers.Api
{
    public class Users
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool coki { get; set; }


    }
    public class ResponseSession
    {
        public string Value { get; set; }
        public string firtname { get; set; }
        public string lastname { get; set; }
    }
    public class SessionController : ApiController
    {
       

            //
            // POST : api/Session
            ModuleEquipementContext db = new ModuleEquipementContext();
            [System.Web.Mvc.HttpPost]
            public HttpResponseMessage PostSession([FromBody] Users user)
            {
                ResponseSession reponse = new ResponseSession();
                
                if (WebSecurity.IsAuthenticated)
                {
                    string username = WebSecurity.CurrentUserName;
                    string firstname = db.Profils.Where(c => c.UserID == WebSecurity.CurrentUserId).First().Prenom;
                    string lastname = db.Profils.Where(c => c.UserID == WebSecurity.CurrentUserId).First().Nom;
                    reponse.Value = "true";
                    reponse.firtname = firstname;
                    reponse.lastname = lastname;

                    return Request.CreateResponse(HttpStatusCode.OK, reponse);
                }
                reponse.Value = "false";
                return Request.CreateResponse(HttpStatusCode.OK, reponse);
            }

            // GET api/Session
            public ResponseSession GetSession()
            {
                ResponseSession reponse = new ResponseSession();

                if (WebSecurity.IsAuthenticated)
                {
                    string username = WebSecurity.CurrentUserName;
                    string firstname = db.Profils.Where(c => c.UserID == WebSecurity.CurrentUserId).First().Prenom;
                    string lastname = db.Profils.Where(c => c.UserID == WebSecurity.CurrentUserId).First().Nom;
                    reponse.Value = "true";
                    reponse.firtname = firstname;
                    reponse.lastname = lastname;


                }
                else
                {
                    reponse.Value = "false";
                    
                    reponse.firtname = "";
                    reponse.lastname = "";
                }
                return reponse;
            }
        
    }
}
