namespace IOTProject.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class add_danhmuc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DM_DonVi",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NAME = c.String(maxLength: 100),
                        CODE = c.String(maxLength: 100),
                        ADDRESS = c.String(maxLength: 500),
                        DOMAIN = c.String(maxLength: 100),
                        DESCRIPTION = c.String(maxLength: 500),
                        TenantId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DM_DonVi_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DM_DonVi_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.DM_SENSOR",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NAME = c.String(maxLength: 100),
                        CODE = c.String(maxLength: 100),
                        DESCRIPTION = c.String(maxLength: 500),
                        TenantId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DM_SENSOR_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DM_SENSOR_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.DM_THONGTINQUANLY",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NAME = c.String(maxLength: 100),
                        CODE = c.String(maxLength: 100),
                        DESCRIPTION = c.String(maxLength: 500),
                        TenantId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DM_THONGTINQUANLY_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DM_THONGTINQUANLY_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.DM_TRANGTHAI",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NAME = c.String(maxLength: 100),
                        CODE = c.String(maxLength: 100),
                        DESCRIPTION = c.String(maxLength: 500),
                        TenantId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DM_TRANGTHAI_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DM_TRANGTHAI_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.DM_TRANGTHAI", new[] { "IsDeleted" });
            DropIndex("dbo.DM_TRANGTHAI", new[] { "TenantId" });
            DropIndex("dbo.DM_THONGTINQUANLY", new[] { "IsDeleted" });
            DropIndex("dbo.DM_THONGTINQUANLY", new[] { "TenantId" });
            DropIndex("dbo.DM_SENSOR", new[] { "IsDeleted" });
            DropIndex("dbo.DM_SENSOR", new[] { "TenantId" });
            DropIndex("dbo.DM_DonVi", new[] { "IsDeleted" });
            DropIndex("dbo.DM_DonVi", new[] { "TenantId" });
            DropTable("dbo.DM_TRANGTHAI",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DM_TRANGTHAI_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DM_TRANGTHAI_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DM_THONGTINQUANLY",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DM_THONGTINQUANLY_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DM_THONGTINQUANLY_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DM_SENSOR",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DM_SENSOR_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DM_SENSOR_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DM_DonVi",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DM_DonVi_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DM_DonVi_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
