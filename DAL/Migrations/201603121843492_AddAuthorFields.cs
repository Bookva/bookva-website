namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "PictureSource", c => c.String(maxLength: 255));
            AddColumn("dbo.Authors", "Pseudonym", c => c.String(maxLength: 35));
            AddColumn("dbo.Authors", "UsePseudonym", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "UsePseudonym");
            DropColumn("dbo.Authors", "Pseudonym");
            DropColumn("dbo.Authors", "PictureSource");
        }
    }
}
