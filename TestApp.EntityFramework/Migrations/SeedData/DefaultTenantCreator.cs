using System.Linq;
using TestApp.EntityFramework;
using TestApp.MultiTenancy;

namespace TestApp.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly TestAppDbContext _context;

        public DefaultTenantCreator(TestAppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
