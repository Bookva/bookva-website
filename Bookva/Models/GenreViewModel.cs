using System.ComponentModel.DataAnnotations;

namespace Bookva.Web.Models
{
    public class GenreViewModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The genre name length must not exceed {1} characters.")]
        public string Value { get; set; }
    }
}
