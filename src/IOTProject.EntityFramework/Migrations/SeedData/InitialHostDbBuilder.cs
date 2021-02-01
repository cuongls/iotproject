using IOTProject.EntityFramework;
using EntityFramework.DynamicFilters;

namespace IOTProject.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly IOTProjectDbContext _context;

        public InitialHostDbBuilder(IOTProjectDbContext context)
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
