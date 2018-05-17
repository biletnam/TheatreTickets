using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using BLL.Interfaces;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BLL.Services;

namespace PL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            using (DataContext db = new DataContext(new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).Options))
            {
                Seed(db);
            }
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<DataContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IUnitOfWork, TheatreUoW>();
            services.AddTransient<ITheatreService, TheatreService>();
            services.AddTransient<IOrderService, OrderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
        }

        public static void Seed(DataContext db)
        {
            //db.Database.EnsureDeleted();
            //if (db.Database.EnsureCreated())
            //{
                //Play play = new Play() { Name = "Romeo&Julietta", Theatre = theatre };
                //Hall hall = new Hall() { Name = "Green Hall", Play = play };
                //List<Place> places = new List<Place>()
                //{
                //    new Place() { Buyed = false, Number = 1, NumberRow = 1, Hall = hall },
                //    new Place() { Buyed = false, Number = 2, NumberRow = 1, Hall = hall },
                //    new Place() { Buyed = false, Number = 3, NumberRow = 1, Hall = hall },
                //};

                //db.Theatres.Add(theatre);
                //db.Halls.Add(hall);
                //db.Plays.Add(play);
                //db.Places.AddRange(places);

                //db.SaveChanges();
            //}
        }
    }
}
