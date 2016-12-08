using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MicroServices.DotNETCore.Web.API.Repository;
using Swashbuckle.Swagger.Model;

namespace MicroServices.DotNETCore.Web.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                
            builder.AddEnvironmentVariables("ASPNETCORE_");
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add SQL Server support
            services
                .AddDbContext<DockerCommandsDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DbContext:DockerCommandsConnectionString"]))
                .AddDbContext<CustomersDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DbContext:CustomersConnectionString"]));

            // Add framework services.
            services.AddMvc();

            // Add our SQL Server Repositories (scoped to each request)
            services.AddScoped<IDockerCommandsRepository, DockerCommandsRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();

            //Transient: Created each time they're needed
            services.AddTransient<DockerCommandsDbSeeder>();
            services.AddTransient<CustomersDbSeeder>();
            
            //Nice article by Shayne Boyer here on Swagger:
            //https://docs.asp.net/en/latest/tutorials/web-api-help-pages-using-swagger.html
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "ASP.NET Core Customers API",
                    Description = "ASP.NET Core Customers Web API documentation",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Salvador Parra", Url = "http://twitter.com/salvadorparra" },
                    License = new License { Name = "MIT", Url = "https://en.wikipedia.org/wiki/MIT_License" }
                });

                //Enable following for XML comment support and add "xmlDoc": true to buildOptions in project.json

                //Base app path 
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                //Set the comments path for the swagger json and ui.
                //options.IncludeXmlComments(basePath + "\\yourAPI.xml");

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
                              DockerCommandsDbSeeder dockerCommandsDbSeeder, CustomersDbSeeder customersDbSeeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //https://github.com/aspnet/JavaScriptServices/blob/dev/samples/angular/MusicStore/Startup.cs
                //routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Customers", action = "Index" });

                routes.MapRoute(
                    name: "spa-fallback",
                    template: "{*anything}",
                    defaults: new { controller = "Customers", action = "Index" });
            });

            customersDbSeeder.SeedAsync(app.ApplicationServices).Wait();
            dockerCommandsDbSeeder.SeedAsync(app.ApplicationServices).Wait();
        }
    }
}
