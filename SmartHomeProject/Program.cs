using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using static SmartHomeProject.ConnectionManager.DatabaseManager;
using SmartHomeProject.Connections;

namespace SmartHomeProject
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateWebDatabase();
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
