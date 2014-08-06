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
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool coki { get; set; }


    }
    public class Reponse
    {
        public string Value { get; set; }
    }
    
    public class loginController : ApiController
    {
         //
        // POST : api/Login
        ModuleEquipementContext db = new ModuleEquipementContext();
        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage PostLogin([FromBody] User user)
        {
            Reponse reponse = new Reponse();
            if (WebSecurity.Login(user.username, user.password, true))
            {
                string username = WebSecurity.CurrentUserName;
                reponse.Value = "true";
                return Request.CreateResponse(HttpStatusCode.OK,reponse);
            }
            reponse.Value = "false";
            return Request.CreateResponse(HttpStatusCode.OK,reponse);
        }
    }
}
