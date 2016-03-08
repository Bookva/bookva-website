using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class ReadCollection
	{
		[Key]
		public int Id { get; set; }

        public int UserId { get; set; }
        public int WorkId { get; set; }

        public virtual User User { get; set; }
		public virtual Work Work { get; set; }
	}
}
