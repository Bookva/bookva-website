﻿using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class WorkRating
	{
		[Key]
		public int Id { get; set; }

		public virtual User User { get; set; }
		public virtual Work Work { get; set; }
		[Range(0,10)]
		public byte Mark { get; set; }
	}
}