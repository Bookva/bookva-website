using System;
using Bookva.Entities;

namespace Bookva.DAL
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
        IRepository<Author> AuthorRepository { get; }
        void Save();
	}
}
