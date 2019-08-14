namespace TestApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cambiodenombre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComprobanteDetalleCuenta", "MontoDebe", c => c.Decimal(nullable: false, precision: 18, scale: 5));
            Sql("UPDATE ComprobanteDetalleCuenta SET MontoDebe = MontDebe");
            DropColumn("dbo.ComprobanteDetalleCuenta", "MontDebe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ComprobanteDetalleCuenta", "MontDebe", c => c.Decimal(nullable: false, precision: 18, scale: 5));
            DropColumn("dbo.ComprobanteDetalleCuenta", "MontoDebe");
        }
    }
}
