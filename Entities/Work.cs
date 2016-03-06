using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class Work
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(50)]
		public string Title { get; set; }
		[MaxLength(1000)]
		public string Description { get; set; }
		public string Extract1 { get; set; }
		public string Extract2 { get; set; }
		public string Extract3 { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime DateCreated { get; set; }
		public virtual WorkType WorkType { get; set; }
	    public string CoverSource { get; set; }
		public string Text { get; set; }
		public bool IsAnonymous { get; set; }
        public virtual ICollection<Author> Author { get; set; }
		public virtual ICollection<Genre> Genres { get; set; }
		public virtual ICollection<Keyword> Keywords { get; set; }
		public virtual ICollection<Review> Reviews { get; set; }
		public virtual ICollection<WorkRating> Ratings{ get; set; }
	}
}
