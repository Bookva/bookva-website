using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class RecentCollection
	{
		[Key]
		public int Id { get; set; }

		public virtual User UserId { get; set; }
		public virtual Work Work { get; set; }
		public DateTime LastViewed { get; set; }
	}
}
