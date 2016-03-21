using System.Collections.Generic;
using System.Linq;

namespace Bookva.DAL
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> Get();
		T Get(int id);
		void Delete(int id);
		void Delete(T entityToDelete);
		void Delete(IEnumerable<T> entitiesToDelete);
		void Insert(T item);
		void Insert(IEnumerable<T> item);
        void Update(T item, int id);
    }
}
