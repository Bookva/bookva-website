using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookva.Entities
{
	public class Keyword
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(20)]
		public string Name { get; set; }

		public virtual ICollection<Work> Works { get; set; }
	}
}
