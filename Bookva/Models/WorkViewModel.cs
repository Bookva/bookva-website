using System;
using System.Collections.Generic;
using System.Web;

namespace Bookva.Web.Models
{
    public class WorkViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Extract1 { get; set; }
        public string Extract2 { get; set; }
        public string Extract3 { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateCreated { get; set; }
        public int WorkType { get; set; }
        public string Text { get; set; }
        public bool IsAnonymous { get; set; }
        public string CoverSource { get; set; }
        public string PreviewCoverSource { get; set; }

        public IEnumerable<AuthorPreviewViewModel> Authors { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<string> Keywords { get; set; }
        //public IEnumerable<Review> Reviews { get; set; }
        //public IEnumerable<WorkRating> Ratings { get; set; }
        //TODO:add ratings and reviews
    }

    public class WorkEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Extract1 { get; set; }
        public string Extract2 { get; set; }
        public string Extract3 { get; set; }
        public DateTime DateCreated { get; set; }
        public int WorkType { get; set; }
        public string Text { get; set; }
        public bool IsAnonymous { get; set; }
        public string CoverSource { get; set; }
        public string PreviewCoverSource { get; set; }

        public IEnumerable<int> AuthorIds { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<string> Keywords { get; set; }
    }

    public class WorkPreviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int WorkType { get; set; }
        public bool IsAnonymous { get; set; }
        public string CoverSource { get; set; }
        public string PreviewCoverSource { get; set; }

        public IEnumerable<AuthorPreviewViewModel> Authors { get; set; }
    }
}