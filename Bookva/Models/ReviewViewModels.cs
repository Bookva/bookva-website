using System;
using Bookva.BusinessEntities.User;

namespace Bookva.Web.Models
{
    public class ReviewEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
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
