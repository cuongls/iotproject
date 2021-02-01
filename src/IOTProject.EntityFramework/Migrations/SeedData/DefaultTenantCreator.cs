using System.Linq;
using IOTProject.EntityFramework;
using IOTProject.MultiTenancy;

namespace IOTProject.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly IOTProjectDbContext _context;

        public DefaultTenantCreator(IOTProjectDbContext context)
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
