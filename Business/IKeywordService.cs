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
    public interface IKeywordService
    {
        IEnumerable<KeywordModel> Get(PaginationOptions options);
        Keyword Create(KeywordModel keyword);
        IEnumerable<Keyword> Create(IEnumerable<KeywordModel> keywords);
    }
}
