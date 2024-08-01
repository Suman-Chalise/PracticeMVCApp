using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVCData.Data;
using MVCData.Repository;

namespace PracticeMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connections = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>( options => options.UseSqlServer(connections, b => b.MigrationsAssembly("PracticeMVC")));

           // builder.Services.AddScoped<IMovieRepository, MovieRepository>(); // added in to dependency injection

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
		




			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                 // pattern: "{controller=Movies}/{action=Index}/{id?}");
                 pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            //{area:exists}

            app.Run();
        }
    }
}
