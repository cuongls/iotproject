namespace IOTProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_sapxep_thongtinquanlys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DM_THONGTINQUANLY", "SAPXEP", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DM_THONGTINQUANLY", "SAPXEP");
        }
    }
}
