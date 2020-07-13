using SmartHomeProject.Models;
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
              DeviceName VARCHAR(255) UNIQUE,
              DeviceType VARCHAR(255),
              DeviceDescription VARCHAR(255),
              DeviceLocation VARCHAR(255),
              DeviceIP VARCHAR(24),
              DevicePort INT,
              DeviceID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL DEFAULT(0)
             );";

        private const string createFunctionTable = @"CREATE TABLE deviceFunctions (
                DeviceID INTEGER,
                FunctionID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL DEFAULT(0),
                Functionname VARCHAR(255),
                GPIO_PIN BYTE,
                LOCATION VARCHAR(255),
                FOREIGN KEY (DeviceID) REFERENCES devices(DeviceID)
               );";
        internal static void CreateWebDatabase()
        {
            if (!File.Exists("WebDatabase.sqlite"))
            {
                try
                {

                    SQLiteConnection.CreateFile("WebDatabase.sqlite");
                    webDBConnection.Open();
                    SQLiteCommand createDeviceQuery = new SQLiteCommand(createDeviceTable, webDBConnection);
                    createDeviceQuery.ExecuteNonQuery();
                    createDeviceQuery = new SQLiteCommand(createFunctionTable, webDBConnection);
                    createDeviceQuery.ExecuteNonQuery();
                    //webDBConnection.Close();
                }
                catch (Exception ex)
                {
                    if (File.Exists("WebDatabase.sqlite"))
                    {
                        File.Delete("WebDatabase.sqlite");
                    }

                    throw ex;
                }
            }
            else
            {
                webDBConnection.Open();
            }
        }

        internal static bool AddNewDevice(string deviceName, string deviceType, string deviceDescription, string deviceIP, string devicePort, string deviceLocation)
        {
            try
            {
                //webDBConnection.Open();
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
                //webDBConnection.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler: " + e.Message);
                return false;
            }
         
        }

        internal static bool DeleteDevice(string deviceName)
        {
            try
            {
                //webDBConnection.Open();
                SQLiteCommand sqlQuery = new SQLiteCommand(webDBConnection);
                sqlQuery.CommandText = @"DELETE FROM devices WHERE DeviceName = @DeviceName";
                sqlQuery.Parameters.AddWithValue("@DeviceName", deviceName);
                sqlQuery.Prepare();
                bool result = sqlQuery.ExecuteNonQuery() > 0;
                //webDBConnection.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler: " + e.Message);
                return false;
            }
          
        }

        internal static bool UpdateDevice(string selectedDevice, string deviceNameNew, string deviceType,
            string deviceDescription, string deviceIP, string devicePort, string deviceLocation)
        {
            try
            {
                SQLiteCommand sqlQuery = new SQLiteCommand(webDBConnection);
                sqlQuery.CommandText = @"UPDATE devices 
            SET DeviceName = @deviceNameNew, DeviceType = @deviceType, DeviceDescription = @deviceDescription, DeviceLocation = @deviceLocation, DeviceIP = @deviceIP, DevicePort = @DevicePort
            WHERE DeviceName = @deviceName;";
                sqlQuery.Parameters.AddWithValue("@deviceName", selectedDevice);
                sqlQuery.Parameters.AddWithValue("@deviceNameNew", deviceNameNew);
                sqlQuery.Parameters.AddWithValue("@deviceType", deviceType);
                sqlQuery.Parameters.AddWithValue("@deviceDescription", deviceDescription);
                sqlQuery.Parameters.AddWithValue("@deviceLocation", deviceLocation);
                sqlQuery.Parameters.AddWithValue("@devicePort", devicePort);
                sqlQuery.Parameters.AddWithValue("@deviceIP", deviceIP);
                sqlQuery.Prepare();
                bool result = sqlQuery.ExecuteNonQuery() > 0;
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler: " + e.Message);
                return false;
            }
         
        }

        internal static bool AddFunctionToDevice(int deviceid, string functionname, byte GPIO_PIN)
        {
            try
            {
                SQLiteCommand sqlQuery = new SQLiteCommand(webDBConnection);
                sqlQuery.CommandText =
                    "INSERT INTO deviceFunctions (DeviceID, Functionname, GPIO_PIN, LOCATION) VALUES (@deviceID, @functionname, @GPIO_PIN, @location);";
                sqlQuery.Parameters.AddWithValue("@deviceID", deviceid);
                sqlQuery.Parameters.AddWithValue("@functionname", functionname);
                sqlQuery.Parameters.AddWithValue("@GPIO_PIN", GPIO_PIN);
                sqlQuery.Parameters.AddWithValue("@location", null);
                sqlQuery.Prepare();
                bool result = sqlQuery.ExecuteNonQuery() > 0;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler: " + ex.Message);
                return false;
            }

        }
        internal static DeviceModel[] getDeviceModels()
        {
            string query = "SELECT * FROM devices";
            //webDBConnection.Open();
            SQLiteCommand sqlQuery = new SQLiteCommand(query, webDBConnection);
            SQLiteDataReader resultReader = sqlQuery.ExecuteReader();
            List<DeviceModel> models = new List<DeviceModel>();
            while (resultReader.Read())
            {
                try
                {
                    DeviceModel model = new DeviceModel(resultReader.GetString(4), resultReader.GetInt32(5))
                    {
                        Image = Properties.Resources.raspi,
                        Name = resultReader.GetString(0),
                        Location = resultReader.GetString(3),
                        Type = resultReader.GetString(1),
                        description = resultReader.GetString(2),
                        deviceID = resultReader.GetInt32(6)
                    };
                    SQLiteCommand functionQuery = new SQLiteCommand(webDBConnection);
                    functionQuery.CommandText = @"SELECT * FROM deviceFunctions WHERE deviceFunctions.DeviceID = @DeviceID";
                    functionQuery.Parameters.AddWithValue("@DeviceID", model.deviceID);
                    functionQuery.Prepare();
                    SQLiteDataReader functionReader = functionQuery.ExecuteReader();
                    while (functionReader.Read())
                    {
                        Console.WriteLine(functionReader.GetDataTypeName(2) + functionReader.GetDataTypeName(4));
                        
                        model.addDeviceModelFunction(functionReader.GetInt32(1), (byte)functionReader.GetInt32(3), functionReader.IsDBNull(2) ? null : functionReader.GetString(2), functionReader.IsDBNull(4) ? null : functionReader.GetString(4));
                    }
                    models.Add(model);
                }
                catch (Exception ex)
               {
                    Console.WriteLine("Fehler: " + ex.Message + ex.StackTrace);
               }
            }



            //webDBConnection.Close();
            return models.ToArray();

        }

    }
}
