using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Author;
using Bookva.BusinessEntities.Filter;

namespace Bookva.Business
{
    public interface IAuthorService
    {
        AuthorReadModel Get(int id);
        IEnumerable<AuthorReadModel> GetAll();
        IEnumerable<AuthorReadModel> Get(PaginationOptions options);
        int Create(AuthorWriteModel work);
        void CreateUserAuthor(AuthorWriteModel author, int userId);
        void Edit(AuthorWriteModel work);
        Task ChangePictureAsync(Image image, int id);
    }
}
