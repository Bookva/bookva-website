using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookva.BusinessEntities.Author
{
    public class AuthorPreviewModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string PictureSource { get; set; }
        public string PreviewPictureSource { get; set; }
    }
}
