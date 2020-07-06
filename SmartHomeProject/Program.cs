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
            //AddNewDevice("raspberry", "raspberry 1", "mini pc", "192.168.1.20", "20", "badezimmer");
            CreateHostBuilder(args).Build().Run();
        }
        //test
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
