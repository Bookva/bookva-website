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
        public static UserPreviewViewModel ToViewModel(this UserPreviewModel model)
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