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
                Author = user.Author?.ToViewModel(),
                RegistrationDate = user.RegistrationDate,
                Email = user.Email,
                FavouritesCollection = user.FavouritesCollection.Select(WorksMapper.ToPreviewViewModel),
                RecentCollection = user.RecentCollection.Select(WorksMapper.ToPreviewViewModel),
                ReadCollection = user.ReadCollection.Select(WorksMapper.ToPreviewViewModel)
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