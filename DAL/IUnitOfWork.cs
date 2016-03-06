using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<CustomCollection> CustomCollectionRepository { get; }
		IRepository<CustomCollectionItem> CustomCollectionItemRepository { get; }
		IRepository<FavouritesCollection> FavouritesCollectionRepository { get; }

		IRepository<Genre> GenreRepository { get; }

		IRepository<Keyword> KeywordRepository { get; }

		IRepository<ReadCollection> ReadCollectionRepository { get; }
		IRepository<RecentCollection> RecentCollectionRepository { get; }
		IRepository<Review> ReviewRepository { get; }
		IRepository<Work> WorkRepository { get; }
		IRepository<WorkRating> WorkRatingRepository { get; }
		IRepository<User> UserRepository { get; }
		void Save();
	}
}
