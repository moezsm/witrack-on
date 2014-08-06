namespace Thermo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profil : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profils", "Prenom", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profils", "Prenom", c => c.String(nullable: false));
        }
    }
}
