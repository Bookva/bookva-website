using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Author;

namespace Bookva.Business
{
    public interface IAuthorService
    {
        AuthorReadModel Get(int id);
        IEnumerable<AuthorReadModel> GetAll();
        IEnumerable<AuthorReadModel> Get(PaginationOptions options);
        void Create(AuthorWriteModel work);
        void Edit(AuthorWriteModel work);
        Task ChangePictureAsync(Image image, int id);
    }
}
