using System;
using System.Linq;
using Bookva.Business.Mappers;
using Bookva.BusinessEntities.Work;
using Bookva.Web.Models;

namespace Bookva.Web.Mappers
{
    public static class WorksMapper
    {
        public static WorkWriteModel ToDTO(WorkEditViewModel viewModel)
        {
            return new WorkWriteModel
            {
                Status = viewModel.Status,
                DateAdded = DateTime.Now,
                YearCreated = viewModel.YearCreated,
                Description = viewModel.Description.Trim(),
                Title = viewModel.Title.Trim(),
                Extract1 = viewModel.Extract1?.Trim(),
                Extract2 = viewModel.Extract2?.Trim(),
                Extract3 = viewModel.Extract3?.Trim(),
                Id = viewModel.Id,
                Text = viewModel.Text.Trim(),
                IsAnonymous = viewModel.IsAnonymous,
                CoverSource = viewModel.CoverSource,
                PreviewCoverSource = viewModel.PreviewCoverSource,
                AuthorIds = viewModel.AuthorIds,
                Genres = viewModel.Genres?.Select(GenreMapper.ToDB),
                Keywords = viewModel.Keywords?.Select(KeywordMapper.ToDB),
            };
        }

        public static WorkViewModel ToViewModel(WorkReadModel work)
        {
            return new WorkViewModel
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
                Reviews = work.Reviews?.Select(ReviewMapper.ToViewModel),
                Genres = work.Genres?.Select(GenreMapper.ToViewModel),
                Keywords = work.Keywords?.Select(KeywordMapper.ToViewModel),
                AverageRating = work.AverageRating,
                TotalVotes = work.TotalVotes,
                CurrentUserVote = work.CurrentUserVote
            };
        }

        public static WorkViewModel ToEditViewModel(WorkReadModel work)
        {
            return new WorkViewModel
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
                Genres = work.Genres?.Select(GenreMapper.ToViewModel),
                Keywords = work.Keywords?.Select(KeywordMapper.ToViewModel)
            };
        }

        public static WorkPreviewViewModel ToPreviewViewModel(WorkPreviewModel work)
        {
            return new WorkPreviewViewModel
            {
                Status = work.Status,
                Description = work.Description,
                Title = work.Title,
                Id = work.Id,
                IsAnonymous = work.IsAnonymous,
                CoverSource = work.CoverSource,
                PreviewCoverSource = work.PreviewCoverSource,
                Authors = work.Authors?.Select(AuthorMapper.ToPreviewViewModel),
                AverageRating = work.AverageRating
            };
        }
    }
}