namespace Thermo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inheritence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipements", "ThsensorID", c => c.Int());
            AddColumn("dbo.Equipements", "HumidityHighAlarm", c => c.Int());
            AddColumn("dbo.Equipements", "HumidityLowAlarm", c => c.Int());
            AddColumn("dbo.Equipements", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipements", "Discriminator");
            DropColumn("dbo.Equipements", "HumidityLowAlarm");
            DropColumn("dbo.Equipements", "HumidityHighAlarm");
            DropColumn("dbo.Equipements", "ThsensorID");
        }
    }
}
