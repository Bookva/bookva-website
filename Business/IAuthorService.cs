
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace Business
{
    public interface IAuthorService
    {
        Author Get(int id);
        IEnumerable<Author> GetAll();
        IEnumerable<Author> Get(PaginationOptions options);
        void Create(Author work);

    }
}
