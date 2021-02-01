using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using IOTProject.EntityFramework;

namespace IOTProject.Migrator
{
    [DependsOn(typeof(IOTProjectDataModule))]
    public class IOTProjectMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<IOTProjectDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}