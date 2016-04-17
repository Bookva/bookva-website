using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Bookva.Business.ImageService;
using Bookva.Business.Mappers;
using Bookva.BusinessEntities.Author;
using Bookva.BusinessEntities.Keyword;
using Bookva.BusinessEntities.Work;
using Bookva.DAL;
using Bookva.Entities;

namespace Bookva.Business
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public IEnumerable<GenreModel> Get(PaginationOptions options)
        {
            return
                _unitOfWork.GenreRepository.Get()
                    .OrderBy(k => k.Name)
                    .Skip(options.PageSize*(options.Page - 1))
                    .Take(options.PageSize).Select(GenreMapper.ToModel);
        }

        public Genre Create(GenreModel genreModel)
        {
            var genre = genreModel.ToDB();
            _unitOfWork.GenreRepository.Insert(genre);
            _unitOfWork.Save();
            return genre;
        }

        public IEnumerable<Genre> Create(IEnumerable<GenreModel> genreModels)
        {
            var genres = genreModels.Select(GenreMapper.ToDB).ToList();
            _unitOfWork.GenreRepository.Insert(genres);
            _unitOfWork.Save();

            return genres;
        }
    }
}
