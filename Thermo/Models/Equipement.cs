using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thermo.DAL;
using System.Data;
using System.Data.Entity;

namespace Thermo.Models
{
    public class Equipement
    {
        public int EquipementID { get; set; }
        public string Name { get; set; }
        public int ZoneID { get; set; }
        public DateTime DateCreation { get; set; }
        public int SensorID { get; set; }
        public int? HighAlarm { get; set; }
        public int? LowAlarm { get; set; }
        public string Numero { get; set; }
        public int UserID { get; set; }
        public int? FirstAlarm { get; set; }
        public int RepititionAlarm { get; set; }

        public virtual Zone Zones { get; set; }
        public virtual Sensor Sensors { get; set; }
        public virtual ICollection<Value> Values { get; set; }
        public virtual ICollection<Responsable> Responsables { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Alarme> Alarmes { get; set; }

        ModuleEquipementContext db = new ModuleEquipementContext();
        public float getLastmeasure()
        {
            float last = 0;
            int id = this.EquipementID;
            if (db.Values.Where(equ => equ.EquipementID == id).Any())
            {
                IEnumerable<Value> value = db.Values.Where(equ => equ.EquipementID == id).ToList();
                foreach (Value item in value.Reverse())
                {
                    last = item.Val;
                    break;
                }
            }
            return last;
        }
        public decimal getLasthumidite()
        {
            decimal last = 0;
            int id = this.EquipementID;
            if (db.Values.Where(equ => equ.EquipementID == id).Any())
            {
                IEnumerable<Value> value = db.Values.Where(equ => equ.EquipementID == id).ToList();
                foreach (Value item in value.Reverse())
                {
                    last = item.humidity;
                    break;
                }
            }
            return last;
        }
        public DateTime getLastdate()
        {
            int id = this.EquipementID;
            if (!db.Values.Where(equ => equ.EquipementID == id).Any())
            {
                return DateTime.Now;
            }
            return db.Values.Where(equ => equ.EquipementID == id).Max(e => e.DateCreation);
        }
        public float getAverage()
        {
            float moy = 0;
            int id = this.EquipementID;
            float somme = 0;
            int n = 0;
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            if (db.Values.Where(equ => equ.EquipementID == id).Any())
            {
                IEnumerable<Value> value = db.Values.Where(equ => equ.EquipementID == id & equ.DateCreation.ToString("yyyy/MM/dd") == date).ToList();
                n = value.Count();
                foreach (Value item in value.Reverse())
                {
                    somme += item.Val;
                }
                moy = somme / n;
            }
            return moy;
        }
        public float getMax()
        {
            float max = 0;
            int id = this.EquipementID;
            if (db.Values.Where(equ => equ.EquipementID == id).Any())
            {
                max = db.Values.Where(equ => equ.EquipementID == id).Max(a => a.Val);
               
            }
           
            return max;
        }
        public float getMin()
        {
            float min = 0;
            int id = this.EquipementID;
            if (db.Values.Where(equ => equ.EquipementID == id).Any())
            {
                min = db.Values.Where(equ => equ.EquipementID == id).Min(e => e.Val);
                
            }
            return min;
        }
    }
}