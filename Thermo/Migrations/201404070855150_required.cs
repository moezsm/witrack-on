namespace Thermo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profils", "Prenom", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profils", "Prenom", c => c.String());
        }
    }
}
