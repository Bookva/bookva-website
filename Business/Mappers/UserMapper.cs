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
