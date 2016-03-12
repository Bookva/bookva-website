namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Surname = c.String(maxLength: 30),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Description = c.String(maxLength: 1000),
                        Extract1 = c.String(),
                        Extract2 = c.String(),
                        Extract3 = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        WorkType = c.Int(nullable: false),
                        CoverSource = c.String(),
                        Text = c.String(),
                        IsAnonymous = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.Byte(nullable: false),
                        User_Id = c.Int(),
                        Work_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Works", t => t.Work_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Work_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationDate = c.DateTime(nullable: false),
                        ImageSource = c.String(),
                        AuthorId = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .Index(t => t.AuthorId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CustomCollectionItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomCollection_Id = c.Int(),
                        Work_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomCollections", t => t.CustomCollection_Id)
                .ForeignKey("dbo.Works", t => t.Work_Id)
                .Index(t => t.CustomCollection_Id)
                .Index(t => t.Work_Id);
            
            CreateTable(
                "dbo.FavouritesCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        WorkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Works", t => t.WorkId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.WorkId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ReadCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        WorkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Works", t => t.WorkId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.WorkId);
            
            CreateTable(
                "dbo.RecentCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        WorkId = c.Int(nullable: false),
                        LastViewed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Works", t => t.WorkId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.WorkId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Text = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        WorkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Works", t => t.WorkId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.WorkId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.WorkAuthors",
                c => new
                    {
                        Work_Id = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Work_Id, t.Author_Id })
                .ForeignKey("dbo.Works", t => t.Work_Id, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Work_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.GenreWorks",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Work_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Work_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Works", t => t.Work_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Work_Id);
            
            CreateTable(
                "dbo.KeywordWorks",
                c => new
                    {
                        Keyword_Id = c.Int(nullable: false),
                        Work_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Keyword_Id, t.Work_Id })
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id, cascadeDelete: true)
                .ForeignKey("dbo.Works", t => t.Work_Id, cascadeDelete: true)
                .Index(t => t.Keyword_Id)
                .Index(t => t.Work_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reviews", "WorkId", "dbo.Works");
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.WorkRatings", "Work_Id", "dbo.Works");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.RecentCollections", "UserId", "dbo.Users");
            DropForeignKey("dbo.RecentCollections", "WorkId", "dbo.Works");
            DropForeignKey("dbo.ReadCollections", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReadCollections", "WorkId", "dbo.Works");
            DropForeignKey("dbo.WorkRatings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.FavouritesCollections", "UserId", "dbo.Users");
            DropForeignKey("dbo.FavouritesCollections", "WorkId", "dbo.Works");
            DropForeignKey("dbo.CustomCollections", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CustomCollectionItems", "Work_Id", "dbo.Works");
            DropForeignKey("dbo.CustomCollectionItems", "CustomCollection_Id", "dbo.CustomCollections");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.KeywordWorks", "Work_Id", "dbo.Works");
            DropForeignKey("dbo.KeywordWorks", "Keyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.GenreWorks", "Work_Id", "dbo.Works");
            DropForeignKey("dbo.GenreWorks", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.WorkAuthors", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.WorkAuthors", "Work_Id", "dbo.Works");
            DropIndex("dbo.KeywordWorks", new[] { "Work_Id" });
            DropIndex("dbo.KeywordWorks", new[] { "Keyword_Id" });
            DropIndex("dbo.GenreWorks", new[] { "Work_Id" });
            DropIndex("dbo.GenreWorks", new[] { "Genre_Id" });
            DropIndex("dbo.WorkAuthors", new[] { "Author_Id" });
            DropIndex("dbo.WorkAuthors", new[] { "Work_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Reviews", new[] { "WorkId" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.RecentCollections", new[] { "WorkId" });
            DropIndex("dbo.RecentCollections", new[] { "UserId" });
            DropIndex("dbo.ReadCollections", new[] { "WorkId" });
            DropIndex("dbo.ReadCollections", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.FavouritesCollections", new[] { "WorkId" });
            DropIndex("dbo.FavouritesCollections", new[] { "UserId" });
            DropIndex("dbo.CustomCollectionItems", new[] { "Work_Id" });
            DropIndex("dbo.CustomCollectionItems", new[] { "CustomCollection_Id" });
            DropIndex("dbo.CustomCollections", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "AuthorId" });
            DropIndex("dbo.WorkRatings", new[] { "Work_Id" });
            DropIndex("dbo.WorkRatings", new[] { "User_Id" });
            DropTable("dbo.KeywordWorks");
            DropTable("dbo.GenreWorks");
            DropTable("dbo.WorkAuthors");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Reviews");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.RecentCollections");
            DropTable("dbo.ReadCollections");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.FavouritesCollections");
            DropTable("dbo.CustomCollectionItems");
            DropTable("dbo.CustomCollections");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.WorkRatings");
            DropTable("dbo.Keywords");
            DropTable("dbo.Genres");
            DropTable("dbo.Works");
            DropTable("dbo.Authors");
        }
    }
}
