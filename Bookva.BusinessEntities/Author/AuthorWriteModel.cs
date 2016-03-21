using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookva.BusinessEntities.Author
{
    public class AuthorWriteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PictureSource { get; set; }
        public string PreviewPictureSource { get; set; }
        public string Pseudonym { get; set; }
        public bool UsePseudonym { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
