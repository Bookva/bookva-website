﻿using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class FavouritesCollection
	{
		[Key]
		public int Id { get; set; }

		public virtual User User { get; set; }
		public virtual Work Work { get; set; }
	}
}
