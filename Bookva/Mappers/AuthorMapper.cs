using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookva.Models;
using Entities;

namespace Bookva.Mappers
{
    public static class AuthorMapper
    {
        public static Author ToDTO(AuthorViewModel viewModel)
        {
            return new Author
            {
                Id = viewModel.Id,
                DateOfBirth = viewModel.DateOfBirth,
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                PictureSource = viewModel.PictureSource,
                Pseudonym = viewModel.Pseudonym,
                UsePseudonym = viewModel.UsePseudonym
            };
        }

        public static AuthorViewModel ToViewModel(Author author)
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
    }
}