﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MyTunes.Models;

namespace MyTunes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AlbumContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBContext")));
            services.AddDbContext<ArtisteContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBContext")));
            services.AddDbContext<EditeurContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBContext")));
            services.AddDbContext<GenreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBContext")));
            services.AddDbContext<MusiqueContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBContext")));
            services.AddDbContext<PochetteContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBContext")));
            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBContext")));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}