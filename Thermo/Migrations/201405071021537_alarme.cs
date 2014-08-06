namespace Thermo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alarme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alarmes", "fin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alarmes", "fin");
        }
    }
}
