using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Bookva.Business.ImageService;
using Bookva.Business.Mappers;
using Bookva.BusinessEntities.Author;
using Bookva.DAL;

namespace Bookva.Business
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public AuthorService(IUnitOfWork uow, IImageService imageService)
        {
            _unitOfWork = uow;
            _imageService = imageService;
        }

        public AuthorReadModel Get(int id)
        {
            var author = _unitOfWork.AuthorRepository.Get(id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with id = {id} is not found!");
            }

            return author.ToReadModel();
        }

        public IEnumerable<AuthorReadModel> GetAll()
        {
            return _unitOfWork.AuthorRepository.Get().ToList().Select(AuthorMapper.ToReadModel);
        }

        public IEnumerable<AuthorReadModel> Get(PaginationOptions options)
        {
            return _unitOfWork.AuthorRepository.Get().OrderBy(a => a.Id).Skip((options.Page - 1) * options.PageSize).Take(options.PageSize).ToList().Select(AuthorMapper.ToReadModel);
        }

        public void Create(AuthorWriteModel author)
        {
            _unitOfWork.AuthorRepository.Insert(author.ToDb());
            _unitOfWork.Save();
        }

        public void Edit(AuthorWriteModel author)
        {
            _unitOfWork.AuthorRepository.Update(author.ToDb(), author.Id);
            _unitOfWork.Save();
        }

        public async Task ChangePictureAsync(Image image, int id)
        {
            var author = _unitOfWork.AuthorRepository.Get(id);
            var pictureTask = _imageService.UploadAsync(image, ImageType.UserPic, $"authorId-{id}");
            var previewPictureTask = _imageService.UploadAsync(image, ImageType.Miniature, $"authorId-{id}-mini");

            author.PictureSource = await pictureTask;
            author.PreviewPictureSource = await previewPictureTask;
            _unitOfWork.AuthorRepository.Update(author, id);
            _unitOfWork.Save();
        }
    }
}
