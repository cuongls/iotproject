namespace IOTProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_trangthai_thietbi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DM_ThietBi", "TRANGTHAI", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DM_ThietBi", "TRANGTHAI");
        }
    }
}
