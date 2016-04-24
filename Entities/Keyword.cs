using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookva.Entities
{
	public class Keyword
	{
		[Key]
		public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(20)]
		public string Name { get; set; }

		public virtual ICollection<Work> Works { get; set; }
	}
}
