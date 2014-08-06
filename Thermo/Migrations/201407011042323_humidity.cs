namespace Thermo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class humidity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Values", "humidity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Values", "humidity");
        }
    }
}
