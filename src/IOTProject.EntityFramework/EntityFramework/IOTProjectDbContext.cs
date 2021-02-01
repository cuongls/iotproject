using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityProperties;
using Abp.Zero.EntityFramework;
using IOTProject.Authorization.Roles;
using IOTProject.Authorization.Users;
using IOTProject.DanhMuc;
using IOTProject.MultiTenancy;
using IOTProject.ThongTin;

namespace IOTProject.EntityFramework
{
    public class IOTProjectDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public virtual IDbSet<DM_TRANGTHAI> DM_TRANGTHAI { get; set; }
        public virtual IDbSet<DM_DonVi> DM_DonVi { get; set; }
        public virtual IDbSet<DM_SENSOR> DM_SENSOR { get; set; }
        public virtual IDbSet<DM_THONGTINQUANLY> DM_THONGTINQUANLY { get; set; }
        public virtual IDbSet<DM_TRAM> DM_TRAM { get; set; }
        public virtual IDbSet<DM_ThietBi> DM_ThietBi { get; set; }
        public virtual IDbSet<ThongTin_ThietBi> ThongTin_ThietBi { get; set; }
        public IOTProjectDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in IOTProjectDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of IOTProjectDbContext since ABP automatically handles it.
         */
        public IOTProjectDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public IOTProjectDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public IOTProjectDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicProperty>().Property(p => p.PropertyName).HasMaxLength(250);
            modelBuilder.Entity<DynamicEntityProperty>().Property(p => p.EntityFullName).HasMaxLength(250);
        }
    }
}
