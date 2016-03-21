using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Bookva.Entities
{
    public class User : IdentityUser<int, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public User()
        {
            RegistrationDate = DateTime.Now;
        }
        public DateTime RegistrationDate { get; set; }

        [MaxLength(255)]
        public string PictureSource { get; set; }

        [MaxLength(255)]
        public string PreviewPictureSource { get; set; }

        public int? AuthorId { get; set; }
        
        public virtual Author Author { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<FavouritesCollection> FavouritesCollection { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<RecentCollection> RecentCollection { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ReadCollection> ReadCollection { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<CustomCollection> CustomCollections { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<WorkRating> Ratings { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ExternalBearer);
            
            return userIdentity;
        }
    }

    public class IdentityUserClaim : IdentityUserClaim<int>
    {

    }
    public class IdentityUserLogin : IdentityUserLogin<int>
    {

    }
    public class IdentityRole : IdentityRole<int, IdentityUserRole>
    {

    }
    public class IdentityUserRole : IdentityUserRole<int>
    {

    }
}
