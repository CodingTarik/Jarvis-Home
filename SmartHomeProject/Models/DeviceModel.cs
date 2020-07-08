using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using SmartHomeProject.Connections;

namespace SmartHomeProject.Models
{
    public class DeviceModel
    {
        public DeviceModel()
        {
            connection = new DeviceConnectionManager(ip, port);
        }
        public DeviceModel(string ip, int port)
        {
            connection = new DeviceConnectionManager(ip, port);
            this.ip = ip;
            this.port = port;
        }
        public string Name { get; set; }

        public byte[] Image
        {
            get; set;
        }
        public string Type { get; set; }
        public string Location { get; set; }
        public int port { get; set; }
        public string ip {get; set; }
        public DeviceConnectionManager connection { get; private set; }
        public List<DeviceModelFunction> DeviceFunctions = new List<DeviceModelFunction>();

        public void addDeviceModelFunction(byte GPIO_PIN, string functionname, string location)
        {
            DeviceFunctions.Add(new DeviceModelFunction(GPIO_PIN, functionname, location, this.connection));
        }
        public class DeviceModelFunction
        {
            public byte GPIO_PIN { get; private set; }
            public string functionname { get; set; }
            public string location { get; set; }
            public bool status { get; set; }
            private DeviceConnectionManager connection;

            public DeviceModelFunction(byte GPIO_PIN, string functionname, string location, DeviceConnectionManager connection)
            {
                this.GPIO_PIN = GPIO_PIN;
                this.functionname = functionname;
                this.location = location;
                this.connection = connection;
                this.status = getStatus();

            }

            public bool getStatus()
            {
                TcpListener listener = new TcpListener(IPAddress.Any, 334);
                connection.SendMessage("Status:"+GPIO_PIN);
                listener.Start();
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                byte[] bytes = new byte[1024];
                stream.Read(bytes, 0, bytes.Length);
                stream.Close();
                client.Close();
                return BitConverter.ToInt32(bytes) == 1;
            }

            public void executeFunction()
            {
                connection.SendMessage("Switch:"+GPIO_PIN);
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