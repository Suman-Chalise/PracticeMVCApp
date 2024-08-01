using Microsoft.EntityFrameworkCore;
using MVCData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using PracticeMVCApp.MVCData.Repository;

namespace MVCData.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{

		private readonly ApplicationDbContext _db;

		internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
			_db = db;  
			this.dbSet = _db.Set<T>();

			// in simple world
			// _db.M_movies == db.Set<T>();
        }
        public void Add(T entity)
		{
			//throw new NotImplementedException();
			_db.Add(entity);
			
		}

		public void Delete(T entity)
		{
			dbSet.Remove(entity);
		}

		public void DeleteRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}

		//public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
		//{
		//	throw new NotImplementedException();
		//}

		public T Get(Expression<Func<T, bool>> filter)  // adding the using statement above for linq 
		{
			IQueryable<T> query = dbSet;
			query = query.Where(filter);
			//return query.FirstOrDefault();

			return query.First();
		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> query = dbSet;
			return query.ToList();
		}
	}
}
