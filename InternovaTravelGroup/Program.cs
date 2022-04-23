using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Question_7_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternovaTravelGroup
{
    public class Program
    {
        /* public static void Main(string[] args)
         {
             CreateHostBuilder(args).Build().Run();
         }*/
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await InitialActionsAsync();
            await host.RunAsync();
            async Task InitialActionsAsync()
            {
                using var scope = host.Services.CreateScope();
                var services = scope.ServiceProvider;
                var logger = services.GetService<ILogger<Program>>();

                await RunPendingMigrationsAsync();

                async Task RunPendingMigrationsAsync()
                {
                    try
                    {
                        var dbContext = services.GetService<ApplicationDbContext>();
                        if (dbContext != null)
                        {
                            var pendingMigration = await dbContext.Database.GetPendingMigrationsAsync();
                            if (pendingMigration.Any())
                            {
                                await dbContext.Database.MigrateAsync();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        logger.LogWarning(e, $"Error running migrations");
                    }
                }
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
