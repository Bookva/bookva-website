namespace Bookva.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPicturePreviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "PreviewPictureSource", c => c.String(maxLength: 255));
            AddColumn("dbo.Works", "PreviewCoverSource", c => c.String(maxLength: 255));
            AddColumn("dbo.Users", "PictureSource", c => c.String(maxLength: 255));
            AddColumn("dbo.Users", "PreviewPictureSource", c => c.String(maxLength: 255));
            AlterColumn("dbo.Works", "CoverSource", c => c.String(maxLength: 255));
            DropColumn("dbo.Users", "ImageSource");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ImageSource", c => c.String());
            AlterColumn("dbo.Works", "CoverSource", c => c.String());
            DropColumn("dbo.Users", "PreviewPictureSource");
            DropColumn("dbo.Users", "PictureSource");
            DropColumn("dbo.Works", "PreviewCoverSource");
            DropColumn("dbo.Authors", "PreviewPictureSource");
        }
    }
}
