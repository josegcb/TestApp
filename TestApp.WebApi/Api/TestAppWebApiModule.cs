using System;
using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Domain.Repositories;
using Abp.Modules;
using Abp.WebApi;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Library.Repositories;
using Library.Services;
using TestApp.EntityFramework.Repositories;
using TestApp.Managers;
using TestApp.Managers.Interface;
using TestApp.Models;
using TestApp.Services;

namespace TestApp.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(TestAppApplicationModule))]
    public class TestAppWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            
            IocManager.IocContainer.Register(Component.For(typeof(IManagerBase<>)).ImplementedBy(typeof(ManagerBase<>)).LifestylePerWebRequest());

            IocManager.IocContainer.Register(Component.For(typeof(IManagerBase<Comprobante>)).ImplementedBy(typeof(ComprobanteManager<>)).LifestylePerWebRequest());
            //Registro de manager con Interface propia
            IocManager.IocContainer.Register(Component.For<IManagerBase<Cuenta>, ICuentaManager>().ImplementedBy(typeof(CuentaManager<>)).LifestylePerWebRequest());



            IocManager.IocContainer.Register(Component.For(typeof(TipoNumeracion)));
            IocManager.IocContainer.Register(Component.For(typeof(Periodo)));
            IocManager.IocContainer.Register(Component.For(typeof(Cuenta)));
            IocManager.IocContainer.Register(Component.For(typeof(Comprobante)));
            IocManager.IocContainer.Register(Component.For(typeof(ComprobanteDetalleCuenta)));


            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(TestAppApplicationModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
            Library.Helpers.SwaggerHelper.ConfigureSwaggerUi<TestAppWebApiModule>(Configuration, "TestApp.WebApi");
            Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = false;

        }

        public override void PreInitialize() {
            base.PreInitialize();
            IocManager.IocContainer.Register(Component.For(typeof(ITestAppGenericRepository<>)).ImplementedBy(typeof(TestAppRepositoryBase<>)).LifestylePerWebRequest());                    }
    }

}
