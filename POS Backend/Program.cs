using POS_Backend.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using POS_Backend.Seeds;
using System.Threading.Tasks;

namespace POS_Backend
{
    public class Program
    {


        public static async Task Main(string[] args)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;



            //Dodavanje usermanagera i rolemanagera iz IDENTITY

            var context = services.GetRequiredService<Context>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
            await context.Database.MigrateAsync();
            await Seed.SeedUsers(context,userManager,roleManager);
            await host.RunAsync();

        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(WebHostBuilderOptions =>
            {
                WebHostBuilderOptions.UseStartup<Startup>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            })
            .UseNLog();

    }
}
