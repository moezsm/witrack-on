using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thermo.DAL;
using Thermo.Mailers;
using Thermo.Models;

namespace Thermo.Helpers
{
    public class Sonde
    {
        public string Sondeid { get; set; }
        public DateTime DateTimeValue { get; set; }
        public float Value { get; set; }
        public Decimal Humidity { get; set; }


    }
    public class AlarmeHelper
    {
        public static decimal getCount()
        {
            ModuleEquipementContext db = new ModuleEquipementContext();
            IEnumerable<Alarme> listalarme = db.Alarmes.ToList();
            return (decimal)listalarme.Count();
        }
        public static decimal getActive()
        {
            ModuleEquipementContext db = new ModuleEquipementContext();
            IEnumerable<Alarme> listalarme = db.Alarmes.ToList();
            return (decimal)listalarme.Where(a => a.closed == "No").ToList().Count();
        }
        public static void getAlarme(Sonde enreg)
        {
            ModuleEquipementContext db = new ModuleEquipementContext();
            if (db.Equipements.Where(equi => equi.Numero == enreg.Sondeid).Select(equi => equi.EquipementID).Any())
            {
                int id = db.Equipements.Where(equi => equi.Numero == enreg.Sondeid).Select(equi => equi.EquipementID).First();
                Value valeur = new Value();
                db.Values.Add(valeur);
                valeur.DateCreation = enreg.DateTimeValue.ToUniversalTime().AddHours(1);
                valeur.EquipementID = id;
                valeur.Val = enreg.Value;
                db.SaveChanges();
                setalarme(id, enreg, valeur);
            }
        }

        public static void setalarme(int id, Sonde enreg, Value valeur)
        {
            ModuleEquipementContext db = new ModuleEquipementContext();
            Alarme alarme = new Alarme();
            int hightalarm = db.Equipements.Where(equi => equi.EquipementID == id).Select(equi => equi.HighAlarm).First().Value;
            int lowalarm = db.Equipements.Where(equi => equi.EquipementID == id).Select(equi => equi.LowAlarm).First().Value;

            int firstalarme = db.Equipements.Where(equi => equi.EquipementID == id).Select(equi => equi.FirstAlarm).First().Value;
            IEnumerable<Alarme> empty = db.Alarmes.Where(alarm => alarm.EquipementID == id).ToList();
            if (enreg.Value >= hightalarm)
            {
                int test = 0;
                int intervalle = 0;
                foreach (Alarme alarm in empty)
                {
                    if (alarm.closed == "No")
                    {
                        test = 1;
                    }
                }
                if (test == 0)
                {

                    db.Alarmes.Add(alarme);
                    alarme.Values = enreg.Value;
                    alarme.Status = "Hight Alarme";
                    alarme.StartDate = DateTime.Now.ToUniversalTime();
                    alarme.EquipementID = id;
                    alarme.EndDate = DateTime.Now.ToUniversalTime();
                    alarme.closed = "No";
                    db.SaveChanges();
                    IUserMailer mailer = new UserMailer();
                    mailer.HightAlarme(enreg.Value, id).Send();

                }
            }
            if (enreg.Value <= lowalarm)
            {
                int test = 0;
                foreach (Alarme alarm in empty)
                {
                    if (alarm.closed == "No")
                    {
                        test = 1;
                    }
                }
                if (test == 0)
                {

                    db.Alarmes.Add(alarme);
                    alarme.Values = enreg.Value;
                    alarme.Status = "Low Alarme";
                    alarme.StartDate = DateTime.Now;
                    alarme.EquipementID = id;
                    alarme.EndDate = DateTime.Now;
                    alarme.closed = "No";
                    db.SaveChanges();
                    IUserMailer mailer = new UserMailer();
                    mailer.LowLevel(enreg.Value, id).Send();

                }
            }
        }
    }
}