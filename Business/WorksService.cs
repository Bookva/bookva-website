using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Bookva.Business.Mappers;
using Bookva.BusinessEntities.Work;
using Bookva.DAL;
using System.Threading.Tasks;
using Bookva.Business.Filters;
using Bookva.Business.ImageService;
using Bookva.BusinessEntities.Filter;
using Bookva.Common;
using Bookva.Entities;

namespace Bookva.Business
{
    public class WorksService : IWorksService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public WorksService(IUnitOfWork uow, IImageService imageService)
        {
            _unitOfWork = uow;
            _imageService = imageService;
        }

        public WorkReadModel Get(int id, int? userId = null)
        {
            var work = _unitOfWork.WorkRepository.Get(id);
            if (work == null)
            {
                throw new KeyNotFoundException($"Work with id {id} is not found!");
            }
            var workModel = work.ToReadModel();
            if (userId.HasValue)
            {
                workModel.CurrentUserVote = work.Ratings.FirstOrDefault(r => r.UserId == userId.Value)?.Mark;
            }
            return workModel;
        }

        public IEnumerable<WorkPreviewModel> GetAll()
        {
            return _unitOfWork.WorkRepository.Get().ToList().Select(WorksMapper.ToPreviewModel);
        }

        public IEnumerable<WorkPreviewModel> Get(PaginationOptions options)
        {
            var data = _unitOfWork.WorkRepository.Get().Where(w => w.Status == WorkStatus.Posted);
            var filter = new WorkFilter();
            data = filter.Sort(data, options.FieldName, options.Order);
            return data.Paginate(options).ToList().Select(WorksMapper.ToPreviewModel);
        }

        public IEnumerable<WorkPreviewModel> Filter(WorkFilterOptions options)
        {
            var data = _unitOfWork.WorkRepository.Get().Where(w => w.Status == WorkStatus.Posted);
            var filter = new WorkFilter();
            data = filter.Filter(data, options);
            return data.Sort(options.FieldName, options.Order).Paginate(options).ToList().Select(WorksMapper.ToPreviewModel);
        }

        public void Create(WorkWriteModel workDto)
        {
            var work = workDto.ToDB();
            foreach (var authorId in workDto.AuthorIds)
            {
                var author = _unitOfWork.AuthorRepository.Get(authorId);
                work.Authors.Add(author);
            }

            foreach (var genre in workDto.Genres)
            {
                Genre dbGenre = genre.Id.HasValue ? _unitOfWork.GenreRepository.Get(genre.Id.Value) : genre.ToDB();
                work.Genres.Add(dbGenre);
            }

            foreach (var keyword in workDto.Keywords)
            {
                Keyword dbKeyword = keyword.Id.HasValue ? _unitOfWork.KeywordRepository.Get(keyword.Id.Value) : keyword.ToDB();
                work.Keywords.Add(dbKeyword);
            }
            
            _unitOfWork.WorkRepository.Insert(work);
            _unitOfWork.Save();
        }

        public void Edit(WorkWriteModel workDto)
        {
            var work = workDto.ToDB();
            foreach (var authorId in workDto.AuthorIds)
            {
                var author = _unitOfWork.AuthorRepository.Get(authorId);
                work.Authors.Add(author);
            }

            foreach (var genre in workDto.Genres)
            {
                Genre dbGenre = genre.Id.HasValue ? _unitOfWork.GenreRepository.Get(genre.Id.Value) : genre.ToDB();
                work.Genres.Add(dbGenre);
            }

            foreach (var keyword in workDto.Keywords)
            {
                Keyword dbKeyword = keyword.Id.HasValue ? _unitOfWork.KeywordRepository.Get(keyword.Id.Value) : keyword.ToDB();
                work.Keywords.Add(dbKeyword);
            }

            _unitOfWork.WorkRepository.Update(work, work.Id);
            _unitOfWork.Save();
        }

        public async Task ChangePictureAsync(Image image, int id)
        {
            var work = _unitOfWork.WorkRepository.Get(id);
            var pictureTask = _imageService.UploadAsync(image, ImageType.UserPic, $"workId-{id}");
            var previewPictureTask = _imageService.UploadAsync(image, ImageType.Miniature, $"workId-{id}-mini");

            work.CoverSource = await pictureTask;
            work.PreviewCoverSource = await previewPictureTask;
            _unitOfWork.WorkRepository.Update(work, id);
            _unitOfWork.Save();
        }

        public void Rate(int workId, int userId, byte mark)
        {
            var work = _unitOfWork.WorkRepository.Get(workId);

            var existingRating = work.Ratings.Where(r => r.UserId == userId).ToList();
            if (existingRating.Any())
            {
                work.TotalVotes = work.TotalVotes - existingRating.Count;
                _unitOfWork.WorkRatingRepository.Delete(existingRating);
                _unitOfWork.Save();
            }
            _unitOfWork.WorkRatingRepository.Insert(new WorkRating {Mark = mark, UserId = userId, WorkId = workId});

            work.AverageRating = work.AverageRating*work.TotalVotes/(work.TotalVotes + 1) + (float)(mark - existingRating.Sum(r => r.Mark))/ (work.TotalVotes + 1);
            work.TotalVotes = work.TotalVotes + 1;
            _unitOfWork.WorkRepository.Update(work, work.Id);
            _unitOfWork.Save();
        }

        public bool IsRated(int workId, int userId)
        {
            return _unitOfWork.WorkRatingRepository.Get().Any(r => r.UserId == userId && r.WorkId == workId);
        }

        public void ChangeStatus(int id, int userId, WorkStatus status)
        {
            var userAuthor = _unitOfWork.UserRepository.Get(userId).AuthorId;
            if ( userAuthor.HasValue)
            {
                var work = _unitOfWork.WorkRepository.Get(id);
                var isUserAllowed = work.Authors.Any(a => a.Id == userAuthor.Value);
                if (isUserAllowed)
                {
                    work.Status = status;
                }
                _unitOfWork.WorkRepository.Update(work, id);
                _unitOfWork.Save();
            }
            else
            {
                throw new ApplicationException("Current user is not allowed to make changes.");
            }
        }
    }
}
