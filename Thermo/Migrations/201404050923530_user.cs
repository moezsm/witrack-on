namespace Thermo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Zones", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Equipements", "ZoneID", "dbo.Zones");
            DropForeignKey("dbo.Equipements", "SensorID", "dbo.Sensors");
            DropForeignKey("dbo.Values", "EquipementID", "dbo.Equipements");
            DropForeignKey("dbo.Responsables", "EquipementID", "dbo.Equipements");
            DropForeignKey("dbo.Notes", "Equipement_EquipementID", "dbo.Equipements");
            DropForeignKey("dbo.Alarmes", "EquipementID", "dbo.Equipements");
            DropForeignKey("dbo.ProfilGroupes", "Profil_ProfilID", "dbo.Profils");
            DropForeignKey("dbo.ProfilGroupes", "Groupe_GroupeID", "dbo.Groupes");
            DropForeignKey("dbo.GroupeServices", "Groupe_GroupeID", "dbo.Groupes");
            DropForeignKey("dbo.GroupeServices", "Service_ServiceID", "dbo.Services");
            DropIndex("dbo.Zones", new[] { "LocationID" });
            DropIndex("dbo.Equipements", new[] { "ZoneID" });
            DropIndex("dbo.Equipements", new[] { "SensorID" });
            DropIndex("dbo.Values", new[] { "EquipementID" });
            DropIndex("dbo.Responsables", new[] { "EquipementID" });
            DropIndex("dbo.Notes", new[] { "Equipement_EquipementID" });
            DropIndex("dbo.Alarmes", new[] { "EquipementID" });
            DropIndex("dbo.ProfilGroupes", new[] { "Profil_ProfilID" });
            DropIndex("dbo.ProfilGroupes", new[] { "Groupe_GroupeID" });
            DropIndex("dbo.GroupeServices", new[] { "Groupe_GroupeID" });
            DropIndex("dbo.GroupeServices", new[] { "Service_ServiceID" });
            DropTable("dbo.Locations");
            DropTable("dbo.Zones");
            DropTable("dbo.Equipements");
            DropTable("dbo.Sensors");
            DropTable("dbo.Values");
            DropTable("dbo.Responsables");
            DropTable("dbo.Notes");
            DropTable("dbo.Alarmes");
            DropTable("dbo.Evenements");
            DropTable("dbo.Measurements");
            DropTable("dbo.Enregistrements");
            DropTable("dbo.Services");
            DropTable("dbo.Groupes");
            DropTable("dbo.Profils");
            DropTable("dbo.Clients");
            DropTable("dbo.ProfilGroupes");
            DropTable("dbo.GroupeServices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GroupeServices",
                c => new
                    {
                        Groupe_GroupeID = c.Int(nullable: false),
                        Service_ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Groupe_GroupeID, t.Service_ServiceID });
            
            CreateTable(
                "dbo.ProfilGroupes",
                c => new
                    {
                        Profil_ProfilID = c.Int(nullable: false),
                        Groupe_GroupeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profil_ProfilID, t.Groupe_GroupeID });
            
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
                "dbo.Groupes",
                c => new
                    {
                        GroupeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupeID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ServiceID);
            
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
                "dbo.Measurements",
                c => new
                    {
                        MeasurementID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MeasurementID);
            
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        EvenementID = c.Int(nullable: false, identity: true),
                        EvenementType = c.String(),
                    })
                .PrimaryKey(t => t.EvenementID);
            
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
                .PrimaryKey(t => t.AlarmeID);
            
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
                .PrimaryKey(t => t.NoteID);
            
            CreateTable(
                "dbo.Responsables",
                c => new
                    {
                        ResponsableID = c.Int(nullable: false, identity: true),
                        EquipementID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResponsableID);
            
            CreateTable(
                "dbo.Values",
                c => new
                    {
                        ValueId = c.Int(nullable: false, identity: true),
                        Val = c.Single(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        EquipementID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ValueId);
            
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        SensorID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.SensorID);
            
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
                .PrimaryKey(t => t.EquipementID);
            
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
                .PrimaryKey(t => t.ZoneID);
            
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
            
            CreateIndex("dbo.GroupeServices", "Service_ServiceID");
            CreateIndex("dbo.GroupeServices", "Groupe_GroupeID");
            CreateIndex("dbo.ProfilGroupes", "Groupe_GroupeID");
            CreateIndex("dbo.ProfilGroupes", "Profil_ProfilID");
            CreateIndex("dbo.Alarmes", "EquipementID");
            CreateIndex("dbo.Notes", "Equipement_EquipementID");
            CreateIndex("dbo.Responsables", "EquipementID");
            CreateIndex("dbo.Values", "EquipementID");
            CreateIndex("dbo.Equipements", "SensorID");
            CreateIndex("dbo.Equipements", "ZoneID");
            CreateIndex("dbo.Zones", "LocationID");
            AddForeignKey("dbo.GroupeServices", "Service_ServiceID", "dbo.Services", "ServiceID", cascadeDelete: true);
            AddForeignKey("dbo.GroupeServices", "Groupe_GroupeID", "dbo.Groupes", "GroupeID", cascadeDelete: true);
            AddForeignKey("dbo.ProfilGroupes", "Groupe_GroupeID", "dbo.Groupes", "GroupeID", cascadeDelete: true);
            AddForeignKey("dbo.ProfilGroupes", "Profil_ProfilID", "dbo.Profils", "ProfilID", cascadeDelete: true);
            AddForeignKey("dbo.Alarmes", "EquipementID", "dbo.Equipements", "EquipementID", cascadeDelete: true);
            AddForeignKey("dbo.Notes", "Equipement_EquipementID", "dbo.Equipements", "EquipementID");
            AddForeignKey("dbo.Responsables", "EquipementID", "dbo.Equipements", "EquipementID", cascadeDelete: true);
            AddForeignKey("dbo.Values", "EquipementID", "dbo.Equipements", "EquipementID", cascadeDelete: true);
            AddForeignKey("dbo.Equipements", "SensorID", "dbo.Sensors", "SensorID", cascadeDelete: true);
            AddForeignKey("dbo.Equipements", "ZoneID", "dbo.Zones", "ZoneID", cascadeDelete: true);
            AddForeignKey("dbo.Zones", "LocationID", "dbo.Locations", "LocationID", cascadeDelete: true);
        }
    }
}
