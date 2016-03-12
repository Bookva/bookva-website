using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookva.Models;
using Entities;

namespace Bookva.Mappers
{
    public static class WorksMapper
    {
        public static Work ToDTO(WorkViewModel viewModel)
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
                IsAnonymous = viewModel.IsAnonymous
            };
        }

        public static WorkViewModel ToViewModel(Work work)
        {
            return new WorkViewModel
            {
                WorkType = (int) work.WorkType,
                DateAdded = work.DateAdded,
                DateCreated = work.DateCreated,
                Description = work.Description,
                Title = work.Title,
                Extract1 = work.Extract1,
                Extract2 = work.Extract2,
                Extract3 = work.Extract3,
                Id = work.Id,
                Text = work.Text,
                IsAnonymous = work.IsAnonymous
            };
        }
    }
}