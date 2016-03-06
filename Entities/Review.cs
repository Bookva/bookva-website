using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
	public class Review
	{
		[Key]
		public int Id { get; set; }

		public virtual User User { get; set; }
		public virtual Work Work { get; set; }
		[MaxLength(250)]
		public string Title { get; set; }
		public string Text { get; set; }
		
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime DateAdded { get; set; }
	}
}
