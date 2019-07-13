using Abp.Configuration.Startup;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Library.Helpers {
    public class SwaggerHelper {
        public static void ConfigureSwaggerUi<T>(IAbpStartupConfiguration vCconfiguration, string vName) {
            vCconfiguration.Modules.AbpWebApi().HttpConfiguration
                .EnableSwagger(c => {
                    c.SingleApiVersion("v1", vName);
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                })
                .EnableSwaggerUi(c => {
                    c.InjectJavaScript(Assembly.GetAssembly(typeof(T)), "Library.Scripts.Swagger-Custom.js");
                });
        }

    }
}
