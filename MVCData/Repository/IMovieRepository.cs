using MVCModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCData.Repository
{

	// This interface is created to perform update and Save changes method only other methods are general
	public interface IMovieRepository : IRepository<Movies>
	{
		void Update(Movies obj);
		//void Save();  // We moved this to Unitofwork
	}
}
