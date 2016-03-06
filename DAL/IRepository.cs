using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public interface IRepository<T, TKey> where T : class
	{
		IQueryable<T> Get();
		T Get(TKey id);
		void Delete(TKey id);
		void Delete(T entityToDelete);
		void Delete(IEnumerable<T> entitiesToDelete);
		void Insert(T item);
		void Insert(IEnumerable<T> item);

	}
}
