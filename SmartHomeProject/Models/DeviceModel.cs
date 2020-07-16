using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Exception = System.Exception;

namespace SmartHomeProject.Models
{
    public class DeviceModel
    {
        private const int TIMEOUTMILSECONDS = 50;
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
        public string Name { get; set; }

        public byte[] Image
        {
            get; set;
        }
        public int deviceID { get; set; }
        public string description { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
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
                    Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
                    return false;
                }
                catch (Exception ex)
                {
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
        public class DeviceModelFunction
        {
            private const double TIMEOUTMILSECONDS = 100;
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
                        Logger.Logger.logInfo(Logger.Logger.Category.NETWORK, "Timeout for function status check for function " + functionname);
                        return false;
                    }

                   
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            public bool executeFunction()
            {
                try
                {
                    var task = System.Threading.Tasks.Task.Run(() => connection.recvMessage("Switch",  GPIO_PIN));
                    if (task.Wait(TimeSpan.FromMilliseconds(TIMEOUTMILSECONDS)))
                    {
                        return task.Result;
                    }
                    else
                    {
                        Logger.Logger.logInfo(Logger.Logger.Category.NETWORK, "Timeout for function status check for function " + functionname);
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    return false;
                }

                 

            }

        }
    }
}



/*
 * GeräteID,FunktionsName,PIN,Location
 * 
 * 
 * PI-Server --> Rasberry-PI { Empfängt message enthalten GPIO PIN und Status, oder Sensor auslesen und andworten} 
 * 
 * 
 * 
 * 
 */
