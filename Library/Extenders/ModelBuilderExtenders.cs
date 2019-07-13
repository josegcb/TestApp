using Library.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;


namespace Library.Extenders {
    public static class ModelBuilderExtenders {
        public static void ConfigureVarchar(this DbModelBuilder valModelBuilder) {
            valModelBuilder.Properties<string>().Configure(c => ConfigureVarchar(c));
        }

        private static void ConfigureVarchar(ConventionPrimitivePropertyConfiguration valConventionPrimitivePropertyConfiguration) {
            var vAttributes = valConventionPrimitivePropertyConfiguration.ClrPropertyInfo.GetCustomAttributes(typeof(VarcharAttribute), false);
            if (vAttributes.Length > 0) {
                valConventionPrimitivePropertyConfiguration.HasColumnType("varchar");
            }

        }

        public static void ConfigureTimestamp(this DbModelBuilder valModelBuilder) {
            valModelBuilder.Properties<Byte[]>().Configure(c => ConfigureTimestamp(c));
        }

        private static void ConfigureTimestamp(ConventionPrimitivePropertyConfiguration valConventionPrimitivePropertyConfiguration) {
            var vAttributes = valConventionPrimitivePropertyConfiguration.ClrPropertyInfo.GetCustomAttributes(typeof(TimestampAttribute), false);
            if (vAttributes.Length > 0 && valConventionPrimitivePropertyConfiguration.ClrPropertyInfo.Name.StartsWith("Timestamp", StringComparison.OrdinalIgnoreCase)) {
                valConventionPrimitivePropertyConfiguration.IsRowVersion();
            }
        }

        public static void ConfigureDecimal(this DbModelBuilder valModelBuilder) {
            valModelBuilder.Properties<decimal>().Configure(c => ConfigureDecimal(c));
        }

        private static void ConfigureDecimal(ConventionPrimitivePropertyConfiguration valConventionPrimitivePropertyConfiguration) {
            byte vPrecision = 18;
            byte vScale = 2;
            var vAttributes = valConventionPrimitivePropertyConfiguration.ClrPropertyInfo.GetCustomAttributes(typeof(DecimalAttribute), false);
            if (vAttributes.Length > 0) {
                foreach (DecimalAttribute vAttribute in vAttributes) {
                    vPrecision = vAttribute.Precision;
                    vScale = vAttribute.Scale;
                }
            }
            valConventionPrimitivePropertyConfiguration.HasPrecision(vPrecision, vScale);
        }
    }
}
