using Bookva.BusinessEntities.Review;
using Bookva.Entities;

namespace Bookva.Business.Mappers
{
    public static class ReviewMapper
    {
        public static Review ToDb(this ReviewWriteModel model)
        {
            return new Review
            {
                Id = model.Id,
                Title = model.Title,
                Text = model.Text,
                WorkId = model.WorkId,
                UserId = model.UserId
            };
        }
        public static ReviewReadModel ToReadModel(this Review review)
        {
            return new ReviewReadModel
            {
                Title = review.Title,
                Text = review.Text,
                DateAdded = review.DateAdded,
                User = review.User.ToPreviewViewModel()
            };
        }
    }
}
