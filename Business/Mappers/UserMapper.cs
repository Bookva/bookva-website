using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Author;
using Bookva.BusinessEntities.User;
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
                AuthorId = user.AuthorId,
                RegistrationDate = user.RegistrationDate,
                Email = user.Email
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
