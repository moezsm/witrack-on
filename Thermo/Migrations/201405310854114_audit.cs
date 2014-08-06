namespace Thermo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class audit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Audits", "action", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Audits", "action");
        }
    }
}
