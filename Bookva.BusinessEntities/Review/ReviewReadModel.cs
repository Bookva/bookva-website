using System;
using Bookva.BusinessEntities.User;

namespace Bookva.BusinessEntities.Review
{
    public class ReviewReadModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Text { get; set; }
        
        public DateTime DateAdded { get; set; }

        public UserPreviewModel User { get; set; }
    }
}
