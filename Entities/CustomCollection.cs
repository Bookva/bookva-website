using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class CustomCollection
	{
		[Key]
		public int Id { get; set; }

		public string Title { get; set; }
		public virtual User User { get; set; }
		public virtual ICollection<CustomCollectionItem> Items { get; set; }	
	}
}
