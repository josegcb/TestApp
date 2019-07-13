using TestApp.EntityFramework;
using EntityFramework.DynamicFilters;

namespace TestApp.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly TestAppDbContext _context;

        public InitialHostDbBuilder(TestAppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
