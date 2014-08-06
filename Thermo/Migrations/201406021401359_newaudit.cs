namespace Thermo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newaudit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Audits", "Field", c => c.String());
            AddColumn("dbo.Audits", "Oldvalue", c => c.String());
            AddColumn("dbo.Audits", "Newvalue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Audits", "Newvalue");
            DropColumn("dbo.Audits", "Oldvalue");
            DropColumn("dbo.Audits", "Field");
        }
    }
}
