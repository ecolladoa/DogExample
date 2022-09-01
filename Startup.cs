using DogExample.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json;

namespace DogExample
{
    public class Startup
    {
        internal IWebHostEnvironment Environment { get; }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllersWithViews()
            .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
             });
            services.AddDbContext<DogExampleContext>(options => options.UseSqlServer("name = ConnectionStrings:RepositoryDB"));
            services.AddSingleton(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            // Use CORS from setting
            app.UseCors(cp =>
            {
                var origins = Configuration.GetValue("AllowedOrigins", "").Split(";", System.StringSplitOptions.RemoveEmptyEntries);
                if (origins.Length == 0)
                {
                    Log.Information("No CORS policy is configured.");
                }
                else
                {
                    if (origins.Length == 1 && origins[0] == "*")
                    {
                        cp.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                        Log.Information("Configured CORS policy to allow all.");
                    }
                    else
                    {
                        cp.WithOrigins(origins)
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .AllowAnyHeader();
                        Log.Information("Configured CORS policy for the following allowed origins: {0}.", string.Join(",", origins));
                    }
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller}/{action=Index}/{id?}");

                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
