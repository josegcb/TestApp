using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using TestApp.DataFilters;
using TestApp.EntityFramework;

namespace TestApp
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(TestAppCoreModule))]
    public class TestAppDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TestAppDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
            Configuration.UnitOfWork.RegisterFilter(new DataFilterPeriodo().FilterName, true);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
