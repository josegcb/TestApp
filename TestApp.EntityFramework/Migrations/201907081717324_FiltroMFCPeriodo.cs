namespace TestApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class FiltroMFCPeriodo : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Cuenta_Periodo",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
        }
        
        public override void Down()
        {
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Cuenta_Periodo",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
