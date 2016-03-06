using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		private DbContext context;

		private IRepository<User, int> userRepository;
		private IRepository<CustomCollection, int> customCollectionRepository;
		private IRepository<CustomCollectionItem, int> customCollectionItemRepository;
		private IRepository<FavouritesCollection, int> favouritesCollectionRepository;
		private IRepository<Genre, int> genreRepository;
		private IRepository<Keyword, int> keywordRepository;
		private IRepository<ReadCollection, int> readCollectionRepository;
		private IRepository<RecentCollection, int> recentCollectionRepository;
		private IRepository<Review, int> reviewRepository;
		private IRepository<Work, int> workRepository;
		private IRepository<WorkRating, int> workRatingRepository;

		public IRepository<CustomCollection, int> CustomCollectionRepository
		{
			get
			{
				if (customCollectionRepository == null)
				{
					customCollectionRepository = new Repository<CustomCollection, int>(context);
				}

				return customCollectionRepository;
			}
		}

		public IRepository<CustomCollectionItem, int> CustomCollectionItemRepository
		{
			get
			{
				if (customCollectionItemRepository == null)
				{
					customCollectionItemRepository = new Repository<CustomCollectionItem, int>(context);
				}

				return customCollectionItemRepository;
			}
		}

		public IRepository<FavouritesCollection, int> FavouritesCollectionRepository
		{
			get
			{
				if (favouritesCollectionRepository == null)
				{
					favouritesCollectionRepository = new Repository<FavouritesCollection, int>(context);
				}

				return favouritesCollectionRepository;
			}
		}

		public IRepository<Genre, int> GenreRepository
		{
			get
			{
				if (genreRepository == null)
				{
					genreRepository = new Repository<Genre, int>(context);
				}

				return genreRepository;
			}
		}

		public IRepository<Keyword, int> KeywordRepository
		{
			get
			{
				if (keywordRepository == null)
				{
					keywordRepository = new Repository<Keyword, int>(context);
				}

				return keywordRepository;
			}
		}

		public IRepository<ReadCollection, int> ReadCollectionRepository
		{
			get
			{
				if (readCollectionRepository == null)
				{
					readCollectionRepository = new Repository<ReadCollection, int>(context);
				}

				return readCollectionRepository;
			}
		}

		public IRepository<RecentCollection, int> RecentCollectionRepository
		{
			get
			{
				if (recentCollectionRepository == null)
				{
					recentCollectionRepository = new Repository<RecentCollection, int>(context);
				}

				return recentCollectionRepository;
			}
		}

		public IRepository<Review, int> ReviewRepository
		{
			get
			{
				if (reviewRepository == null)
				{
					reviewRepository = new Repository<Review, int>(context);
				}

				return reviewRepository;
			}
		}

		public IRepository<Work, int> WorkRepository
		{
			get
			{
				if (workRepository == null)
				{
					workRepository = new Repository<Work, int>(context);
				}

				return workRepository;
			}
		}

		public IRepository<WorkRating, int> WorkRatingRepository
		{
			get
			{
				if (workRatingRepository == null)
				{
					workRatingRepository = new Repository<WorkRating, int>(context);
				}

				return workRatingRepository;
			}
		}

		public IRepository<User, int> UserRepository
		{
			get
			{
				if (userRepository == null)
				{
					userRepository = new Repository<User, int>(context);
				}

				return userRepository;
			}
		}
		public UnitOfWork(DbContext context)
		{
			this.context = context;
		}

		public void Save()
		{
			context.SaveChanges();
		}

		#region IDisposable Members

		private bool disposed = false;

		public void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

	}
}
