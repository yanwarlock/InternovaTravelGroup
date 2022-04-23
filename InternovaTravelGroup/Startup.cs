using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Question_7_API.Data;
using Question_7_API.Mapping;
using Question_7_API.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InternovaTravelGroup
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
            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
           .UseLoggerFactory(loggerFactory));

            services.AddControllers();

            services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Internova Travel Group Test",
                    Description = " ",
                    Version = "v1.0",
                    Contact = new OpenApiContact
                    {
                        Name = "Maikel Blanco Dieguez",
                        Email = "yanwarlock@gmail.com",

                    }
                });
               
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swaggerGenOptions.IncludeXmlComments(xmlPath);
            }
          );

            services.AddScoped<FlightService>();

            services.AddAutoMapper(config =>
            {
                config.AddProfile<MapProfile>();
            },
              Assembly.GetExecutingAssembly()
          );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(SwaggerUIOption =>
            {
                SwaggerUIOption.SwaggerEndpoint("/swagger/v1/swagger.json", "InternovaTravelGroup");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
