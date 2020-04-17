using Microsoft.AspNetCore.Builder;
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
            services.AddDbContext<MyTunesContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBContext")));

            services.AddControllers();

            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "V2";
                    document.Info.Title = "MyTunes";
                    document.Info.Description = "ITunes mais sans licence ou moyen financier";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Beaupuy / Brangbour / Nolin",
                        Email = string.Empty,
                        Url = "https://youtu.be/dQw4w9WgXcQ"
                    };
                };
            });
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

            // Register the Swagger generator and the Swagger UI middlewares
            //http://localhost:5000/swagger
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}