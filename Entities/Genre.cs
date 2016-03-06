using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class Genre
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(30)]
		public string Name { get; set; }

		public virtual ICollection<Work> Works{ get; set; }
	}
}
