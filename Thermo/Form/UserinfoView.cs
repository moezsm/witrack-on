using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thermo.DAL;
using Thermo.Models;

namespace Thermo.Form
{
    public class UserinfoView
    {
        
        ModuleEquipementContext db = new ModuleEquipementContext();
        public IEnumerable<string> selectedValues { get; set; }
        public IEnumerable<SelectListItem> userlist
        {
            
            get 
            {
                List<Profil> user = db.Profils.ToList();
                return new[]
            {
                new SelectListItem { Value = "1", Text = "item 1" },
                new SelectListItem { Value = "2", Text = "item 2" },
                new SelectListItem { Value = "3", Text = "item 3" },
            };
            }
        }
    }
}