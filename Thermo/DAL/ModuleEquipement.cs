using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Thermo.Models;
using WebMatrix.WebData;

namespace Thermo.DAL
{
    
        public class ModuleEquipementContext : DbContext
        {

            public DbSet<Location> Locations { get; set; }
            public DbSet<Zone> Zones { get; set; }
            public DbSet<Equipement> Equipements { get; set; }
            public DbSet<Sensor> Sensors { get; set; }
            public DbSet<Value> Values { get; set; }
            public DbSet<Evenement> Evenements { get; set; }
            public DbSet<Alarme> Alarmes { get; set; }
            public DbSet<Measurement> Measurements { get; set; }
            public DbSet<Note> Notes { get; set; }
            public DbSet<Enregistrement> Enregistrements { get; set; }
            public DbSet<Responsable> Responsables { get; set; }
            public DbSet<Service> Services { get; set; }
            public DbSet<Client> Clients { get; set; }
            public DbSet<Profil> Profils { get; set; }
            public DbSet<Groupe> Groupes { get; set; }
            public DbSet<Audit> Audits { get; set; }
            public DbSet<Thsensor> Thsensors { get; set; }


            public override int SaveChanges()
            {
               /* // Get all Added/Deleted/Modified entities (not Unmodified or Detached)
                foreach (var ent in this.ChangeTracker.Entries().Where(p => p.State == System.Data.EntityState.Added || p.State == System.Data.EntityState.Deleted || p.State == System.Data.EntityState.Modified))
                {
                    // For each changed record, get the audit record entries and add them
                    foreach (Audit x in GetAuditRecordsForChanges(ent))
                    {
                        this.Audits.Add(x);
                    }
                }*/
                return base.SaveChanges();
            }

            private List<Audit> GetAuditRecordsForChanges(DbEntityEntry dbEntry)
            {
                List<Audit> result = new List<Audit>();

                DateTime changeTime = DateTime.UtcNow;

                // Get the Table() attribute, if one exists
                TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;

                // Get table name (if it has a Table attribute, use that, otherwise get the pluralized name)
                string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;

               
                if (dbEntry.State == System.Data.EntityState.Added)
                {
                    // For Inserts, just add the whole record
                    // If the entity implements IDescribableEntity, use the description from Describe(), otherwise use ToString()
                    result.Add(new Audit()
                    {
                        AuditID = Guid.NewGuid(),
                        UserName = WebSecurity.CurrentUserName, 
                        Timestamp = changeTime,
                        action = "Ajout dans " + tableName
                    }
                        );
                }
                else if (dbEntry.State == System.Data.EntityState.Deleted)
                {
                    // Same with deletes, do the whole record, and use either the description from Describe() or ToString()
                    result.Add(new Audit()
                    {
                        AuditID = Guid.NewGuid(),
                        UserName = WebSecurity.CurrentUserName,
                        Timestamp = changeTime,
                        action = "Suppretion dans " + tableName,

                    }
                        );
                }
                else if (dbEntry.State == System.Data.EntityState.Modified)
                {
                    foreach (string propertyName in dbEntry.OriginalValues.PropertyNames)
                    {
                        // For updates, we only want to capture the columns that actually changed
                        if (!object.Equals(dbEntry.OriginalValues.GetValue<object>(propertyName), dbEntry.CurrentValues.GetValue<object>(propertyName)))
                        {
                            result.Add(new Audit()
                            {
                                AuditID = Guid.NewGuid(),
                                UserName = WebSecurity.CurrentUserName,
                                Timestamp = changeTime,
                                action = "Suppretion dans " + tableName,
                                Field = propertyName,

                                Newvalue = dbEntry.CurrentValues.ToObject().ToString()
                            }
                                );
                        }
                    }
                }
                // Otherwise, don't do anything, we don't care about Unchanged or Detached entities

                return result;
            }

            

        }
    
}