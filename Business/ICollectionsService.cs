using System.Collections.Generic;
using System.Drawing;
using Bookva.BusinessEntities.Work;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Filter;
using Bookva.Common;

namespace Bookva.Business
{
    public interface ICollectionsService
    {
        IEnumerable<WorkPreviewModel> GetFavouriteWorks(PaginationOptions options, int userId);
        IEnumerable<WorkPreviewModel> GetReadWorks(PaginationOptions options, int userId);
        IEnumerable<WorkPreviewModel> GetLatestWorks(PaginationOptions options, int userId);

        void AddToFavourites(int workId, int userId);
        void AddToRead(int workId, int userId);
        void AddToLatest(int workId, int userId);

        void DeleteFromFavourites(int workId, int userId);
        void DeleteFromRead(int workId, int userId);
        void DeleteFromLatest(int workId, int userId);
    }
}
