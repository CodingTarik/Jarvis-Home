using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Data.SQLite;

namespace SmartHomeProject
{
    public class Program
    {
        public static SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=WebDatabase.sqlite;Version=3;");
        public static void Main(string[] args)
        {
            if (!File.Exists("WebDatabase.sqlite"))
            { 
                SQLiteConnection.CreateFile("WebDatabase.sqlite");
                m_dbConnection.Open();
                string createDeviceTable =
                    "CREATE TABLE devices (DeviceName VARCHAR(255));";
                SQLiteCommand createDeviceQuery = new SQLiteCommand(createDeviceTable, m_dbConnection);
                createDeviceQuery.ExecuteNonQuery();
                m_dbConnection.Close();
            }
           

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
