namespace TestApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Comprobante : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comprobante",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeriodoId = c.Int(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Numero = c.String(nullable: false, maxLength: 30, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 300, unicode: false),
                        Fecha = c.DateTime(nullable: false),
                        TotalDebe = c.Decimal(nullable: false, precision: 18, scale: 5),
                        TotalHaber = c.Decimal(nullable: false, precision: 18, scale: 5),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Comprobante_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Comprobante_Periodo", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Periodo", t => t.PeriodoId, cascadeDelete: true)
                .ForeignKey("dbo.AbpTenants", t => t.TenantId, cascadeDelete: false)
                .Index(t => new { t.PeriodoId, t.Numero }, unique: true, name: "U_Comprobante")
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.ComprobanteDetalleCuenta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComprobanteId = c.Int(nullable: false),
                        CuentaId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 300, unicode: false),
                        Fecha = c.DateTime(nullable: false),
                        MontDebe = c.Decimal(nullable: false, precision: 18, scale: 5),
                        MontoHaber = c.Decimal(nullable: false, precision: 18, scale: 5),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobante", t => t.ComprobanteId, cascadeDelete: true)
                .ForeignKey("dbo.Cuenta", t => t.CuentaId, cascadeDelete: false)
                .Index(t => t.ComprobanteId)
                .Index(t => t.CuentaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comprobante", "TenantId", "dbo.AbpTenants");
            DropForeignKey("dbo.Comprobante", "PeriodoId", "dbo.Periodo");
            DropForeignKey("dbo.ComprobanteDetalleCuenta", "CuentaId", "dbo.Cuenta");
            DropForeignKey("dbo.ComprobanteDetalleCuenta", "ComprobanteId", "dbo.Comprobante");
            DropIndex("dbo.ComprobanteDetalleCuenta", new[] { "CuentaId" });
            DropIndex("dbo.ComprobanteDetalleCuenta", new[] { "ComprobanteId" });
            DropIndex("dbo.Comprobante", new[] { "TenantId" });
            DropIndex("dbo.Comprobante", "U_Comprobante");
            DropTable("dbo.ComprobanteDetalleCuenta");
            DropTable("dbo.Comprobante",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Comprobante_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Comprobante_Periodo", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
