namespace TestApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Periodo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Periodo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(nullable: false),
                        TipoNumeracionId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        FechaDeApertura = c.DateTime(nullable: false),
                        FechaDeCierre = c.DateTime(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Periodo_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpTenants", t => t.TenantId, cascadeDelete: true)
                .ForeignKey("dbo.TipoNumeracion", t => t.TipoNumeracionId, cascadeDelete: true)
                .Index(t => t.TenantId)
                .Index(t => new { t.TenantId, t.Nombre }, unique: true, name: "U_Periodo")
                .Index(t => t.TipoNumeracionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Periodo", "TipoNumeracionId", "dbo.TipoNumeracion");
            DropForeignKey("dbo.Periodo", "TenantId", "dbo.AbpTenants");
            DropIndex("dbo.Periodo", new[] { "TipoNumeracionId" });
            DropIndex("dbo.Periodo", "U_Periodo");
            DropIndex("dbo.Periodo", new[] { "TenantId" });
            DropTable("dbo.Periodo",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Periodo_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
