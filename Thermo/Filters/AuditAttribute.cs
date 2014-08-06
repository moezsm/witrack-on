using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thermo.DAL;
using Thermo.Models;

namespace Thermo.Filters
{
    public class AuditAttribute : ActionFilterAttribute
    {
        public int AuditingLevel { get; set; }
        public string actiontype { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Stores the Request in an Accessible object
          var request = filterContext.HttpContext.Request;
          //Generate an audit
          Audit audit = new Audit()
          {
               //Your Audit Identifier     
               AuditID = Guid.NewGuid(),
               //Our Username (if available)
               UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
               //The IP Address of the Request
               IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
               //The URL that was accessed
               AreaAccessed =  request.RawUrl,
               //Creates our Timestamp
               Timestamp = DateTime.UtcNow,
               //type action 
               action = actiontype
          };

            
          //Stores the Audit in the Database
          ModuleEquipementContext context = new ModuleEquipementContext();
          context.Audits.Add(audit);
          context.SaveChanges();

          //Finishes executing the Action as normal 
          base.OnActionExecuting(filterContext);
        }

        
        private string GetType()
        {
            switch (AuditingLevel)
            {
                //No Request Data will be serialized
                case 0:
                default:
                    return "zero";
                //Basic Request Serialization - just stores Data
                case 1:
                //Middle Level - Customize to your Preferences
                     return "first case";
                    
            }
        }
    }
    
}