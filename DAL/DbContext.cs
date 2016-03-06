﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using IdentityRole = Entities.IdentityRole;
using IdentityUserClaim = Entities.IdentityUserClaim;
using IdentityUserLogin = Entities.IdentityUserLogin;
using IdentityUserRole = Entities.IdentityUserRole;

namespace DAL
{
	
	public class BookvaDbContext :
		IdentityDbContext
			<User, IdentityRole, int, IdentityUserLogin, IdentityUserRole,
				IdentityUserClaim>
	{
		public BookvaDbContext()
			: base("DefaultConnection")
		{
		}

		public static BookvaDbContext Create()
		{
			return new BookvaDbContext();
		}

		public virtual DbSet<CustomCollection> CustomCollections { get; set; }
		public virtual DbSet<CustomCollectionItem> CustomCollectionItems { get; set; }
		public virtual DbSet<FavouritesCollection> FavouritesCollections { get; set; }
		public virtual DbSet<Genre> Genres { get; set; }
		public virtual DbSet<Keyword> Keywords { get; set; }
		public virtual DbSet<RecentCollection> RecentCollections { get; set; }
		public virtual DbSet<ReadCollection> ReadCollections { get; set; }
		public virtual DbSet<Review> Reviews { get; set; }
		public virtual DbSet<Work> Works { get; set; }

		public virtual DbSet<WorkRating> WorkRatings { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

			modelBuilder.Entity<User>().ToTable("Users");
		}
	}
}
