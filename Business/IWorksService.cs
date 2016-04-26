using System.Collections.Generic;
using System.Drawing;
using Bookva.BusinessEntities.Work;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Filter;
using Bookva.Common;

namespace Bookva.Business
{
    public interface IWorksService
    {
        WorkReadModel Get(int id, int? userId = null);
        IEnumerable<WorkPreviewModel> GetAll();
        IEnumerable<WorkPreviewModel> Get(PaginationOptions options);
        IEnumerable<WorkPreviewModel> Filter(WorkFilterOptions options);
        void Create(WorkWriteModel work);
        void Edit(WorkWriteModel work);
        Task ChangePictureAsync(Image image, int id);
        void Rate(int workId, int userId, byte mark);
        bool IsRated(int workId, int userId);
        void ChangeStatus(int id, int userId, WorkStatus status);
    }
}
