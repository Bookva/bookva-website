using System;
using System.ComponentModel.DataAnnotations;
using Bookva.BusinessEntities.User;

namespace Bookva.Web.Models
{
    public class ReviewEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "The {0} must not exceed {1} characters.")]
        public string Title { get; set; }
        [Required]
        [MaxLength(2000, ErrorMessage = "The {0} must not exceed {1} characters.")]
        public string Text { get; set; }
        [Required]
        public int WorkId { get; set; }
    }

    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
        public UserPreviewViewModel User { get; set; }
    }
}
