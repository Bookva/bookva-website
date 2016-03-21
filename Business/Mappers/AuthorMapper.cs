using System.Linq;
using Bookva.BusinessEntities.Author;
using Bookva.Entities;

namespace Bookva.Business.Mappers
{
    public static class AuthorMapper
    {
        public static Author ToDb(this AuthorWriteModel viewModel)
        {
            return new Author
            {
                Id = viewModel.Id,
                DateOfBirth = viewModel.DateOfBirth,
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                PictureSource = viewModel.PictureSource,
                PreviewPictureSource = viewModel.PreviewPictureSource,
                Pseudonym = viewModel.Pseudonym,
                UsePseudonym = viewModel.UsePseudonym
            };
        }

        public static AuthorReadModel ToReadModel(this Author author)
        {
            return new AuthorReadModel
            {
                Id = author.Id,
                DateOfBirth = author.DateOfBirth,
                Name = author.Name,
                Surname = author.Surname,
                PictureSource = author.PictureSource,
                PreviewPictureSource = author.PreviewPictureSource,
                Pseudonym = author.Pseudonym,
                UsePseudonym = author.UsePseudonym,
                Works = author.Works.Select(WorksMapper.ToPreviewModel)
            };
        }
        public static AuthorPreviewModel ToPreviewViewModel(this Author author)
        {
            return new AuthorPreviewModel
            {
                Id = author.Id,
                PictureSource = author.PictureSource,
                PreviewPictureSource = author.PreviewPictureSource,
                DisplayName = author.UsePseudonym ? author.Pseudonym : $"{author.Name} {author.Surname}"
            };
        }
    }
}