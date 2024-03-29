﻿using SmartHomeProject.Connections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeProject.Models
{
    public class DeviceModel
    {
        /// <summary>
        ///     Timeout for ping
        /// </summary>
        private const int TIMEOUTMILSECONDS = 25;

        /// <summary>
        ///     Creates a new device model with deviceconnectionamanger (ip, port)
        /// </summary>
        public DeviceModel()
        {
            DeviceConnectionManager = new DeviceConnectionManager(ip, port);
        }

        /// <summary>
        ///     Creates a new device model with deviceconnectionamanger (ip, port)
        /// </summary>
        /// <param name="ip">IP</param>
        /// <param name="port">Port</param>
        public DeviceModel(string ip, int port)
        {
            DeviceConnectionManager = new DeviceConnectionManager(ip, port);
            this.ip = ip;
            this.port = port;
        }

        /// <summary>
        ///     Name of the device
        /// </summary>
        public string name { get; set; }

        /// <summary>
        ///     Unique device ID
        /// </summary>
        public int deviceID { get; set; }

        /// <summary>
        ///     Description of the device
        /// </summary>
        public string description { get; set; }

        /// <summary>
        ///     Type of the device e.g. rapsberry, arduino etc.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        ///     Location of the device
        /// </summary>
        public string location { get; set; }

        /// <summary>
        ///     Device port for connections
        /// </summary>
        public int port { get; set; }

        /// <summary>
        ///     Device ip for connections
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        ///     Image for the device model
        /// </summary>
        public byte[] image { get; set; }

        /// <summary>
        ///     Manages connection to a device
        /// </summary>
        public DeviceConnectionManager DeviceConnectionManager { get; }

        /// <summary>
        ///     List of all functions the device has
        /// </summary>
        public List<DeviceModelFunction> DeviceFunctions { get; set; }

        /// <summary>
        ///     List of all sensors the device has
        /// </summary>
        public List<Sensor> Sensors { get; set; }

        /// <summary>
        ///     Checks if device is online with a ping request
        /// </summary>
        public bool OnlineStatus
        {
            get
            {
                try
                {
                    var p = new Ping();
                    if (Logger.Logger.VERBOSE_LOG)
                    {
                        Logger.Logger.logInfo(Logger.Logger.Category.NETWORK, "Sending ping to IP " + ip);
                    }

                    var reply = p.Send(ip, TIMEOUTMILSECONDS);
                    if (reply.Status == IPStatus.Success)
                    {
                        return true;
                    }

                    return false;
                }
                catch (PingException ex)
                {
                    if (Logger.Logger.VERBOSE_LOG)
                    {
                        Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
                    }

                    Logger.Logger.logInfo(Logger.Logger.Category.NETWORK,
                        "Device with IP " + ip + " *probably* not reachable");

                    return false;
                }
                catch (Exception ex)
                {
                    Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
                    return false;
                }
            }
        }


        /// <summary>
        ///     Adds a new sensor to the sensor list for this device
        /// </summary>
        /// <param name="sensorID">Unique sensor ID</param>
        /// <param name="GPIO_PINS">Pins used for this sensor</param>
        /// <param name="python">python script executed for data processing</param>
        /// <param name="sensorname">Name of the sensor</param>
        /// <param name="location">location of the sensor</param>
        public void addDeviceSensors(int sensorID, byte[] GPIO_PINS, string python, string sensorname, string location)
        {
            if (Sensors == null)
            {
                Sensors = new List<Sensor>();
            }

            Sensors.Add(new Sensor(sensorID, GPIO_PINS, python, sensorname, location, DeviceConnectionManager,
                OnlineStatus));
        }

        /// <summary>
        ///     Adds a new function to a device
        /// </summary>
        /// <param name="functionID">unqiue function id</param>
        /// <param name="GPIO_PIN">GPIO Pin</param>
        /// <param name="functionname">functionname</param>
        /// <param name="location">location</param>
        /// <param name="RGB">is function a dimming function?</param>
        public void addDeviceModelFunction(int functionID, byte GPIO_PIN, string functionname, string location,
            bool RGB)
        {
            if (DeviceFunctions == null)
            {
                DeviceFunctions = new List<DeviceModelFunction>();
            }

            DeviceFunctions.Add(new DeviceModelFunction(functionID, GPIO_PIN, functionname, location, RGB,
                DeviceConnectionManager, OnlineStatus));
        }

        /// <summary>
        ///     Class for handeling sensors
        /// </summary>
        public class Sensor
        {
            /// <summary>
            ///     Timeout for network communication
            /// </summary>
            private const double TIMEOUTMILSECONDS = 40;

            private readonly DeviceConnectionManager _deviceConnectionManager;

            public Sensor(int id, byte[] GPIO_PINS, string python, string sensorname, string location,
                DeviceConnectionManager deviceConnectionManager, bool deviceOnlineStauts)
            {
                this.GPIO_PINS = GPIO_PINS;
                this.sensorname = sensorname;
                this.location = location;
                _deviceConnectionManager = deviceConnectionManager;
                this.python = python;
                sensorID = id;
                if (deviceOnlineStauts)
                {
                    status = getStatus();
                }
                else
                {
                    status = "ERROR";
                }
            }

            public string sensorname { get; set; }
            public string python { get; set; }
            public int sensorID { get; set; }
            public string status { get; set; }
            public byte[] GPIO_PINS { get; }
            public string location { get; set; }
            public string pythonError { get; set; }

            public string getFullPythonExecution()
            {
                var pythonBuilder = new StringBuilder();
                var pythonReader = new StringReader(python);
                pythonBuilder.AppendLine("def sensorValue():");
                string codeLine;
                while ((codeLine = pythonReader.ReadLine()) != null)
                {
                    pythonBuilder.AppendLine("\t" + codeLine);
                }

                for (var i = 0; i < GPIO_PINS.Length; i++)
                {
                    pythonBuilder.Replace("PIN[" + i + "]", GPIO_PINS[i].ToString());
                }

                return pythonBuilder.ToString();
            }

            public string getStatus()
            {
                try
                {
                    var task = Task.Run(() => _deviceConnectionManager.recvSensor(getFullPythonExecution()));
                    if (task.Wait(TimeSpan.FromMilliseconds(TIMEOUTMILSECONDS)))
                    {
                        var result = task.Result;
                        var resultStrings = result.Split(':');
                        if (resultStrings[0] == "ERROR")
                        {
                            if (Logger.Logger.VERBOSE_LOG)
                            {
                                Logger.Logger.logError(Logger.Logger.Category.PYTHON, resultStrings[1], null);
                            }

                            pythonError = resultStrings[1];
                            return "ERROR";
                        }

                        return resultStrings[1];
                    }
                }
                catch (Exception e)
                {
                    if (Logger.Logger.VERBOSE_LOG)
                    {
                        Logger.Logger.logError(Logger.Logger.Category.NETWORK + ", " + Logger.Logger.Category.PYTHON,
                            e.Message, e);
                    }
                }

                return "ERROR";
            }
        }

        /// <summary>
        ///     Class for handeling functions
        /// </summary>
        public class DeviceModelFunction
        {
            /// <summary>
            ///     Timeout for network communication
            /// </summary>
            private const double TIMEOUTMILSECONDS = 30;

            private readonly DeviceConnectionManager _deviceConnectionManager;

            public DeviceModelFunction(int id, byte GPIO_PIN, string functionname, string location, bool RGB,
                DeviceConnectionManager deviceConnectionManager, bool deviceOnlineStauts)
            {
                this.GPIO_PIN = GPIO_PIN;
                this.functionname = functionname;
                this.location = location;
                _deviceConnectionManager = deviceConnectionManager;
                this.RGB = RGB;
                functionID = id;
                if (deviceOnlineStauts)
                {
                    status = getStatus();
                }
            }

            public int functionID { get; set; }
            public byte GPIO_PIN { get; }
            public string functionname { get; set; }
            public string location { get; set; }
            public bool status { get; set; }
            public bool RGB { get; set; }


            public bool getStatus()
            {
                try
                {
                    var task = Task.Run(() => _deviceConnectionManager.recvMessage("Status", GPIO_PIN));
                    if (task.Wait(TimeSpan.FromMilliseconds(TIMEOUTMILSECONDS)))
                    {
                        return task.Result;
                    }

                    if (Logger.Logger.VERBOSE_LOG)
                    {
                        Logger.Logger.logInfo(Logger.Logger.Category.NETWORK,
                            "Timeout for function status check for function " + functionname);
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    if (Logger.Logger.VERBOSE_LOG)
                    {
                        Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
                    }

                    return false;
                }
            }

            public bool executeFunction()
            {
                try
                {
                    var task = Task.Run(() => _deviceConnectionManager.recvMessage("Switch", GPIO_PIN));
                    if (task.Wait(TimeSpan.FromMilliseconds(TIMEOUTMILSECONDS)))
                    {
                        return task.Result;
                    }

                    Logger.Logger.logInfo(Logger.Logger.Category.NETWORK,
                        "Timeout for function execute for " + functionname);
                    return false;
                }
                catch (Exception ex)
                {
                    if (Logger.Logger.VERBOSE_LOG)
                    {
                        Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
                    }

                    return false;
                }
            }
            public bool changeRGB(double red, double green, double blue, double alpha)
            {
                if (!RGB)
                {
                    return false;
                }
                try
                {
                    var task = Task.Run(() => _deviceConnectionManager.recvColor(red, green, blue, alpha, GPIO_PIN));
                    if (task.Wait(TimeSpan.FromMilliseconds(TIMEOUTMILSECONDS)))
                    {
                        return task.Result;
                    }

                    Logger.Logger.logInfo(Logger.Logger.Category.NETWORK,
                        "Timeout for function execute for " + functionname);
                    return false;
                }
                catch (Exception ex)
                {
                    if (Logger.Logger.VERBOSE_LOG)
                    {
                        Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
                    }

                    return false;
                }
            }
        }
    }
}