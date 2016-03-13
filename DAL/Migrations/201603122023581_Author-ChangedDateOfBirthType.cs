using System.Data.Entity.Migrations;

namespace Bookva.DAL.Migrations
{
    public partial class AuthorChangedDateOfBirthType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "DateOfBirth", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
