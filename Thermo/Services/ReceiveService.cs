using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Thermo.DAL;
using Thermo.Helpers;
using Thermo.Mailers;
using Thermo.Models;

namespace Thermo.Services
{
    public class ReceiveService
    {
        private ModuleEquipementContext db = new ModuleEquipementContext();
        public async Task<Value> GetFirsvalueAsync(int id)
        {
            Value values = db.Values.Where(equi => equi.EquipementID == id).First();
            return values;
        }
        public async Task<Enregistrement> setEnregAsync(Sonde enreg)
        {
            Enregistrement value = new Enregistrement();


            db.Enregistrements.Add(value);
            value.Sondeid = enreg.Sondeid;
            value.DateTimeValue = enreg.DateTimeValue;
            value.Value = enreg.Value;
            
            db.SaveChanges();
            return value;
        }
        public async Task<Value> setValueAsync(Sonde enreg)
        {
            Value valeur = new Value();
            ModuleEquipementContext db = new ModuleEquipementContext();
            if (db.Equipements.Where(equi => equi.Numero == enreg.Sondeid).Select(equi => equi.EquipementID).Any())
            {
                int id = db.Equipements.Where(equi => equi.Numero == enreg.Sondeid).Select(equi => equi.EquipementID).First();
               
                db.Values.Add(valeur);
                valeur.DateCreation = enreg.DateTimeValue;

                valeur.EquipementID = id;
                valeur.Val = enreg.Value;
                valeur.humidity = enreg.Humidity;
                db.SaveChanges();
                Task<Alarme> setalarme = setalarmeAsync(id, enreg, valeur);
                
                
                 await Task.WhenAll(setalarme);
                
                return valeur;
                
            }
            return valeur;
        }
        public async Task<Alarme> setalarmeAsync(int id, Sonde enreg, Value valeur)
        {
            ModuleEquipementContext db = new ModuleEquipementContext();
            Alarme alarme = new Alarme();
            
            EquipementService equipementservice = new EquipementService();
            AlarmeService alarmeservice = new AlarmeService();

            Task<Equipement> equipement = equipementservice.GetEquipementAsync(id);
            Task<IEnumerable<Alarme>> alarmes = alarmeservice.GetListAsync(id);
            Task < IEnumerable < Value >> listvalue = equipementservice.GetListvaluedecendAsync(id);
            await Task.WhenAll(equipement, alarmes, listvalue);
            int? hightalarm = equipement.Result.HighAlarm;
            int? lowalarm = equipement.Result.LowAlarm;

            int? firstalarme = equipement.Result.FirstAlarm;
            int rappale = equipement.Result.RepititionAlarm;
            if (enreg.Value >= hightalarm)
            {
                Task<Boolean> isintervalle = IsIntervalle(listvalue.Result, valeur, firstalarme, hightalarm);
                await Task.WhenAll(isintervalle);
                Boolean test = true;
                foreach (Alarme alarm in alarmes.Result)
                {
                    if (alarm.fin == "No")
                    {
                        test = false;
                    }
                }
                if (test)
                {
                    if (isintervalle.Result)
                    {
                        db.Alarmes.Add(alarme);
                        alarme.Values = enreg.Value;
                        alarme.Status = "Hight Alarme";
                        alarme.StartDate = DateTime.Now.ToUniversalTime().AddHours(1);

                        alarme.EquipementID = id;
                        alarme.EndDate = DateTime.Now.ToUniversalTime().AddHours(1);
                        alarme.closed = "No";
                        alarme.fin = "No";
                        db.SaveChanges();
                        if (rappale != null)
                        {
                            Task<Boolean> repeat = Repiter(rappale, id, enreg, valeur);
                        }
                        IUserMailer mailer = new UserMailer();
                        mailer.HightAlarme(enreg.Value, id).Send();
                    }
                }

            }

            else if (enreg.Value <= lowalarm)
            {
                Task<Boolean> isintervallelow = IsIntervallelow(listvalue.Result, valeur, firstalarme, lowalarm);
                await Task.WhenAll(isintervallelow);
                Boolean test = true;
                foreach (Alarme alarm in alarmes.Result)
                {
                    if (alarm.fin == "No")
                    {
                        test = false;
                    }
                }
                if (test)
                {
                    if (isintervallelow.Result)
                    {
                        db.Alarmes.Add(alarme);
                        alarme.Values = enreg.Value;
                        alarme.Status = "Low Alarme";
                        alarme.StartDate = DateTime.Now.ToUniversalTime().AddHours(1);

                        alarme.EquipementID = id;
                        alarme.EndDate = DateTime.Now.ToUniversalTime().AddHours(1);
                        alarme.closed = "No";
                        alarme.fin = "No";
                        db.SaveChanges();
                        if (rappale != null)
                        {
                            Task<Boolean> repeat = Repiter(rappale, id, enreg, valeur);
                        }
                        IUserMailer mailer = new UserMailer();
                        mailer.LowLevel(enreg.Value, id).Send();
                    }
                }

            }
            else
            {
                Boolean test = false;
                foreach (Alarme alarm in alarmes.Result)
                {
                    if (alarm.fin == "No")
                    {
                        Alarme al = db.Alarmes.Find(alarm.AlarmeID);
                        al.fin = "Yes";
                        al.EndDate = DateTime.Now.ToUniversalTime().AddHours(1);
                        db.SaveChanges();
                        
                    }
                    
                }
            }
            return alarme;
        }
        public async Task<Boolean> IsIntervalle(IEnumerable<Value> listvalue, Value valeur, int? firstalarme, int? higtalarme)
        {
            Boolean test = false;
            int n = listvalue.Count();
            int i = 0;
            int currentvalid = 0;
            int longeur = 0;
            Value[] tablevaleur = new Value[n];
            foreach(Value val in listvalue)
            {
                tablevaleur[i] = val;
                if (val.ValueId == valeur.ValueId)
                {
                    currentvalid = i;
 
                }
                i++;
            }
            longeur = n - currentvalid;
            for (int j = 1; j < longeur; j++)
            {
                if (tablevaleur[currentvalid + j].Val >= higtalarme)
                {
                    TimeSpan ts = valeur.DateCreation - tablevaleur[currentvalid + j].DateCreation;
                    int intervalle = ts.Minutes;
                    
                    if (intervalle >= firstalarme)
                    {
                        test = true;
                    }

                }
                else
                {
                    test = false;
                }
                
            }

            return test;
        }
        public async Task<Boolean> IsIntervallelow(IEnumerable<Value> listvalue, Value valeur, int? firstalarme, int? lowalarme)
        {
            Boolean test = false;
            int n = listvalue.Count();
            int i = 0;
            int currentvalid = 0;
            int longeur = 0;
            Value[] tablevaleur = new Value[n];
            foreach (Value val in listvalue)
            {
                tablevaleur[i] = val;
                if (val.ValueId == valeur.ValueId)
                {
                    currentvalid = i;

                }
                i++;
            }
            longeur = n - currentvalid;
            for (int j = 1; j < longeur; j++)
            {
                if (tablevaleur[currentvalid + j].Val <= lowalarme)
                {
                    TimeSpan ts = valeur.DateCreation - tablevaleur[currentvalid + j].DateCreation;
                    int intervalle = ts.Minutes;
                   
                    if (intervalle >= firstalarme)
                    {
                        test = true;
                    }

                }
                else
                {
                    test = false;
                }

            }

            return test;
        }

