using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Author;
using Bookva.BusinessEntities.Filter;
using Bookva.BusinessEntities.Keyword;
using Bookva.BusinessEntities.Work;
using Bookva.Entities;

namespace Bookva.Business
{
    public interface IGenreService
    {
        IEnumerable<GenreModel> Get(PaginationOptions options);
        Genre Create(GenreModel genre);
        IEnumerable<Genre> Create(IEnumerable<GenreModel> genres);
    }
}
