using System.ComponentModel.DataAnnotations;

namespace Bookva.Web.Models
{
    public class KeywordViewModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The keyword length must not exceed {1} characters.")]
        public string Value { get; set; }
    }
}
