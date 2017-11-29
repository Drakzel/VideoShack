using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VideoShackBLL;
using VideoShackBLL.BusinessObjects;

namespace VideoRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();

                MovieBO movie = facade.GetVideoService.Create(
                    new MovieBO()
                    {
                        Name = "Titanic",
                        Genre = "Drama"
                    });

                MovieBO movie2 = facade.GetVideoService.Create(
                    new MovieBO()
                    {
                        Name = "Avatar the Last Airbender",
                        Genre = "Adventure"
                    });

                var collection = facade.GetCollectionService.Create(
                    new CollectionBO()
                    {
                        CreatedDate = DateTime.Now.AddMonths(-1),
                        Name = "Favorite Movies",
                        Movies = new List<MovieBO> ()
                    });
                collection.Movies.Add(movie);
                collection.Movies.Add(movie2);
            }

            app.UseMvc();
        }
    }
}
