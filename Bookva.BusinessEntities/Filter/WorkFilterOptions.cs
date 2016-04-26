using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookva.Business;
using Bookva.BusinessEntities.Keyword;
using Bookva.Common;

namespace Bookva.BusinessEntities.Filter
{
    public class WorkFilterOptions : PaginationOptions
    {
        public string Title { get; set; }
        public short? YearCreated { get; set; }
        public IEnumerable<int> AuthorIds { get; set; }
        public IEnumerable<int> GenresIds { get; set; }
        public IEnumerable<int> KeywordsIds { get; set; }
    }
}
