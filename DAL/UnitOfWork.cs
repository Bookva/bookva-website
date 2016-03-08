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

		private IRepository<User> userRepository;
		private IRepository<CustomCollection> customCollectionRepository;
		private IRepository<CustomCollectionItem> customCollectionItemRepository;
		private IRepository<FavouritesCollection> favouritesCollectionRepository;
		private IRepository<Genre> genreRepository;
		private IRepository<Keyword> keywordRepository;
		private IRepository<ReadCollection> readCollectionRepository;
		private IRepository<RecentCollection> recentCollectionRepository;
		private IRepository<Review> reviewRepository;
		private IRepository<Work> workRepository;
		private IRepository<WorkRating> workRatingRepository;
	    private IRepository<Author> authorRepository;

		public IRepository<CustomCollection> CustomCollectionRepository
		{
			get
			{
				if (customCollectionRepository == null)
				{
					customCollectionRepository = new Repository<CustomCollection>(context);
				}

				return customCollectionRepository;
			}
		}

		public IRepository<CustomCollectionItem> CustomCollectionItemRepository
		{
			get
			{
				if (customCollectionItemRepository == null)
				{
					customCollectionItemRepository = new Repository<CustomCollectionItem>(context);
				}

				return customCollectionItemRepository;
			}
		}

		public IRepository<FavouritesCollection> FavouritesCollectionRepository
		{
			get
			{
				if (favouritesCollectionRepository == null)
				{
					favouritesCollectionRepository = new Repository<FavouritesCollection>(context);
				}

				return favouritesCollectionRepository;
			}
		}

		public IRepository<Genre> GenreRepository
		{
			get
			{
				if (genreRepository == null)
				{
					genreRepository = new Repository<Genre>(context);
				}

				return genreRepository;
			}
		}

		public IRepository<Keyword> KeywordRepository
		{
			get
			{
				if (keywordRepository == null)
				{
					keywordRepository = new Repository<Keyword>(context);
				}

				return keywordRepository;
			}
		}

		public IRepository<ReadCollection> ReadCollectionRepository
		{
			get
			{
				if (readCollectionRepository == null)
				{
					readCollectionRepository = new Repository<ReadCollection>(context);
				}

				return readCollectionRepository;
			}
		}

		public IRepository<RecentCollection> RecentCollectionRepository
		{
			get
			{
				if (recentCollectionRepository == null)
				{
					recentCollectionRepository = new Repository<RecentCollection>(context);
				}

				return recentCollectionRepository;
			}
		}

		public IRepository<Review> ReviewRepository
		{
			get
			{
				if (reviewRepository == null)
				{
					reviewRepository = new Repository<Review>(context);
				}

				return reviewRepository;
			}
		}

		public IRepository<Work> WorkRepository
		{
			get
			{
				if (workRepository == null)
				{
					workRepository = new Repository<Work>(context);
				}

				return workRepository;
			}
		}

		public IRepository<WorkRating> WorkRatingRepository
		{
			get
			{
				if (workRatingRepository == null)
				{
					workRatingRepository = new Repository<WorkRating>(context);
				}

				return workRatingRepository;
			}
		}

		public IRepository<User> UserRepository
		{
			get
			{
				if (userRepository == null)
				{
					userRepository = new Repository<User>(context);
				}

				return userRepository;
			}
		}

	    public IRepository<Author> AuthorRepository
	    {
	        get
	        {
	            if (authorRepository == null)
	            {
                    authorRepository = new Repository<Author>(context);
	            }

	            return authorRepository;
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
