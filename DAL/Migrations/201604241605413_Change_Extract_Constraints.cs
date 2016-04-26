namespace Bookva.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Extract_Constraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Works", "Extract1", c => c.String());
            AlterColumn("dbo.Works", "Extract2", c => c.String());
            AlterColumn("dbo.Works", "Extract3", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Works", "Extract3", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Works", "Extract2", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Works", "Extract1", c => c.String(maxLength: 4000));
        }
    }
}
