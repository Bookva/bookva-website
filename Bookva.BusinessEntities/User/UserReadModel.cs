using System;
using System.Collections.Generic;
using Bookva.BusinessEntities.Author;
using Bookva.BusinessEntities.Work;

namespace Bookva.BusinessEntities.User
{
    public class UserReadModel 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PictureSource { get; set; }
        public AuthorReadModel Author { get; set; }

        public virtual IEnumerable<WorkPreviewModel> FavouritesCollection { get; set; }
        public virtual IEnumerable<WorkPreviewModel> RecentCollection { get; set; }
        public virtual IEnumerable<WorkPreviewModel> ReadCollection { get; set; }
    }
}