        public async Task<Boolean> Repiter(int rappele,int id, Sonde enreg, Value valeur )
        {
            bool test = true;
            Thread.Sleep(rappele * 60 * 1000);
            Equipement equipement = db.Equipements.Find(id);
            float mesure = equipement.getLastmeasure();
            if (mesure > equipement.HighAlarm)
            {
                Alarme alarme = new Alarme();
                db.Alarmes.Add(alarme);
                alarme.Values = enreg.Value;
                alarme.Status = "Rappelle pour Alarme haute";
                alarme.StartDate = DateTime.Now.ToUniversalTime().AddHours(1);

                alarme.EquipementID = id;
                alarme.EndDate = DateTime.Now.ToUniversalTime().AddHours(1);
                alarme.closed = "No";
                alarme.fin = "No";
                db.SaveChanges();
                IUserMailer mailer = new UserMailer();
                mailer.HightAlarme(enreg.Value, id).Send();
            }
            if (mesure < equipement.LowAlarm)
            {
                Alarme alarme = new Alarme();
                db.Alarmes.Add(alarme);
                alarme.Values = enreg.Value;
                alarme.Status = "Rappelle pour Alarme basse";
                alarme.StartDate = DateTime.Now.ToUniversalTime().AddHours(1);

                alarme.EquipementID = id;
                alarme.EndDate = DateTime.Now.ToUniversalTime().AddHours(1);
                alarme.closed = "No";
                alarme.fin = "No";
                db.SaveChanges();
                IUserMailer mailer = new UserMailer();
                mailer.LowLevel(enreg.Value, id).Send();
            }
            return test;
        }

    }
}