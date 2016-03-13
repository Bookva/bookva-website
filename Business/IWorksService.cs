using System.Collections.Generic;
using Bookva.BusinessEntities.Work;

namespace Bookva.Business
{
    public interface IWorksService
    {
        WorkReadModel Get(int id);
        IEnumerable<WorkPreviewModel> GetAll();
        IEnumerable<WorkPreviewModel> Get(PaginationOptions options);
        void Create(WorkWriteModel work);

    }
}
