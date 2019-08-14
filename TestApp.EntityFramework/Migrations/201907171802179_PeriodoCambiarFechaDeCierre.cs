namespace TestApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeriodoCambiarFechaDeCierre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Periodo", "FechaDeCierre", c => c.DateTime(nullable: false));
            Sql("UPDATE dbo.Periodo SET FechaDeCierre = FechaDeCierrre");
            DropColumn("dbo.Periodo", "FechaDeCierrre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Periodo", "FechaDeCierrre", c => c.DateTime(nullable: false));
            DropColumn("dbo.Periodo", "FechaDeCierre");
        }
    }
}
