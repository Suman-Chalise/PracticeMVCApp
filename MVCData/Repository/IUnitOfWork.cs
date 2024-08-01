using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MVCData.Repository
{
	public interface IUnitOfWork
	{
		IMovieRepository MovieUnit { get; } // adding Imovie repository inside IUnitofWork so that when we access Unitofwork we can access IMoviesRepository as well


		void Save();
	}
}
