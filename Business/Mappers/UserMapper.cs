using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Author;
using Bookva.BusinessEntities.User;
using Bookva.BusinessEntities.Work;
using Bookva.Entities;

namespace Bookva.Business.Mappers
{
    public static class UserMapper
    {
        public static UserReadModel ToReadModel(this User user)
        {
            return new UserReadModel
            {
                Id = user.Id,
                Username = user.UserName,
                PictureSource = user.PreviewPictureSource,
                Author = user.AuthorId.HasValue? user.Author.ToReadModel(): null,
                RegistrationDate = user.RegistrationDate,
                Email = user.Email,
                FavouritesCollection = user.FavouritesCollection.Select(fci => fci.Work.ToPreviewModel()),
                RecentCollection = user.RecentCollection.Select(rci => rci.Work.ToPreviewModel()),
                ReadCollection = user.ReadCollection.Select(rci => rci.Work.ToPreviewModel())
            };
        }

        public static UserPreviewModel ToPreviewViewModel(this User user)
        {
            return new UserPreviewModel
            {
                Id = user.Id,
                Nickname = user.UserName,
                PreviewPictureSource = user.PreviewPictureSource
            };
        }
    }
}
