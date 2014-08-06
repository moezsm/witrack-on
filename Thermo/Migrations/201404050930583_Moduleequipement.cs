namespace Thermo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moduleequipement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        ZoneID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LocationID = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZoneID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Equipements",
                c => new
                    {
                        EquipementID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ZoneID = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        SensorID = c.Int(nullable: false),
                        HighAlarm = c.Int(),
                        LowAlarm = c.Int(),
                        Numero = c.String(),
                        UserID = c.Int(nullable: false),
                        FirstAlarm = c.Int(),
                        RepititionAlarm = c.Int(),
                    })
                .PrimaryKey(t => t.EquipementID)
                .ForeignKey("dbo.Zones", t => t.ZoneID, cascadeDelete: true)
                .ForeignKey("dbo.Sensors", t => t.SensorID, cascadeDelete: true)
                .Index(t => t.ZoneID)
                .Index(t => t.SensorID);
            
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        SensorID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.SensorID);
            
            CreateTable(
                "dbo.Values",
                c => new
                    {
                        ValueId = c.Int(nullable: false, identity: true),
                        Val = c.Single(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        EquipementID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ValueId)
                .ForeignKey("dbo.Equipements", t => t.EquipementID, cascadeDelete: true)
                .Index(t => t.EquipementID);
            
            CreateTable(
                "dbo.Responsables",
                c => new
                    {
                        ResponsableID = c.Int(nullable: false, identity: true),
                        EquipementID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResponsableID)
                .ForeignKey("dbo.Equipements", t => t.EquipementID, cascadeDelete: true)
                .Index(t => t.EquipementID);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteID = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Datecreation = c.DateTime(nullable: false),
                        text = c.String(),
                        AlarmeID = c.Int(nullable: false),
                        Equipement_EquipementID = c.Int(),
                    })
                .PrimaryKey(t => t.NoteID)
                .ForeignKey("dbo.Equipements", t => t.Equipement_EquipementID)
                .Index(t => t.Equipement_EquipementID);
            
            CreateTable(
                "dbo.Alarmes",
                c => new
                    {
                        AlarmeID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Values = c.Single(nullable: false),
                        EquipementID = c.Int(nullable: false),
                        closed = c.String(),
                        NoteId = c.Int(),
                    })
                .PrimaryKey(t => t.AlarmeID)
                .ForeignKey("dbo.Equipements", t => t.EquipementID, cascadeDelete: true)
                .Index(t => t.EquipementID);
            
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        EvenementID = c.Int(nullable: false, identity: true),
                        EvenementType = c.String(),
                    })
                .PrimaryKey(t => t.EvenementID);
            
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        MeasurementID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MeasurementID);
            
            CreateTable(
                "dbo.Enregistrements",
                c => new
                    {
                        EnregistrementID = c.Int(nullable: false, identity: true),
                        Value = c.Single(nullable: false),
                        Sondeid = c.String(),
                        DateTimeValue = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EnregistrementID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ServiceID);
            
            CreateTable(
                "dbo.Groupes",
                c => new
                    {
                        GroupeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupeID);
            
            CreateTable(
                "dbo.Profils",
                c => new
                    {
                        ProfilID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Mail = c.String(),
                        Mailweekend = c.String(),
                        Mail3 = c.String(),
                        numero = c.Int(),
                        numero2 = c.Int(),
                        numero3 = c.Int(),
                    })
                .PrimaryKey(t => t.ProfilID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        AdminID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.ProfilGroupes",
                c => new
                    {
                        Profil_ProfilID = c.Int(nullable: false),
                        Groupe_GroupeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profil_ProfilID, t.Groupe_GroupeID })
                .ForeignKey("dbo.Profils", t => t.Profil_ProfilID, cascadeDelete: true)
                .ForeignKey("dbo.Groupes", t => t.Groupe_GroupeID, cascadeDelete: true)
                .Index(t => t.Profil_ProfilID)
                .Index(t => t.Groupe_GroupeID);
            
            CreateTable(
                "dbo.GroupeServices",
                c => new
                    {
                        Groupe_GroupeID = c.Int(nullable: false),
                        Service_ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Groupe_GroupeID, t.Service_ServiceID })
                .ForeignKey("dbo.Groupes", t => t.Groupe_GroupeID, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Service_ServiceID, cascadeDelete: true)
                .Index(t => t.Groupe_GroupeID)
                .Index(t => t.Service_ServiceID);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropIndex("dbo.GroupeServices", new[] { "Service_ServiceID" });
            DropIndex("dbo.GroupeServices", new[] { "Groupe_GroupeID" });
            DropIndex("dbo.ProfilGroupes", new[] { "Groupe_GroupeID" });
            DropIndex("dbo.ProfilGroupes", new[] { "Profil_ProfilID" });
            DropIndex("dbo.Alarmes", new[] { "EquipementID" });
            DropIndex("dbo.Notes", new[] { "Equipement_EquipementID" });
            DropIndex("dbo.Responsables", new[] { "EquipementID" });
            DropIndex("dbo.Values", new[] { "EquipementID" });
            DropIndex("dbo.Equipements", new[] { "SensorID" });
            DropIndex("dbo.Equipements", new[] { "ZoneID" });
            DropIndex("dbo.Zones", new[] { "LocationID" });
            DropForeignKey("dbo.GroupeServices", "Service_ServiceID", "dbo.Services");
            DropForeignKey("dbo.GroupeServices", "Groupe_GroupeID", "dbo.Groupes");
            DropForeignKey("dbo.ProfilGroupes", "Groupe_GroupeID", "dbo.Groupes");
            DropForeignKey("dbo.ProfilGroupes", "Profil_ProfilID", "dbo.Profils");
            DropForeignKey("dbo.Alarmes", "EquipementID", "dbo.Equipements");
            DropForeignKey("dbo.Notes", "Equipement_EquipementID", "dbo.Equipements");
            DropForeignKey("dbo.Responsables", "EquipementID", "dbo.Equipements");
            DropForeignKey("dbo.Values", "EquipementID", "dbo.Equipements");
            DropForeignKey("dbo.Equipements", "SensorID", "dbo.Sensors");
            DropForeignKey("dbo.Equipements", "ZoneID", "dbo.Zones");
            DropForeignKey("dbo.Zones", "LocationID", "dbo.Locations");
            DropTable("dbo.GroupeServices");
            DropTable("dbo.ProfilGroupes");
            DropTable("dbo.Clients");
            DropTable("dbo.Profils");
            DropTable("dbo.Groupes");
            DropTable("dbo.Services");
            DropTable("dbo.Enregistrements");
            DropTable("dbo.Measurements");
            DropTable("dbo.Evenements");
            DropTable("dbo.Alarmes");
            DropTable("dbo.Notes");
            DropTable("dbo.Responsables");
            DropTable("dbo.Values");
            DropTable("dbo.Sensors");
            DropTable("dbo.Equipements");
            DropTable("dbo.Zones");
            DropTable("dbo.Locations");
        }
    }
}
