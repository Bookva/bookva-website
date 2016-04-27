using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookva.BusinessEntities.Review;
using Bookva.Web.Models;

namespace Bookva.Web.Mappers
{
    public class ReviewMapper
    {
        public static ReviewWriteModel ToDTO(ReviewEditViewModel viewModel, int userId)
        {
            return new ReviewWriteModel
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Text = viewModel.Text,
                WorkId = viewModel.WorkId,
                UserId = userId
            };
        }

        public static ReviewViewModel ToViewModel(ReviewReadModel review)
        {
            return new ReviewViewModel
            {
                Id = review.Id,
                Title = review.Title,
                Text = review.Text,
                DateAdded = review.DateAdded,
                User = review.User.ToViewModel()
            };
        }
    }
}