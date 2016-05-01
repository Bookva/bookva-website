using System;

namespace Bookva.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PictureSource { get; set; }
        public int? AuthorId { get; set; }
    }

    public class UserPreviewViewModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string PreviewPictureSource { get; set; }
    }
}
