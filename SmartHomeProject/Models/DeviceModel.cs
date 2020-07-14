using SmartHomeProject.Connections;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Exception = System.Exception;

namespace SmartHomeProject.Models
{
    public class DeviceModel
    {
        public DeviceModel()
        {
            
        }
        public DeviceModel(string ip, int port)
        {
            
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
                    Console.WriteLine("Sending ping to: " + ip);
                    PingReply reply = p.Send(ip);
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
                    Console.WriteLine(ex.StackTrace);
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

    
        public List<DeviceModelFunction> DeviceFunctions { get; set; }

        public void addDeviceModelFunction(int functionID, byte GPIO_PIN, string functionname, string location)
        {
            if (DeviceFunctions == null)
            {
                DeviceFunctions = new List<DeviceModelFunction>();
            }

            DeviceFunctions.Add(new DeviceModelFunction(functionID, GPIO_PIN, functionname, location));
        }
        public class DeviceModelFunction
        {
            public int functionID { get; set; }
            public byte GPIO_PIN { get; private set; }
            public string functionname { get; set; }
            public string location { get; set; }
            public bool status { get; set; }
            

            public DeviceModelFunction(int id, byte GPIO_PIN, string functionname, string location)
            {
                this.GPIO_PIN = GPIO_PIN;
                this.functionname = functionname;
                this.location = location;

            }

            public bool getStatus(int pin) 
            {
                //Hier muss das aus Conections die sendmessage methode aufgerufen werden
                return false;

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
