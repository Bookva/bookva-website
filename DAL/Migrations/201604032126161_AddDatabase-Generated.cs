namespace Bookva.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabaseGenerated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "DateAdded", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
