using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Author;

namespace Bookva.BusinessEntities.Work
{
    public class WorkPreviewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int WorkType { get; set; }
        public bool IsAnonymous { get; set; }
        public string CoverSource { get; set; }
        public string PreviewCoverSource { get; set; }
        public IEnumerable<AuthorPreviewModel> Authors { get; set; }
    }
}
