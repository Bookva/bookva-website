using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Author;
using Bookva.BusinessEntities.Review;

namespace Bookva.Business
{
    public interface IReviewService
    {
        IEnumerable<ReviewReadModel> GetByWorkId(int id);
        IEnumerable<ReviewReadModel> GetByWorkId(int id, PaginationOptions options);
        IEnumerable<ReviewReadModel> GetByUserId(int id);
        IEnumerable<ReviewReadModel> GetByUserId(int id, PaginationOptions options);
        void Create(ReviewWriteModel review);
        void Edit(ReviewWriteModel review);
        void Delete(int id);
    }
}
