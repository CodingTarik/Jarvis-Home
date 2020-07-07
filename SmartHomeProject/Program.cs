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
            //AddNewDevice("raspberry", "raspberry 1", "mini pc", "192.168.1.20", "20", "badezimmer");
            Connections.DeviceConnectionManager cs = new Connections.DeviceConnectionManager("127.0.0.1", 333);
            cs.SendMessage("rrrrrrrrrrrr");
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
