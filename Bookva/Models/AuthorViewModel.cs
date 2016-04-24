using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookva.Web.Models
{
    public class AuthorEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The {0} must not exceed {1} characters.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The {0} must not exceed {1} characters.")]
        public string Surname { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The {0} must not exceed {1} characters.")]
        public string PictureSource { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The {0} must not exceed {1} characters.")]
        public string PreviewPictureSource { get; set; }
        
        [MaxLength(35, ErrorMessage = "The {0} must not exceed {1} characters.")]
        public string Pseudonym { get; set; }

        [Required]
        public bool UsePseudonym { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }

    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PictureSource { get; set; }
        public string PreviewPictureSource { get; set; }
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