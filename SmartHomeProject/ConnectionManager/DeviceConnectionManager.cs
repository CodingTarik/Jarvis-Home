using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace SmartHomeProject.Connections
{
    public class DeviceConnectionManager
    {
        private readonly string _ip;
        private readonly int _port;

        public DeviceConnectionManager(string ip, int port)
        {
            _port = port;
            _ip = ip;
        }

        public void SendSensor(string method, int port)
        {
            try
            {
                var client = new TcpClient(_ip, _port);

                var message = "Sensor" + ":" + port + ":" + method;

                var byteCount = Encoding.ASCII.GetByteCount(message);

                var sendDater = new byte[byteCount];

                sendDater = Encoding.ASCII.GetBytes(message);

                var stream = client.GetStream();

                stream.Write(sendDater, 0, sendDater.Length);

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                if (Logger.Logger.VERBOSE_LOG) Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
            }
        }

        public void SendPin(string operation, byte pin, int port)
        {
            try
            {
                var client = new TcpClient(_ip, _port);

                var message = operation + ":" + pin + ":" + port;

                var byteCount = Encoding.ASCII.GetByteCount(message);

                var sendDater = new byte[byteCount];

                sendDater = Encoding.ASCII.GetBytes(message);

                var stream = client.GetStream();

                stream.Write(sendDater, 0, sendDater.Length);

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                if (Logger.Logger.VERBOSE_LOG) Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
            }
        }
        public void SendColor(string color, string colortype, byte pin, int port)
        {
            try
            {
                var client = new TcpClient(_ip, _port);
                if (colortype == "rgb(")
                {
                    colortype = "rgb";
                }
                var message = "SetColor" + ":" + colortype + ":" + color + ":" + pin + ":" + port;

                var byteCount = Encoding.ASCII.GetByteCount(message);

                var sendDater = new byte[byteCount];

                sendDater = Encoding.ASCII.GetBytes(message);

                var stream = client.GetStream();

                stream.Write(sendDater, 0, sendDater.Length);

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                if (Logger.Logger.VERBOSE_LOG) Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
            }
        }
        public bool recvMessage(string operation, byte pin)
        {
            try
            {
                var port = 456;
                var isAvailable = false;
                var rand = new Random();
                var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                var tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
                while (isAvailable == false)
                {
                    port = rand.Next(1024, 65535);

                    foreach (var tcpi in tcpConnInfoArray)
                        if (tcpi.LocalEndPoint.Port == port)
                        {
                            isAvailable = false;
                            return false;
                        }
                        else
                        {
                            var ascii = new ASCIIEncoding();
                            var listener = new TcpListener(IPAddress.Any, port);
                            listener.Start();
                            SendPin(operation, pin, port);
                            var client = listener.AcceptTcpClient();
                            var stream = client.GetStream();
                            var bytes = new byte[1024];
                            stream.Read(bytes, 0, bytes.Length);
                            stream.Close();
                            client.Close();
                            return BitConverter.ToInt32(bytes) == 49;
                        }
                }

                return false;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public string recvSensor(string method)
        {
            try
            {
                var port = 456;
                var isAvailable = false;
                var rand = new Random();
                var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                var tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
                while (isAvailable == false)
                {
                    port = rand.Next(1024, 65535);

                    foreach (var tcpi in tcpConnInfoArray)
                        if (tcpi.LocalEndPoint.Port == port)
                        {
                            isAvailable = false;
                            return null;
                        }
                        else
                        {
                            var ascii = new ASCIIEncoding();
                            var listener = new TcpListener(IPAddress.Any, port);
                            listener.Start();
                            SendSensor(method, port);
                            var client = listener.AcceptTcpClient();
                            var stream = client.GetStream();
                            var bytes = new byte[1024];
                            stream.Read(bytes, 0, bytes.Length);
                            stream.Close();
                            client.Close();
                            return Encoding.ASCII.GetString(bytes);
                        }
                }

                return null;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public string recvColor(string color, byte pin)
        {
            try
            {
                var port = 456;
                var isAvailable = false;
                var rand = new Random();
                var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                var tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
                while (isAvailable == false)
                {
                    port = rand.Next(1024, 65535);

                    foreach (var tcpi in tcpConnInfoArray)
                        if (tcpi.LocalEndPoint.Port == port)
                        {
                            isAvailable = false;
                            return null;
                        }
                        else
                        {
                            var ascii = new ASCIIEncoding();
                            var listener = new TcpListener(IPAddress.Any, port);
                            listener.Start();
                            string colorType = color.Substring(0, 4);
                            SendColor(color, colorType, pin, port);
                            var client = listener.AcceptTcpClient();
                            var stream = client.GetStream();
                            var bytes = new byte[1024];
                            stream.Read(bytes, 0, bytes.Length);
                            stream.Close();
                            client.Close();
                            return Encoding.ASCII.GetString(bytes);
                        }
                }

                return null;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}