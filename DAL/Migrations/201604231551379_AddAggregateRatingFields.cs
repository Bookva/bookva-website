namespace Bookva.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAggregateRatingFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkRatings", "Work_Id", "dbo.Works");
            DropForeignKey("dbo.WorkRatings", "User_Id", "dbo.Users");
            DropIndex("dbo.WorkRatings", new[] { "User_Id" });
            DropIndex("dbo.WorkRatings", new[] { "Work_Id" });
            RenameColumn(table: "dbo.WorkRatings", name: "Work_Id", newName: "WorkId");
            RenameColumn(table: "dbo.WorkRatings", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Works", "TotalVotes", c => c.Int(nullable: false));
            AddColumn("dbo.Works", "AverageRating", c => c.Single(nullable: false));
            AlterColumn("dbo.WorkRatings", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkRatings", "WorkId", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkRatings", "UserId");
            CreateIndex("dbo.WorkRatings", "WorkId");
            AddForeignKey("dbo.WorkRatings", "WorkId", "dbo.Works", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkRatings", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkRatings", "UserId", "dbo.Users");
            DropForeignKey("dbo.WorkRatings", "WorkId", "dbo.Works");
            DropIndex("dbo.WorkRatings", new[] { "WorkId" });
            DropIndex("dbo.WorkRatings", new[] { "UserId" });
            AlterColumn("dbo.WorkRatings", "WorkId", c => c.Int());
            AlterColumn("dbo.WorkRatings", "UserId", c => c.Int());
            DropColumn("dbo.Works", "AverageRating");
            DropColumn("dbo.Works", "TotalVotes");
            RenameColumn(table: "dbo.WorkRatings", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.WorkRatings", name: "WorkId", newName: "Work_Id");
            CreateIndex("dbo.WorkRatings", "Work_Id");
            CreateIndex("dbo.WorkRatings", "User_Id");
            AddForeignKey("dbo.WorkRatings", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.WorkRatings", "Work_Id", "dbo.Works", "Id");
        }
    }
}
