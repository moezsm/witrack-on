namespace Thermo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repeat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Equipements", "RepititionAlarm", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipements", "RepititionAlarm", c => c.Int());
        }
    }
}
