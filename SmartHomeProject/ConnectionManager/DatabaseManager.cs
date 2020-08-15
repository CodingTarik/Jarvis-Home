using SmartHomeProject.Models;
using SmartHomeProject.Properties;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace SmartHomeProject.ConnectionManager
{
    public class DatabaseManager
    {
        /// <summary>
        ///     Has Attributes: DeviceName, DeviceType, DeviceDescription, DeviceLocation, DeviceIP, DevicePort
        /// </summary>
        private const string createDeviceTable = @"CREATE TABLE devices (
              DeviceName VARCHAR(255) UNIQUE,
              DeviceType VARCHAR(255),
              DeviceDescription VARCHAR(255),
              DeviceLocation VARCHAR(255),
              DeviceIP VARCHAR(24),
              DevicePort INT DEFAULT(333) NOT NULL,
              DeviceID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL DEFAULT(0)
             );";

        /// <summary>
        ///     DeviceID, FunctionID, Functionname, GPIO_PIN, Location, RGB
        /// </summary>
        private const string createFunctionTable = @"CREATE TABLE deviceFunctions (
                DeviceID INTEGER NOT NULL,
                FunctionID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL DEFAULT(0),
                Functionname VARCHAR(255),
                GPIO_PIN BYTE NOT NULL,
                LOCATION VARCHAR(255),
                RGB INTEGER DEFAULT(0) CHECK(RGB IN (0,1)),
                FOREIGN KEY (DeviceID) REFERENCES devices(DeviceID)
               );";

        /// <summary>
        ///     DeviceID, SensorID, Sensor, GPIO_PINS, LOCATION, PYTHON
        /// </summary>
        private const string createSensorTable = @"CREATE TABLE sensors (
                DeviceID INTEGER NOT NULL,
                SensorID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL DEFAULT(0),
                Sensor VARCHAR(255) NOT NULL,
                GPIO_PINS VARCHAR(255) NOT NULL,
                LOCATION VARCHAR(255) NOT NULL,
                PYTHON VARCHAR(32000) NOT NULL,
                FOREIGN KEY (DeviceID) REFERENCES devices(DeviceID)
               );";

        private const string createSettingsTable = @"CREATE TABLE settings ( Bootstrap VARCHAR(255) NOT NULL );";

        public static SQLiteConnection webDBConnection =
            new SQLiteConnection("Data Source=WebDatabase.sqlite;Version=3;");

        public static string getBootstrap()
        {
            try
            {
                var query = "SELECT * FROM settings";
                var sqlQuery = new SQLiteCommand(query, webDBConnection);
                var reader = sqlQuery.ExecuteReader();
                string bootstrap = reader.Read() ? reader.GetString(0) : "bootstrap-Flatly.css";
                return bootstrap;
            }
            catch (Exception ex)
            {
                Logger.Logger.logError(Logger.Logger.Category.DATABASE, "ERROR reading bootstrap value", ex);
            }
            return "booststrap-Litera.css";
        }

        internal static bool updateActiveBootstrap(string name)
        {
            try
            {
                var query = "UPDATE settings SET Bootstrap = @BOOTSTRAP";
                var sqlQuery = new SQLiteCommand(query, webDBConnection);
                sqlQuery.Parameters.AddWithValue("@BOOTSTRAP", name);
                sqlQuery.Prepare();
                return sqlQuery.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Logger.Logger.logError(Logger.Logger.Category.DATABASE, "ERROR updating bootstrap value to: " + name + "; " + ex.Message, ex);
            }
            return false;
        }
        internal static string getSensornameById(int id)
        {
            try
            {
                var command = new SQLiteCommand(webDBConnection);
                command.CommandText = "SELECT Sensor FROM sensors WHERE SensorID = @SensorID";
                command.Parameters.AddWithValue("@SensorID", id);
                command.Prepare();
                var reader = command.ExecuteReader();
                return reader.GetString(0);
            }
            catch (Exception e)
            {
                Logger.Logger.logError(Logger.Logger.Category.DATABASE, e.Message, e);
                return "ERROR";
            }
        }

        /// <summary>
        ///     Checks for existance of a sqlite database and creates one
        /// </summary>
        internal static void CreateWebDatabase()
        {
            if (!File.Exists("WebDatabase.sqlite"))
            {
                try
                {
                    SQLiteConnection.CreateFile("WebDatabase.sqlite");
                    webDBConnection.Open();
                    var createDeviceQuery = new SQLiteCommand(createDeviceTable, webDBConnection);
                    createDeviceQuery.ExecuteNonQuery();
                    createDeviceQuery = new SQLiteCommand(createFunctionTable, webDBConnection);
                    createDeviceQuery.ExecuteNonQuery();
                    createDeviceQuery = new SQLiteCommand(createSensorTable, webDBConnection);
                    createDeviceQuery.ExecuteNonQuery();
                    createDeviceQuery = new SQLiteCommand(createSettingsTable, webDBConnection);
                    createDeviceQuery.ExecuteNonQuery();
                    createDeviceQuery = new SQLiteCommand("INSERT INTO settings VALUES ('bootstrap-Flatly.css');", webDBConnection);
                    createDeviceQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    webDBConnection.Close();
                    webDBConnection.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Logger.Logger.logError(Logger.Logger.Category.DATABASE, "Critical error: " + ex.Message + "; No database could be created", ex);
                    try
                    {
                        int i = 0;
                        while (IsFileLocked("WebDatabase.sqlite"))
                        {
                            System.Threading.Thread.Sleep(100);
                            i++;
                            if (i == 25)
                            {
                                throw new IOException("Could not get access to database");
                            }
                        }
                        if (File.Exists("WebDatabase.sqlite"))
                        {
                            File.Delete("WebDatabase.sqlite");
                        }
                    }
                    catch (Exception exx)
                    {
                        Logger.Logger.logError(Logger.Logger.Category.DATABASE, "Critical error: " + exx.Message + "; couldn't delete damaged database", exx);
                    }

                    throw ex;
                }
            }
            else
            {
                webDBConnection.Open();
            }
        }
        public static bool IsFileLocked(string filename)
        {
            bool Locked = false;
            try
            {
                FileStream fs =
                    File.Open(filename, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch (IOException ex)
            {
                Locked = true;
            }
            return Locked;
        }
        /// <summary>
        ///     Add new device
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="deviceType"></param>
        /// <param name="deviceDescription"></param>
        /// <param name="deviceIP"></param>
        /// <param name="devicePort"></param>
        /// <param name="deviceLocation"></param>
        /// <returns></returns>
        internal static bool AddNewDevice(string deviceName, string deviceType, string deviceDescription,
            string deviceIP, string devicePort, string deviceLocation)
        {
            try
            {
                //webDBConnection.Open();
                var sqlQuery = new SQLiteCommand(webDBConnection);
                sqlQuery.CommandText =
                    @"INSERT INTO devices(DeviceName, DeviceType, DeviceDescription, DeviceLocation, DeviceIP, DevicePort)
            VALUES(@DeviceName, @DeviceType, @DeviceDescription, @DeviceLocation, @DeviceIP, @DevicePort)";
                sqlQuery.Parameters.AddWithValue("@DeviceName", deviceName);
                sqlQuery.Parameters.AddWithValue("@DeviceType", deviceType);
                sqlQuery.Parameters.AddWithValue("@DeviceDescription", deviceDescription);
                sqlQuery.Parameters.AddWithValue("@DeviceLocation", deviceLocation);
                sqlQuery.Parameters.AddWithValue("@DeviceIP", deviceIP);
                if (string.IsNullOrEmpty(devicePort))
                {
                    devicePort = "333";
                }

                sqlQuery.Parameters.AddWithValue("@DevicePort", int.Parse(devicePort));
                sqlQuery.Prepare();
                var result = sqlQuery.ExecuteNonQuery() != 0;
                //webDBConnection.Close();
                return result;
            }
            catch (Exception e)
            {
                Logger.Logger.logError(Logger.Logger.Category.DATABASE, e.Message, e);
                return false;
            }
        }

        /// <summary>
        ///     Deletes a device by name
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        internal static bool DeleteDevice(string deviceName)
        {
            try
            {
                var sqlQuery = new SQLiteCommand(webDBConnection);
                sqlQuery.CommandText = @"SELECT DeviceID FROM devices WHERE DeviceName = @DeviceName";
                sqlQuery.Parameters.AddWithValue("@DeviceName", deviceName);
                sqlQuery.Prepare();
                var reader = sqlQuery.ExecuteReader();
                var id = 0;
                if (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                else
                {
                    throw new ObjectNotFoundException("Couldn't get device id of " + deviceName + " for deletion");
                }

                var tr = webDBConnection.BeginTransaction();
                try
                {
                    sqlQuery.CommandText = @"DELETE FROM deviceFunctions WHERE DeviceID = @DeviceID";
                    sqlQuery.Parameters.AddWithValue("@DeviceID", id);
                    sqlQuery.Transaction = tr;
                    sqlQuery.Prepare();
                    sqlQuery.ExecuteNonQuery();

                    sqlQuery.CommandText = @"DELETE FROM sensors WHERE DeviceID = @DeviceID";
                    sqlQuery.Parameters.AddWithValue("@DeviceID", id);
                    sqlQuery.Transaction = tr;
                    sqlQuery.Prepare();
                    sqlQuery.ExecuteNonQuery();

                    sqlQuery.CommandText = @"DELETE FROM devices WHERE DeviceName = @DeviceName";
                    sqlQuery.Parameters.AddWithValue("@DeviceName", deviceName);
                    sqlQuery.Transaction = tr;
                    sqlQuery.Prepare();
                    var result1 = sqlQuery.ExecuteNonQuery() > 0;
                    if (!result1)
                    {
                        tr.Rollback();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    tr.Rollback();
                    return false;
                }

                tr.Commit();
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.logError(Logger.Logger.Category.DATABASE, e.Message, e);
                return false;
            }
        }

        /// <summary>
        ///     Updates a device
        /// </summary>
        /// <param name="selectedDevice"></param>
        /// <param name="deviceNameNew"></param>
        /// <param name="deviceType"></param>
        /// <param name="deviceDescription"></param>
        /// <param name="deviceIP"></param>
        /// <param name="devicePort"></param>
        /// <param name="deviceLocation"></param>
        /// <returns></returns>
        internal static bool UpdateDevice(string selectedDevice, string deviceNameNew, string deviceType,
            string deviceDescription, string deviceIP, string devicePort, string deviceLocation)
        {
            try
            {
                var sqlQuery = new SQLiteCommand(webDBConnection);
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
                var result = sqlQuery.ExecuteNonQuery() > 0;
                return result;
            }
            catch (Exception e)
            {
                Logger.Logger.logError(Logger.Logger.Category.DATABASE, e.Message, e);
                return false;
            }
        }

        /// <summary>
        ///     Updates a device function
        /// </summary>
        /// <param name="functionID"></param>
        /// <param name="functionname"></param>
        /// <param name="GPIO_PIN"></param>
        /// <param name="location"></param>
        /// <param name="RGB"></param>
        /// <returns></returns>
        internal static bool UpdateDeviceFunction(int functionID, string functionname, byte GPIO_PIN, string location,
            bool RGB)
        {
            try
            {
                var sqlQuery = new SQLiteCommand(webDBConnection);
                sqlQuery.CommandText = @"UPDATE deviceFunctions
                SET Functionname = @functionname, GPIO_PIN = @GPIO_PIN, LOCATION = @location, RGB = @RGB
                WHERE FunctionID = @functionID";
                sqlQuery.Parameters.AddWithValue("@functionID", functionID);
                sqlQuery.Parameters.AddWithValue("@functionname", functionname);
                sqlQuery.Parameters.AddWithValue("@GPIO_PIN", GPIO_PIN);
                sqlQuery.Parameters.AddWithValue("@location", location);
                sqlQuery.Parameters.AddWithValue("@RGB", RGB ? 1 : 0);
                sqlQuery.Prepare();
                var result = sqlQuery.ExecuteNonQuery() > 0;
                return result;
            }
            catch (Exception ex)
            {
                Logger.Logger.logError(Logger.Logger.Category.DATABASE, ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        ///     Updates a sensor
        /// </summary>
        /// <param name="sensorID"></param>
        /// <param name="sensorname"></param>
        /// <param name="GPIO_PINS"></param>
        /// <param name="python"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        internal static bool UpdateSensor(int sensorID, string sensorname, byte[] GPIO_PINS, string python,
            string location = "")
        {
            try
            {
                var sqlQuery = new SQLiteCommand(webDBConnection);
                sqlQuery.CommandText = @"UPDATE Sensors
                SET Sensor = @sensorname, GPIO_PINS = @GPIO_PINS, LOCATION = @location, PYTHON = @python
                WHERE SensorID = @SensorID";
                var pinBuilder = new StringBuilder();
                for (var i = 0; i < GPIO_PINS.Length; i++)
                {
                    if (i + 1 == GPIO_PINS.Length)
                    {
                        pinBuilder.Append(GPIO_PINS[i].ToString());
                    }
                    else
                    {
                        pinBuilder.Append(GPIO_PINS[i] + ";");
                    }
                }

                sqlQuery.Parameters.AddWithValue("@sensorname", sensorname);
                sqlQuery.Parameters.AddWithValue("@GPIO_PINS", pinBuilder.ToString());
                sqlQuery.Parameters.AddWithValue("@location", location);
                sqlQuery.Parameters.AddWithValue("@python", python);
                sqlQuery.Parameters.AddWithValue("@SensorID", sensorID);
                sqlQuery.Prepare();
                var result = sqlQuery.ExecuteNonQuery() > 0;
                return result;
            }
            catch (Exception ex)
            {
                Logger.Logger.logError(Logger.Logger.Category.DATABASE, ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        ///     Deletes a device function
        /// </summary>
        /// <param name="functionID"></param>
        /// <returns></returns>
        internal static bool DeleteDeviceFunction(int functionID)
        {
            try
            {
                var sqlQuery = new SQLiteCommand(webDBConnection);
                sqlQuery.CommandText = @"DELETE FROM deviceFunctions WHERE FunctionID = @FunctionID";
                sqlQuery.Parameters.AddWithValue("@FunctionID", functionID);
                sqlQuery.Prepare();
                var result = sqlQuery.ExecuteNonQuery() > 0;
                return result;
            }
            catch (Exception e)
            {
                Logger.Logger.logError(Logger.Logger.Category.DATABASE, e.Message, e);
                return false;
            }
        }

        /// <summary>
        ///     Deletes a sensor
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        internal static bool DeleteSensor(int SensorID)
        {
            try
            {
                var sqlQuery = new SQLiteCommand(webDBConnection);
                sqlQuery.CommandText = @"DELETE FROM Sensors WHERE SensorID = @SensorID";
                sqlQuery.Parameters.AddWithValue("@SensorID", SensorID);
                sqlQuery.Prepare();
                var result = sqlQuery.ExecuteNonQuery() > 0;
                return result;
            }
            catch (Exception e)
            {
                Logger.Logger.logError(Logger.Logger.Category.DATABASE, e.Message, e);
                return false;
            }
        }

        /// <summary>
        ///     Adds function to device
        /// </summary>
        /// <param name="deviceid"></param>
        /// <param name="functionname"></param>
        /// <param name="GPIO_PIN"></param>
        /// <param name="RGB"></param>
        /// <returns></returns>
        internal static bool AddFunctionToDevice(int deviceid, string functionname, byte GPIO_PIN, bool RGB)
        {
            try
            {
                var sqlQuery = new SQLiteCommand(webDBConnection);
                sqlQuery.CommandText =
                    "INSERT INTO deviceFunctions (DeviceID, Functionname, GPIO_PIN, LOCATION, RGB) VALUES (@deviceID, @functionname, @GPIO_PIN, @location, @RGB);";
                sqlQuery.Parameters.AddWithValue("@deviceID", deviceid);
                sqlQuery.Parameters.AddWithValue("@functionname", functionname);
                sqlQuery.Parameters.AddWithValue("@GPIO_PIN", GPIO_PIN);
                sqlQuery.Parameters.AddWithValue("@location", null);
                sqlQuery.Parameters.AddWithValue("@RGB", RGB ? 1 : 0);
                sqlQuery.Prepare();
                var result = sqlQuery.ExecuteNonQuery() > 0;
                return result;
            }
            catch (Exception ex)
            {
                Logger.Logger.logError(Logger.Logger.Category.DATABASE, ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        ///     Adds sensor to device
        /// </summary>
        /// <param name="deviceid"></param>
        /// <param name="sensorname"></param>
        /// <param name="GPIO_PINS"></param>
        /// <param name="python"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        internal static bool AddSensorToDevice(int deviceid, string sensorname, byte[] GPIO_PINS, string python,
            string location = "")
        {
            try
            {
                var sqlQuery = new SQLiteCommand(webDBConnection);
                sqlQuery.CommandText =
                    "INSERT INTO sensors (DeviceID, Sensor, GPIO_PINS, LOCATION, PYTHON) VALUES (@deviceID, @sensorname, @GPIO_PINS, @location, @python);";
                sqlQuery.Parameters.AddWithValue("@deviceID", deviceid);
                var pinBuilder = new StringBuilder();
                for (var i = 0; i < GPIO_PINS.Length; i++)
                {
                    if (i + 1 == GPIO_PINS.Length)
                    {
                        pinBuilder.Append(GPIO_PINS[i].ToString());
                    }
                    else
                    {
                        pinBuilder.Append(GPIO_PINS[i] + ";");
                    }
                }

                sqlQuery.Parameters.AddWithValue("@deviceID", deviceid);
                sqlQuery.Parameters.AddWithValue("@sensorname", sensorname);
                sqlQuery.Parameters.AddWithValue("@GPIO_PINS", pinBuilder.ToString());
                sqlQuery.Parameters.AddWithValue("@location", location);
                sqlQuery.Parameters.AddWithValue("@python", python);
                sqlQuery.Prepare();
                var result = sqlQuery.ExecuteNonQuery() > 0;
                return result;
            }
            catch (Exception ex)
            {
                Logger.Logger.logError(Logger.Logger.Category.DATABASE, ex.Message, ex);
                return false;
            }
        }
        private static byte[] imageSwitch(string deviceType)
        {
            switch(deviceType)
            {
                case "Raspberry PI":
                    return Resources.raspi;
                case "Arduino":
                    return Resources.arduino;
                default:
                    return Resources.raspi;
            }
        }
        private static DeviceModel[] modelBuffer;
        private static DateTime lastModelQuery = DateTime.Now;
        private const int secondsToBuffer = 3;
        /// <summary>
        ///     Reads all devices from database
        /// </summary>
        /// <returns>Array of type DeviceModel</returns>
        internal static DeviceModel[] getDeviceModels()
        {
            if(modelBuffer != null && (DateTime.Now - lastModelQuery).TotalSeconds < secondsToBuffer)
            {
                return modelBuffer;
            }
            var query = "SELECT * FROM devices";
            var sqlQuery = new SQLiteCommand(query, webDBConnection);
            var resultReader = sqlQuery.ExecuteReader();
            var models = new List<DeviceModel>();
            while (resultReader.Read())
            {
                try
                {
                    var model = new DeviceModel(resultReader.GetString(4), resultReader.GetInt32(5))
                    {
                        image = imageSwitch(resultReader.GetString(1)),
                        name = resultReader.GetString(0),
                        location = resultReader.GetString(3),
                        type = resultReader.GetString(1),
                        description = resultReader.GetString(2),
                        deviceID = resultReader.GetInt32(6)
                    };
                    var functionQuery = new SQLiteCommand(webDBConnection);
                    functionQuery.CommandText =
                        @"SELECT * FROM deviceFunctions WHERE deviceFunctions.DeviceID = @DeviceID";
                    functionQuery.Parameters.AddWithValue("@DeviceID", model.deviceID);
                    functionQuery.Prepare();
                    var functionReader = functionQuery.ExecuteReader();
                    while (functionReader.Read())
                    {
                        model.addDeviceModelFunction(functionReader.GetInt32(1), (byte)functionReader.GetInt32(3),
                            functionReader.IsDBNull(2) ? null : functionReader.GetString(2),
                            functionReader.IsDBNull(4) ? null : functionReader.GetString(4),
                            functionReader.GetInt32(5) == 1);
                    }

                    var sensorQuery = new SQLiteCommand(webDBConnection);
                    sensorQuery.CommandText = @"SELECT * FROM Sensors WHERE Sensors.DeviceID = @DeviceID";
                    sensorQuery.Parameters.AddWithValue("@DeviceID", model.deviceID);
                    sensorQuery.Prepare();
                    var sensorReader = sensorQuery.ExecuteReader();
                    while (sensorReader.Read())
                    {
                        var modelSensors = new List<byte>();
                        try
                        {
                            var sensorValues = sensorReader.GetString(3);
                            sensorValues = sensorValues.Trim();
                            if (!string.IsNullOrEmpty(sensorValues))
                            {
                                var byteSensorValues = sensorValues.Split(';');
                                foreach (var byteString in byteSensorValues)
                                {
                                    modelSensors.Add(byte.Parse(byteString));
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            if (Logger.Logger.VERBOSE_LOG)
                            {
                                Logger.Logger.logError(Logger.Logger.Category.DATABASE, e.Message, e);
                            }
                        }

                        model.addDeviceSensors(sensorReader.GetInt32(1), modelSensors.ToArray(),
                            sensorReader.GetString(5), sensorReader.GetString(2), sensorReader.GetString(4));
                    }

                    models.Add(model);
                }
                catch (Exception ex)
                {
                    Logger.Logger.logError(Logger.Logger.Category.DATABASE, ex.Message, ex);
                }
            }
            modelBuffer = models.ToArray();
            return modelBuffer;
        }
    }
}