using System.Data.Entity.Migrations;

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
            
        }
    }
}
