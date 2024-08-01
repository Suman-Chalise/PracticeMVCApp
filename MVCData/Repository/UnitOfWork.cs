using MVCData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCData.Repository
{
	public class UnitOfWork : IUnitOfWork
	{

		private readonly ApplicationDbContext _db;
		public IMovieRepository MovieUnit { get; private set; }
		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			MovieUnit = new MovieRepository(_db);
		}


		////public IMovieRepository MovieRepository => throw new NotImplementedException();
		//public IMovieRepository MovieRepository { get; private set; }

		public void Save()
		{
			//throw new NotImplementedException();
			_db.SaveChanges();
		}
	}
}
