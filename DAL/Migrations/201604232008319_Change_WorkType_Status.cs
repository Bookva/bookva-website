namespace Bookva.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_WorkType_Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Works", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Works", "WorkType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Works", "WorkType", c => c.Int(nullable: false));
            DropColumn("dbo.Works", "Status");
        }
    }
}
