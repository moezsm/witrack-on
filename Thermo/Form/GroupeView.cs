using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thermo.DAL;
using Thermo.Models;

namespace Thermo.Form
{
    public class GroupeView
    {
        ModuleEquipementContext db = new ModuleEquipementContext();
        public List<string> Groupes { get; set; }
        public MultiSelectList  GroupeList {get; set;}

        public GroupeView()
        {
            this.GroupeList = GetGroupe(null);
        }

        public MultiSelectList GetGroupe(string selectedValues)
        {
            List<Groupe> groupes = db.Groupes.ToList();
            return new MultiSelectList(groupes, "GroupeID", "name", selectedValues);
            
        }
    }
}