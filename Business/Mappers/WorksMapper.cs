﻿using System.Collections.Generic;
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
                WorkType = (WorkType)viewModel.WorkType,
                DateAdded = viewModel.DateAdded,
                DateCreated = viewModel.DateCreated,
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
                Authors = new List<Author>()
            };
        }

        public static WorkReadModel ToReadModel(this Work work)
        {
            return new WorkReadModel
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
                PreviewCoverSource = work.PreviewCoverSource,
                Authors = work.Authors.Select(AuthorMapper.ToPreviewViewModel),
                Genres = work.Genres.Select(g => g.Name),
                Keywords = work.Keywords.Select(k => k.Name),
                Reviews = work.Reviews.Select(ReviewMapper.ToReadModel)
            };
        }

        public static WorkPreviewModel ToPreviewModel(this Work work)
        {
            return new WorkPreviewModel
            {
                WorkType = (int)work.WorkType,
                Description = work.Description,
                Title = work.Title,
                Id = work.Id,
                IsAnonymous = work.IsAnonymous,
                CoverSource = work.CoverSource,
                PreviewCoverSource = work.PreviewCoverSource,
                Authors = work.Authors.Select(AuthorMapper.ToPreviewViewModel),
            };
        }
    }
}