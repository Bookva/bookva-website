namespace Bookva.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Indexes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Works", "Extract1", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Works", "Extract2", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Works", "Extract3", c => c.String(maxLength: 4000));
            CreateIndex("dbo.Authors", "Name");
            CreateIndex("dbo.Authors", "Surname");
            CreateIndex("dbo.Authors", "Pseudonym");
            CreateIndex("dbo.Works", "Title");
            CreateIndex("dbo.Works", "DateAdded");
            CreateIndex("dbo.Works", "YearCreated");
            CreateIndex("dbo.Works", "Status");
            CreateIndex("dbo.Works", "TotalVotes");
            CreateIndex("dbo.Works", "AverageRating");
            CreateIndex("dbo.Genres", "Name", unique: true);
            CreateIndex("dbo.Keywords", "Name", unique: true);
            CreateIndex("dbo.Users", "RegistrationDate");
            CreateIndex("dbo.Reviews", "DateAdded");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Reviews", new[] { "DateAdded" });
            DropIndex("dbo.Users", new[] { "RegistrationDate" });
            DropIndex("dbo.Keywords", new[] { "Name" });
            DropIndex("dbo.Genres", new[] { "Name" });
            DropIndex("dbo.Works", new[] { "AverageRating" });
            DropIndex("dbo.Works", new[] { "TotalVotes" });
            DropIndex("dbo.Works", new[] { "Status" });
            DropIndex("dbo.Works", new[] { "YearCreated" });
            DropIndex("dbo.Works", new[] { "DateAdded" });
            DropIndex("dbo.Works", new[] { "Title" });
            DropIndex("dbo.Authors", new[] { "Pseudonym" });
            DropIndex("dbo.Authors", new[] { "Surname" });
            DropIndex("dbo.Authors", new[] { "Name" });
            AlterColumn("dbo.Works", "Extract3", c => c.String());
            AlterColumn("dbo.Works", "Extract2", c => c.String());
            AlterColumn("dbo.Works", "Extract1", c => c.String());
        }
    }
}
