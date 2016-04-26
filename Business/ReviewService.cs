using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Bookva.Business.Filters;
using Bookva.Business.ImageService;
using Bookva.Business.Mappers;
using Bookva.BusinessEntities.Author;
using Bookva.BusinessEntities.Filter;
using Bookva.BusinessEntities.Review;
using Bookva.DAL;

namespace Bookva.Business
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public IEnumerable<ReviewReadModel> GetByWorkId(int id)
        {
            return _unitOfWork.ReviewRepository.Get()
                .Where(review => review.WorkId == id )
                .ToList()
                .Select(ReviewMapper.ToReadModel);
        }

        public IEnumerable<ReviewReadModel> GetByWorkId(int id, PaginationOptions options)
        {
            return _unitOfWork.ReviewRepository.Get()
                .Where(review => review.WorkId == id)
                .OrderBy(a => a.DateAdded)
                .Paginate(options)
                .ToList()
                .Select(ReviewMapper.ToReadModel);
        }

        public IEnumerable<ReviewReadModel> GetByUserId(int id)
        {
            return _unitOfWork.ReviewRepository.Get()
                .Where(review => review.UserId == id)
                .ToList()
                .Select(ReviewMapper.ToReadModel);
        }

        public IEnumerable<ReviewReadModel> GetByUserId(int id, PaginationOptions options)
        {
            return _unitOfWork.ReviewRepository.Get()
                .Where(review => review.UserId == id)
                .OrderBy(a => a.Id)
                .Skip((options.Page - 1) * options.PageSize)
                .Take(options.PageSize)
                .ToList()
                .Select(ReviewMapper.ToReadModel);
        }

        public void Create(ReviewWriteModel review)
        {
            _unitOfWork.ReviewRepository.Insert(review.ToDb());
            _unitOfWork.Save();
        }

        public void Edit(ReviewWriteModel review)
        {
            _unitOfWork.ReviewRepository.Update(review.ToDb(), review.Id);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.ReviewRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
