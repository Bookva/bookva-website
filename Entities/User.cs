using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Entities
{
	public class User : IdentityUser<int,IdentityUserLogin,IdentityUserRole,IdentityUserClaim>
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime RegistrationDate { get; set; }

        public string ImageSource { get; set; }
        public virtual Author AuthorId { get; set; }
		public virtual FavouritesCollection FavouritesCollection { get; set; }
		public virtual RecentCollection RecentCollection { get; set; }
		public virtual ReadCollection ReadCollection{ get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }
    }

	public class IdentityUserClaim : IdentityUserClaim<int>
	{
		
	}
	public class IdentityUserLogin :IdentityUserLogin<int>
	{
		
	}
	public class IdentityRole : IdentityRole<int, IdentityUserRole>
	{

	}
	public class IdentityUserRole : IdentityUserRole<int>
	{

	}
}
