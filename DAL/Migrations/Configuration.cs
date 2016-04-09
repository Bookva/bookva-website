using System.Data.Entity.Migrations;
using System.Linq;
using Bookva.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using IdentityUserRole = Bookva.Entities.IdentityUserRole;

namespace Bookva.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookvaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DAL.BookvaDbContext";
        }

        protected override void Seed(BookvaDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new Entities.IdentityRole { Name = "Admin" });
                context.Roles.Add(new Entities.IdentityRole { Name = "Author" });
                context.Roles.Add(new Entities.IdentityRole { Name = "Publisher" });
            }
            if (!(context.Users.Any(u => u.UserName == "admin")))
            {
                var userStore = new UserStore<User, Entities.IdentityRole, int, Entities.IdentityUserLogin, Entities.IdentityUserRole,
                            Entities.IdentityUserClaim>(context);
                var userManager = new UserManager<User, int>(userStore);
                var userToInsert = new User
                {
                    Id = 0,
                    UserName = "admin",
                    Email = "bookva.team@gmail.com"
                };
                userManager.Create(userToInsert, "Password123");
                userManager.AddToRole(0, "Admin");
            }
        }
    }
}
