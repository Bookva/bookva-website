using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class CustomCollectionItem
	{
		[Key]
		public int Id { get; set; }

		public virtual CustomCollection	CustomCollection{ get; set; }
		public virtual Work Work { get; set; }
	}
}
