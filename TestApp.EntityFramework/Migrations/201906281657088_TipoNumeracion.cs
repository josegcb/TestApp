namespace TestApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoNumeracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoNumeracion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200, unicode: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nombre, unique: true, name: "U_TipoNumeracionNombre");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TipoNumeracion", "U_TipoNumeracionNombre");
            DropTable("dbo.TipoNumeracion");
        }
    }
}
