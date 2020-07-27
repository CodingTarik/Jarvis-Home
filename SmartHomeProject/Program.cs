using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using static SmartHomeProject.ConnectionManager.DatabaseManager;

namespace SmartHomeProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebDatabase();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}