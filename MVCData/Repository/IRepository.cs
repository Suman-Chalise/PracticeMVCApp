using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCData.Repository
{
	public interface IRepository<T> where T : class
	{

	  // T - will be catagory . we need to think of crud for category so we write all method, 

		IEnumerable<T> GetAll();  // getting all 

		//T GetFirstorDefault();  // below also same 

		T Get(Expression<Func<T, bool>> filter);  // This is general syntex for linq where we are using like this 
												  // var mov = _context.M_movies.FirstOrDefault(a => a.MovieId == id)

		void Add(T entity);
		//void Update(T entity);  
		void Delete(T entity);
		void DeleteRange(IEnumerable<T> entities);


		//void Remove(T entity);
		//void RemoveRange(IEnumerable<T> entities);

		// withing the generic repository we do not want to use update and save changes as their logic might be different so we will create Movie interface for those seperately 



	}
}
