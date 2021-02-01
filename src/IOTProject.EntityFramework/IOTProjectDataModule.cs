using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using IOTProject.EntityFramework;

namespace IOTProject
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(IOTProjectCoreModule))]
    public class IOTProjectDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<IOTProjectDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
