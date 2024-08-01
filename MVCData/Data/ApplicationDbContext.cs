using Microsoft.EntityFrameworkCore;

using MVCModel.Models;
using MVCData.Data;

namespace MVCData.Data

//namespace MVC.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Movies>M_movies {  get; set; }
    }
}
