﻿using SmartHomeProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace SmartHomeProject.ConnectionManager
{
    public class DatabaseManager
    {
        public static SQLiteConnection webDBConnection = new SQLiteConnection("Data Source=WebDatabase.sqlite;Version=3;");

        /// <summary>
        /// Has Attributes: DeviceName, DeviceType, DeviceDescription, DeviceLocation, DeviceIP, DevicePort
        /// </summary>
        private const string createDeviceTable = @"CREATE TABLE devices (
              DeviceName VARCHAR(255) PRIMARY KEY,
              DeviceType VARCHAR(255),
              DeviceDescription VARCHAR(255),
              DeviceLocation VARCHAR(255),
              DeviceIP VARCHAR(24),
              DevicePort INT
             );";

        internal static void CreateWebDatabase()
        {
            if (!File.Exists("WebDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("WebDatabase.sqlite");
                webDBConnection.Open();
                SQLiteCommand createDeviceQuery = new SQLiteCommand(createDeviceTable, webDBConnection);
                createDeviceQuery.ExecuteNonQuery();
                webDBConnection.Close();
            }
        }

        internal static bool AddNewDevice(string deviceName, string deviceType, string deviceDescription, string deviceIP, string devicePort, string deviceLocation)
        {
            webDBConnection.Open();
            SQLiteCommand sqlQuery = new SQLiteCommand(webDBConnection);
            sqlQuery.CommandText =
                @"INSERT INTO devices(DeviceName, DeviceType, DeviceDescription, DeviceLocation, DeviceIP, DevicePort)
            VALUES(@DeviceName, @DeviceType, @DeviceDescription, @DeviceLocation, @DeviceIP, @DevicePort)";
            sqlQuery.Parameters.AddWithValue("@DeviceName", deviceName);
            sqlQuery.Parameters.AddWithValue("@DeviceType", deviceType);
            sqlQuery.Parameters.AddWithValue("@DeviceDescription", deviceDescription);
            sqlQuery.Parameters.AddWithValue("@DeviceLocation", deviceLocation);
            sqlQuery.Parameters.AddWithValue("@DeviceIP", deviceIP);
            if (String.IsNullOrEmpty(devicePort))
            {
                devicePort = "333";
            }
            sqlQuery.Parameters.AddWithValue("@DevicePort", int.Parse(devicePort));
            sqlQuery.Prepare();
            bool result = sqlQuery.ExecuteNonQuery() != 0;
            webDBConnection.Close();
            return result;
        }

        internal static bool DeleteDevice(string deviceName)
        {
            webDBConnection.Open();
            SQLiteCommand sqlQuery = new SQLiteCommand(webDBConnection);
            sqlQuery.CommandText = @"DELETE FROM devices WHERE DeviceName = @DeviceName";
            sqlQuery.Parameters.AddWithValue("@DeviceName", deviceName);
            sqlQuery.Prepare();
            bool result = sqlQuery.ExecuteNonQuery() != 0;
            webDBConnection.Close();
            return result;
        }

        internal static DeviceModel[] getDeviceModels()
        {
            string query = "SELECT * FROM devices";
            webDBConnection.Open();
            SQLiteCommand sqlQuery = new SQLiteCommand(query, webDBConnection);
            SQLiteDataReader resultReader = sqlQuery.ExecuteReader();
            List<DeviceModel> models = new List<DeviceModel>();
            while (resultReader.Read())
            {
                try
                {
                    DeviceModel model = new DeviceModel(resultReader.GetString(4), resultReader.GetInt32(5))
                    {
                        Image = Properties.Resources.raspi, Name = resultReader.GetString(0),
                        Location = resultReader.GetString(3), Type = resultReader.GetString(1),
                        description = resultReader.GetString(3)
                    };
                    models.Add(model);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fehler: " + ex.Message);
                }
            }



            webDBConnection.Close();
            return models.ToArray();

        }

    }
}