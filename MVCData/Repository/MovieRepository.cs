using MVCData.Data;
using MVCModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCData.Repository
{
	/// <summary>
	/// This repository implementation is just created for 2 methods below 
	/// In general repository we did not implement below as sometimes user wants to update certain fields only 
	/// 
	/// 
	/// therefore we have implementation for 2 methods below which is "Update" and "Save Changes"
	/// </summary>
	public class MovieRepository : Repository<Movies>, IMovieRepository
	{

		private readonly ApplicationDbContext _db;

        public MovieRepository(ApplicationDbContext db) : base(db)
        {
			_db = db;
        }
  //      public void Save()
		//{
		//	// _db.SaveChanges();   // this is a global method so we will create UnitOfWork to handle this correctly 
		//}

		public void Update(Movies obj)
		{
			_db.M_movies.Update(obj);
		}
	}
}
