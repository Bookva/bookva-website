﻿using System.Linq;
using Bookva.BusinessEntities.Author;
using Bookva.Web.Models;

namespace Bookva.Web.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorWriteModel ToDTO(AuthorViewModel viewModel)
        {
            return new AuthorWriteModel
            {
                Id = viewModel.Id,
                DateOfBirth = viewModel.DateOfBirth,
                Name = viewModel.Name.Trim(),
                Surname = viewModel.Surname.Trim(),
                PictureSource = viewModel.PictureSource.Trim(),
                Pseudonym = viewModel.Pseudonym.Trim(),
                UsePseudonym = viewModel.UsePseudonym
            };
        }

        public static AuthorViewModel ToViewModel(AuthorReadModel author)
        {
            return new AuthorViewModel
            {
                Id = author.Id,
                DateOfBirth = author.DateOfBirth,
                Name = author.Name,
                Surname = author.Surname,
                PictureSource = author.PictureSource,
                Pseudonym = author.Pseudonym,
                UsePseudonym = author.UsePseudonym,
                Works = author.Works.Select(WorksMapper.ToPreviewViewModel)
            };
        }
        public static AuthorPreviewViewModel ToPreviewViewModel(AuthorPreviewModel author)
        {
            return new AuthorPreviewViewModel
            {
                Id = author.Id,
                PictureSource = author.PictureSource,
                DisplayName = author.DisplayName
            };
        }
    }
}