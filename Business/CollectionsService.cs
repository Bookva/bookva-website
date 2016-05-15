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
    public class CollectionsService : ICollectionsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollectionsService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public IEnumerable<WorkPreviewModel> GetFavouriteWorks(PaginationOptions options, int userId)
        {
            options = options ?? new PaginationOptions();
            var data = _unitOfWork.UserRepository.Get(userId).FavouritesCollection.Select(f => f.Work)
                                    .Where(w => w != null && w.Status == WorkStatus.Posted).AsQueryable();
            var filter = new WorkFilter();
            data = filter.Sort(data, options.FieldName, options.Order);
            return data.Paginate(options).Select(WorksMapper.ToPreviewModel);
        }

        public IEnumerable<WorkPreviewModel> GetReadWorks(PaginationOptions options, int userId)
        {
            options = options ?? new PaginationOptions();
            var data = _unitOfWork.UserRepository.Get(userId).ReadCollection.Select(f => f.Work)
                                    .Where(w => w != null && w.Status == WorkStatus.Posted).AsQueryable();
            var filter = new WorkFilter();
            data = filter.Sort(data, options.FieldName, options.Order);
            return data.Paginate(options).Select(WorksMapper.ToPreviewModel);
        }

        public IEnumerable<WorkPreviewModel> GetLatestWorks(PaginationOptions options, int userId)
        {
            options = options ?? new PaginationOptions();
            var data = _unitOfWork.UserRepository.Get(userId).RecentCollection.OrderBy( rc => rc.LastViewed).AsQueryable().
                Paginate(options).Select(f => f.Work).Where(w => w != null && w.Status == WorkStatus.Posted);

            return data.Select(WorksMapper.ToPreviewModel);
        }

        public void AddToFavourites(int workId, int userId)
        {
            var isAdded = _unitOfWork.FavouritesCollectionRepository.Get().Any(fc => fc.UserId == userId && fc.WorkId == workId);
            if(isAdded) throw new ApplicationException("This work is already added to favourites collection.");
            _unitOfWork.FavouritesCollectionRepository.Insert(new FavouritesCollection {UserId = userId, WorkId = workId});
            _unitOfWork.Save();
        }

        public void AddToRead(int workId, int userId)
        {
            var isAdded = _unitOfWork.FavouritesCollectionRepository.Get().Any(fc => fc.UserId == userId && fc.WorkId == workId);
            if (isAdded) throw new ApplicationException("This work is already added to read works collection.");
            _unitOfWork.ReadCollectionRepository.Insert(new ReadCollection { UserId = userId, WorkId = workId });
            _unitOfWork.Save();
        }

        public void AddToLatest(int workId, int userId)
        {
            var record = _unitOfWork.RecentCollectionRepository.Get().FirstOrDefault(fc => fc.UserId == userId && fc.WorkId == workId);
            if (record == null)
            {
                _unitOfWork.RecentCollectionRepository.Insert(new RecentCollection { UserId = userId, WorkId = workId, LastViewed = DateTime.Now });
            }
            else
            {
                record.LastViewed = DateTime.Now;
                _unitOfWork.RecentCollectionRepository.Insert(record);
            }
            _unitOfWork.Save();
        }

        public void DeleteFromFavourites(int workId, int userId)
        {
            var record = _unitOfWork.FavouritesCollectionRepository.Get().FirstOrDefault(fc => fc.UserId == userId && fc.WorkId == workId);
            if(record == null) throw new ApplicationException("This work is not added to favourites collection.");
            _unitOfWork.FavouritesCollectionRepository.Delete(record);
            _unitOfWork.Save();
        }

        public void DeleteFromRead(int workId, int userId)
        {
            var record = _unitOfWork.ReadCollectionRepository.Get().FirstOrDefault(fc => fc.UserId == userId && fc.WorkId == workId);
            if (record == null) throw new ApplicationException("This work is not added to read work collection.");
            _unitOfWork.ReadCollectionRepository.Delete(record);
            _unitOfWork.Save();
        }

        public void DeleteFromLatest(int workId, int userId)
        {
            var record = _unitOfWork.RecentCollectionRepository.Get().FirstOrDefault(fc => fc.UserId == userId && fc.WorkId == workId);
            if (record == null) throw new ApplicationException("This work is not added to recent work collection.");
            _unitOfWork.RecentCollectionRepository.Delete(record);
            _unitOfWork.Save();
        }
    }
}
