using System;
using System.Linq;
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
                WorkType = viewModel.WorkType,
                DateAdded = DateTime.Now,
                DateCreated = viewModel.DateCreated,
                Description = viewModel.Description.Trim(),
                Title = viewModel.Title.Trim(),
                Extract1 = viewModel.Extract1.Trim(),
                Extract2 = viewModel.Extract2.Trim(),
                Extract3 = viewModel.Extract3.Trim(),
                Id = viewModel.Id,
                Text = viewModel.Text.Trim(),
                IsAnonymous = viewModel.IsAnonymous,
                CoverSource = viewModel.CoverSource,
                AuthorIds = viewModel.AuthorIds
                //TODO: add keywords and genres
            };
        }

        public static WorkViewModel ToViewModel(WorkReadModel work)
        {
            return new WorkViewModel
            {
                WorkType = (int)work.WorkType,
                DateAdded = work.DateAdded,
                DateCreated = work.DateCreated,
                Description = work.Description,
                Title = work.Title,
                Extract1 = work.Extract1,
                Extract2 = work.Extract2,
                Extract3 = work.Extract3,
                Id = work.Id,
                Text = work.Text,
                IsAnonymous = work.IsAnonymous,
                CoverSource = work.CoverSource,
                Authors = work.Authors.Select(AuthorMapper.ToPreviewViewModel),
                //Genres = work.Genres.Select(g => g.Name),
                //Keywords = work.Keywords.Select(k => k.Name)
            };
        }

        public static WorkViewModel ToEditViewModel(WorkReadModel work)
        {
            return new WorkViewModel
            {
                WorkType = work.WorkType,
                DateAdded = work.DateAdded,
                DateCreated = work.DateCreated,
                Description = work.Description,
                Title = work.Title,
                Extract1 = work.Extract1,
                Extract2 = work.Extract2,
                Extract3 = work.Extract3,
                Id = work.Id,
                Text = work.Text,
                IsAnonymous = work.IsAnonymous,
                CoverSource = work.CoverSource,
                Authors = work.Authors.Select(AuthorMapper.ToPreviewViewModel),
                //Genres = work.Genres.Select(g => g.Name),
                //Keywords = work.Keywords.Select(k => k.Name)
            };
        }

        public static WorkPreviewViewModel ToPreviewViewModel(WorkPreviewModel work)
        {
            return new WorkPreviewViewModel
            {
                WorkType = (int)work.WorkType,
                Description = work.Description,
                Title = work.Title,
                Id = work.Id,
                IsAnonymous = work.IsAnonymous,
                CoverSource = work.CoverSource,
                Authors = work.Authors.Select(AuthorMapper.ToPreviewViewModel)
            };
        }
    }
}