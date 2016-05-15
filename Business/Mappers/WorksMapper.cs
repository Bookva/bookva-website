using System.Collections.Generic;
using System.Linq;
using Bookva.BusinessEntities.Work;
using Bookva.Entities;

namespace Bookva.Business.Mappers
{
    public static class WorksMapper
    {
        public static Work ToDB(this WorkWriteModel viewModel)
        {
            return new Work
            {
                Status = viewModel.Status,
                DateAdded = viewModel.DateAdded,
                YearCreated = viewModel.YearCreated,
                Description = viewModel.Description,
                Title = viewModel.Title,
                Extract1 = viewModel.Extract1,
                Extract2 = viewModel.Extract2,
                Extract3 = viewModel.Extract3,
                Id = viewModel.Id,
                Text = viewModel.Text,
                IsAnonymous = viewModel.IsAnonymous,
                CoverSource = viewModel.CoverSource,
                PreviewCoverSource = viewModel.PreviewCoverSource,
                Genres = new List<Genre>(),
                Keywords = new List<Keyword>(),
                Authors = new List<Author>()
            };
        }

        public static WorkReadModel ToReadModel(this Work work)
        {
            return new WorkReadModel
            {
                Status = work.Status,
                DateAdded = work.DateAdded,
                YearCreated = work.YearCreated,
                Description = work.Description,
                Title = work.Title,
                Extract1 = work.Extract1,
                Extract2 = work.Extract2,
                Extract3 = work.Extract3,
                Id = work.Id,
                Text = work.Text,
                IsAnonymous = work.IsAnonymous,
                CoverSource = work.CoverSource,
                PreviewCoverSource = work.PreviewCoverSource,
                Authors = work.Authors?.Select(AuthorMapper.ToPreviewViewModel),
                Genres = work.Genres?.Select(GenreMapper.ToModel),
                Keywords = work.Keywords?.Select(KeywordMapper.ToModel),
                Reviews = work.Reviews?.Select(ReviewMapper.ToReadModel),
                AverageRating = work.AverageRating,
                TotalVotes = work.TotalVotes
            };
        }

        public static WorkPreviewModel ToPreviewModel(this Work work)
        {
            return new WorkPreviewModel
            {
                Status = work.Status,
                Description = work?.Description,
                Title = work.Title,
                Id = work.Id,
                IsAnonymous = work.IsAnonymous,
                CoverSource = work.CoverSource,
                PreviewCoverSource = work.PreviewCoverSource,
                Authors = work.Authors?.Select(AuthorMapper.ToPreviewViewModel),
                AverageRating = work.AverageRating,
                ReviewsCount = work.Reviews?.Count ?? 0
            };
        }
    }
}