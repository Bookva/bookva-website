using System.ComponentModel.DataAnnotations;

namespace Bookva.Entities
{
	public class WorkRating
	{
		[Key]
		public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkId { get; set; }

        public virtual User User { get; set; }
		public virtual Work Work { get; set; }
		[Range(0,5)]
		public byte Mark { get; set; }
	}
}
