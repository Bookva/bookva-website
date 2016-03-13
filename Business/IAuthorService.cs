using System.Collections.Generic;
using Bookva.BusinessEntities.Author;

namespace Bookva.Business
{
    public interface IAuthorService
    {
        AuthorReadModel Get(int id);
        IEnumerable<AuthorReadModel> GetAll();
        IEnumerable<AuthorReadModel> Get(PaginationOptions options);
        void Create(AuthorWriteModel work);

    }
}
