namespace Bookva.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_DateAdded_YearAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Works", "YearCreated", c => c.Short());
            DropColumn("dbo.Works", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Works", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Works", "YearCreated");
        }
    }
}
