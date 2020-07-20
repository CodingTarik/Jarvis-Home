using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using Exception = System.Exception;

namespace SmartHomeProject.Models
{
    public class DeviceModel
    {
        private const int TIMEOUTMILSECONDS = 20;
        public DeviceModel()
        {
            connection = new Connections.Connections(ip, port);
        }
        public DeviceModel(string ip, int port)
        {
            connection = new Connections.Connections(ip, port);
            this.ip = ip;
            this.port = port;
        }
        public string name { get; set; }

        public byte[] image
        {
            get; set;
        }
        public int deviceID { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string location { get; set; }
        public int port { get; set; }
        public string ip { get; set; }



        public bool OnlineStatus
        {
            get
            {
                try
                {
                    Ping p = new Ping();
                    if (Logger.Logger.VERBOSE_LOG)
                    {
                        Logger.Logger.logInfo(Logger.Logger.Category.NETWORK, "Sending ping to IP " + ip);
                    }

                    PingReply reply = p.Send(ip, TIMEOUTMILSECONDS);
                    if (reply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
                catch (PingException ex)
                {
                    if (Logger.Logger.VERBOSE_LOG)
                    {
                        Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
                    }
                    Logger.Logger.logInfo(Logger.Logger.Category.NETWORK, "Device with IP " + ip + " *probably* not reachable");

                    return false;
                }
                catch (Exception ex)
                {
                    Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
                    return false;
                }

            }
        }

        public Connections.Connections connection { get; private set; }
        public List<DeviceModelFunction> DeviceFunctions { get; set; }

        public void addDeviceModelFunction(int functionID, byte GPIO_PIN, string functionname, string location)
        {
            if (DeviceFunctions == null)
            {
                DeviceFunctions = new List<DeviceModelFunction>();
            }

            DeviceFunctions.Add(new DeviceModelFunction(functionID, GPIO_PIN, functionname, location, connection));
        }

        public class Sensor
        {
            public string sensorname { get; set; }
            public string python { get; set; }
            public int sensorID { get; set; }
            public string status { get; set; }
            public byte[] GPIO_PINS { get; private set; }
            public string location { get; set; }
            public string pythonError { get; set; }
            private Connections.Connections connection;

            public Sensor(int id, byte[] GPIO_PINS, string python, string sensorname, string location, Connections.Connections connection)
            {
                this.GPIO_PINS = GPIO_PINS;
                this.sensorname = sensorname;
                this.location = location;
                this.connection = connection;
                sensorID = id;
                status = getStatus();
            }

            public string getFullPythonExecution()
            {
                StringBuilder pythonBuilder = new StringBuilder();
                StringReader pythonReader = new StringReader(python);
                pythonBuilder.AppendLine("def sensorValue():");
                string codeLine;
                while ((codeLine = pythonReader.ReadLine()) != null)
                {
                    pythonBuilder.AppendLine("\t" + codeLine);
                }

                for (int i = 0; i < GPIO_PINS.Length; i++)
                {
                    pythonBuilder.Replace("PIN[" + i + "]", GPIO_PINS[i].ToString());
                }

                return pythonBuilder.ToString();

            }
            public string getStatus()
            {
                try
                {
                    var task = System.Threading.Tasks.Task.Run(() => connection.recvSensor(getFullPythonExecution()));
                    if (task.Wait(TimeSpan.FromMilliseconds(TIMEOUTMILSECONDS+30)))
                    {
                        string result = task.Result;
                        string[] resultStrings = result.Split(':');
                        if (resultStrings[0] == "error")
                        {
                            if (Logger.Logger.VERBOSE_LOG)
                            {
                                Logger.Logger.logError(Logger.Logger.Category.PYTHON, resultStrings[1], null);
                            }

                            return "ERROR:" + resultStrings[1];
                        }
                        else
                        {
                            return resultStrings[1];
                        }
                    }
                }
                catch (Exception e)
                {
                    if (Logger.Logger.VERBOSE_LOG)
                    {
                        Logger.Logger.logError(Logger.Logger.Category.NETWORK + ", " + Logger.Logger.Category.PYTHON, e.Message, e);
                        
                    }
                }

                return "ERROR";

            }



        }
        public class DeviceModelFunction
        {
            private const double TIMEOUTMILSECONDS = 50;
            public int functionID { get; set; }
            public byte GPIO_PIN { get; private set; }
            public string functionname { get; set; }
            public string location { get; set; }
            public bool status { get; set; }
            private Connections.Connections connection;

            public DeviceModelFunction(int id, byte GPIO_PIN, string functionname, string location, Connections.Connections connection)
            {
                this.GPIO_PIN = GPIO_PIN;
                this.functionname = functionname;
                this.location = location;
                this.connection = connection;
                functionID = id;
                status = getStatus();
            }


            public bool getStatus()
            {
                try
                {
                    var task = System.Threading.Tasks.Task.Run(() => connection.recvMessage("Status", GPIO_PIN));
                    if (task.Wait(TimeSpan.FromMilliseconds(TIMEOUTMILSECONDS)))
                    {

                        return task.Result;
                    }
                    else
                    {
                        if (Logger.Logger.VERBOSE_LOG)
                        {
                            Logger.Logger.logInfo(Logger.Logger.Category.NETWORK, "Timeout for function status check for function " + functionname);
                        }

                        return false;
                    }


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
                    var task = System.Threading.Tasks.Task.Run(() => connection.recvMessage("Switch", GPIO_PIN));
                    if (task.Wait(TimeSpan.FromMilliseconds(TIMEOUTMILSECONDS)))
                    {
                        return task.Result;
                    }
                    else
                    {
                        Logger.Logger.logInfo(Logger.Logger.Category.NETWORK, "Timeout for function execute for " + functionname);
                        return false;
                    }
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
