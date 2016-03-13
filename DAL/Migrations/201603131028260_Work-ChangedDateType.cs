using System.Data.Entity.Migrations;

namespace Bookva.DAL.Migrations
{
    public partial class WorkChangedDateType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Works", "DateAdded", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Works", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Works", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Works", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
