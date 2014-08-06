using Mvc.Mailer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thermo.Models;
using Thermo.DAL;

namespace Thermo.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
        ModuleEquipementContext db = new ModuleEquipementContext();
		public UserMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage HightAlarme( float val, int equipementid)
		{
			ViewBag.Data = val;
            Equipement equipement = db.Equipements.Find(equipementid);
            ViewData["equipementname"] = equipement.Name;

            ViewData["date"] = DateTime.Now;
            ViewData["zone"] = equipement.Zones.Name;
            ViewData["location"] = equipement.Zones.Location.Name;
            if (db.Responsables.Where(r => r.EquipementID == equipementid).Any())
            {
                IEnumerable<Responsable> listeresponsable = db.Responsables.Where(r => r.EquipementID == equipementid).ToList();
                foreach (Responsable responsable in listeresponsable)
                {

                    Profil profil = db.Profils.Where(p => p.UserID == responsable.UserID).First();

                    return Populate(x =>
                    {
                        x.Subject = "HightAlarme";
                        x.ViewName = "HightAlarme";
                        x.To.Add(profil.Mail);
                    });
                }
            }
            return Populate(x =>
            {
                x.Subject = "HightAlarme" + equipementid;
                x.ViewName = "HightAlarme";
                x.To.Add("rojbimoezsm@gmail.com");
            });
		}
 
		public virtual MvcMailMessage Contact()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "Contact";
				x.ViewName = "Contact";
				x.To.Add("some-email@example.com");
			});
		}

        public virtual MvcMailMessage LowLevel(float val, int equipementid)
		{
			//ViewBag.Data = someObject;

            Equipement equipement = db.Equipements.Find(equipementid);
            ViewData["equipementname"] = equipement.Name;
            ViewData["date"] = DateTime.Now;
            ViewData["zone"] = equipement.Zones.Name;
            ViewData["location"] = equipement.Zones.Location.Name;

            var resources = new Dictionary<string, string>();

            MvcMailMessage mailMessage = new MvcMailMessage();
            if (db.Responsables.Where(r => r.EquipementID == equipementid).Any())
            {
                IEnumerable<Responsable> listeresponsable = db.Responsables.Where(r => r.EquipementID == equipementid).ToList();
                foreach (Responsable responsable in listeresponsable)
                {

                    Profil profil = db.Profils.Where(p => p.UserID == responsable.UserID).First();

                    
                    return Populate(x =>
                    {
                        x.Subject = "LowLevel";
                        x.ViewName = "LowLevel";

                        x.To.Add(profil.Mail);
                    });
                }
            }
			return Populate(x =>
			{
				x.Subject = "LowLevel" + equipementid;
				x.ViewName = "LowLevel";
                x.To.Add("rojbimoezsm@gmail.com");
			});
		}
 	}
}