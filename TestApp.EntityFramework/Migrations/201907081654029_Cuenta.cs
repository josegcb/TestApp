namespace TestApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Cuenta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cuenta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeriodoId = c.Int(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 30, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 300, unicode: false),
                        EsTitulo = c.Boolean(nullable: false),
                        Naturaleza = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Cuenta_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Periodo", t => t.PeriodoId, cascadeDelete: true)
                .ForeignKey("dbo.AbpTenants", t => t.TenantId, cascadeDelete: false)
                .Index(t => new { t.PeriodoId, t.Codigo }, unique: true, name: "U_Cuenta")
                .Index(t => t.TenantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cuenta", "TenantId", "dbo.AbpTenants");
            DropForeignKey("dbo.Cuenta", "PeriodoId", "dbo.Periodo");
            DropIndex("dbo.Cuenta", new[] { "TenantId" });
            DropIndex("dbo.Cuenta", "U_Cuenta");
            DropTable("dbo.Cuenta",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Cuenta_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
