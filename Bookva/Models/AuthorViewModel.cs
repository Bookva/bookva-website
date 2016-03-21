using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookva.Web.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Surname { get; set; }

        [MaxLength(255)]
        public string PictureSource { get; set; }
        [MaxLength(255)]
        public string PreviewPictureSource { get; set; }

        [MaxLength(35)]
        public string Pseudonym { get; set; }

        public bool UsePseudonym { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IEnumerable<WorkPreviewViewModel> Works { get; set; }
    }

    public class AuthorPreviewViewModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string PictureSource { get; set; }
        public string PreviewPictureSource { get; set; }
    }
}