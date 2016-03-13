using System;
using System.Collections.Generic;
using Bookva.BusinessEntities.Work;

namespace Bookva.BusinessEntities.Author
{
    public class AuthorReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PictureSource { get; set; }
        public string Pseudonym { get; set; }
        public bool UsePseudonym { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<WorkPreviewModel> Works { get; set; }
    }
}