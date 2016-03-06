using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private DbContext context;
		private DbSet<T> entities;

		public Repository(DbContext context)
		{
			this.context = context;
			entities = context.Set<T>();
		}

		public Repository(DbContext context, DbSet<T> entities)
		{
			this.context = context;
			this.entities = entities;
		}

		public virtual IQueryable<T> Get()
		{
			return entities.Take(entities.Count());
		}

		public virtual T Get(int id)
		{
			return entities.Find(id);
		}

		public virtual void Delete(int id)
		{
			var entityToDelete = entities.Find(id);
			Delete(entityToDelete);
		}

		public virtual void Delete(T entityToDelete)
		{
			if (context.Entry(entityToDelete).State == EntityState.Detached)
			{
				entities.Attach(entityToDelete);
			}

			entities.Remove(entityToDelete);
		}

		public virtual void Delete(IEnumerable<T> entitiesToDelete)
		{
			entitiesToDelete = entitiesToDelete.ToList();
			foreach (var entity in entitiesToDelete.Where(entity => context.Entry(entity).State == EntityState.Detached))
			{
				entities.Attach(entity);
			}

			entities.RemoveRange(entitiesToDelete);
		}

		public virtual void Insert(T item)
		{
			entities.Add(item);
		}

		public virtual void Insert(IEnumerable<T> item)
		{
			entities.AddRange(item);
		}
	}
}
