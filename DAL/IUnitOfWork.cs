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
		IRepository<CustomCollection, int> CustomCollectionRepository { get; }
		IRepository<CustomCollectionItem, int> CustomCollectionItemRepository { get; }
		IRepository<FavouritesCollection, int> FavouritesCollectionRepository { get; }

		IRepository<Genre, int> GenreRepository { get; }

		IRepository<Keyword, int> KeywordRepository { get; }

		IRepository<ReadCollection, int> ReadCollectionRepository { get; }
		IRepository<RecentCollection, int> RecentCollectionRepository { get; }
		IRepository<Review, int> ReviewRepository { get; }
		IRepository<Work, int> WorkRepository { get; }
		IRepository<WorkRating, int> WorkRatingRepository { get; }
		IRepository<User, int> UserRepository { get; }
		void Save();
	}
}
