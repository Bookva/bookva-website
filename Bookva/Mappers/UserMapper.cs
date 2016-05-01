using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookva.BusinessEntities.User;
using Bookva.Web.Models;

namespace Bookva.Web.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToViewModel(this UserReadModel user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Username = user.Username,
                PictureSource = user.PictureSource,
                AuthorId = user.AuthorId,
                RegistrationDate = user.RegistrationDate,
                Email = user.Email
            };
        }

        public static UserPreviewViewModel ToPreviewViewModel(this UserPreviewModel model)
        {
            return new UserPreviewViewModel
            {
                Id = model.Id,
                Nickname = model.Nickname,
                PreviewPictureSource = model.PreviewPictureSource
            };
        }
    }
}