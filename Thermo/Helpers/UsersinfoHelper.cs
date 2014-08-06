using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thermo.DAL;
using Thermo.Models;

using System.Threading;

namespace Thermo.Helpers
{
    public class UsersinfoHelper
    {
        
        public static string getLastname(int userid)
        {
            ModuleEquipementContext db = new ModuleEquipementContext();
            string lastname = "";
            if (db.Profils.Where(p => p.UserID == userid).Any())
            {
                Profil profil = db.Profils.Where(p => p.UserID == userid).First();
                lastname = profil.Nom;
            }
            return lastname;
        }
        public static string getFirstname(int userid)
        {
            ModuleEquipementContext db = new ModuleEquipementContext();
            string firstname = "";
            if (db.Profils.Where(p => p.UserID == userid).Any())
            {
                Profil profil = db.Profils.Where(p => p.UserID == userid).First();
                firstname = profil.Prenom;
            }
            return firstname;
        }
        public static int getId(int userid)
        {
            ModuleEquipementContext db = new ModuleEquipementContext();
            int id = 0;
            if (db.Profils.Where(p => p.UserID == userid).Any())
            {
                Profil profil = db.Profils.Where(p => p.UserID == userid).First();
                id = profil.ProfilID;
            }
            return id;
        } 
    }
}