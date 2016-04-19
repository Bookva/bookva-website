using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookva.Entities
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
        [Column(TypeName = "datetime2")]
		public DateTime DateAdded { get; set; }
        public short? YearCreated { get; set; }
		public virtual WorkType WorkType { get; set; }
        [MaxLength(255)]
        public string CoverSource { get; set; }
        [MaxLength(255)]
        public string PreviewCoverSource { get; set; }
        public string Text { get; set; }
		public bool IsAnonymous { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
		public virtual ICollection<Genre> Genres { get; set; }
		public virtual ICollection<Keyword> Keywords { get; set; }
        [InverseProperty("Work")]
		public virtual ICollection<Review> Reviews { get; set; }
        [InverseProperty("Work")]
		public virtual ICollection<WorkRating> Ratings{ get; set; }
	}
}
