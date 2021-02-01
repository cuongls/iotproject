namespace IOTProject.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class add_danhmuc_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DM_ThietBi",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IDTRAM = c.Long(nullable: false),
                        NAME = c.String(maxLength: 100),
                        CODE = c.String(maxLength: 100),
                        IP = c.String(maxLength: 100),
                        PORT_INFO = c.String(maxLength: 500),
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
                    { "DynamicFilter_DM_ThietBi_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DM_ThietBi_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DM_TRAM", t => t.IDTRAM, cascadeDelete: true)
                .Index(t => t.IDTRAM)
                .Index(t => t.TenantId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.DM_TRAM",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IDDONVI = c.Long(nullable: false),
                        NAME = c.String(maxLength: 100),
                        CODE = c.String(maxLength: 100),
                        ADDRESS = c.String(maxLength: 500),
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
                    { "DynamicFilter_DM_TRAM_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DM_TRAM_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DM_DonVi", t => t.IDDONVI, cascadeDelete: true)
                .Index(t => t.IDDONVI)
                .Index(t => t.TenantId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.ThongTin_ThietBi",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IDTHIETBI = c.Long(nullable: false),
                        IDTHONGTINQUANLY = c.Long(nullable: false),
                        TRANGTHAI = c.String(maxLength: 100),
                        DESCRIPTION = c.String(maxLength: 100),
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
                    { "DynamicFilter_ThongTin_ThietBi_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ThongTin_ThietBi_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DM_ThietBi", t => t.IDTHIETBI, cascadeDelete: true)
                .ForeignKey("dbo.DM_THONGTINQUANLY", t => t.IDTHONGTINQUANLY, cascadeDelete: true)
                .Index(t => t.IDTHIETBI)
                .Index(t => t.IDTHONGTINQUANLY)
                .Index(t => t.TenantId)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThongTin_ThietBi", "IDTHONGTINQUANLY", "dbo.DM_THONGTINQUANLY");
            DropForeignKey("dbo.ThongTin_ThietBi", "IDTHIETBI", "dbo.DM_ThietBi");
            DropForeignKey("dbo.DM_ThietBi", "IDTRAM", "dbo.DM_TRAM");
            DropForeignKey("dbo.DM_TRAM", "IDDONVI", "dbo.DM_DonVi");
            DropIndex("dbo.ThongTin_ThietBi", new[] { "IsDeleted" });
            DropIndex("dbo.ThongTin_ThietBi", new[] { "TenantId" });
            DropIndex("dbo.ThongTin_ThietBi", new[] { "IDTHONGTINQUANLY" });
            DropIndex("dbo.ThongTin_ThietBi", new[] { "IDTHIETBI" });
            DropIndex("dbo.DM_TRAM", new[] { "IsDeleted" });
            DropIndex("dbo.DM_TRAM", new[] { "TenantId" });
            DropIndex("dbo.DM_TRAM", new[] { "IDDONVI" });
            DropIndex("dbo.DM_ThietBi", new[] { "IsDeleted" });
            DropIndex("dbo.DM_ThietBi", new[] { "TenantId" });
            DropIndex("dbo.DM_ThietBi", new[] { "IDTRAM" });
            DropTable("dbo.ThongTin_ThietBi",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ThongTin_ThietBi_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ThongTin_ThietBi_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DM_TRAM",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DM_TRAM_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DM_TRAM_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DM_ThietBi",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DM_ThietBi_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DM_ThietBi_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
