using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.NetworkInformation;

namespace SmartHomeProject.Connections
{
    public class Connections
    {
        string _ip;
        int _port;

        public Connections(string ip, int port)
        {

            this._port = port;
            this._ip = ip;


        }



        public void SendMessage(string operation, string pin, int port)
        {
            try
            {
                TcpClient client = new TcpClient(this._ip, this._port);

                string message = operation + ":" + pin + ":" + port;

                int byteCount = Encoding.ASCII.GetByteCount(message);

                byte[] sendDater = new byte[byteCount];

                sendDater = Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(sendDater, 0, sendDater.Length);

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                if (Logger.Logger.VERBOSE_LOG)
                {
                    Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
                }
            }



        }
        public void SendPin(string operation, byte pin, int port)
        {
            try
            {
                TcpClient client = new TcpClient(this._ip, this._port);

                string message = operation + ":" + pin + ":" + port;

                int byteCount = Encoding.ASCII.GetByteCount(message);

                byte[] sendDater = new byte[byteCount];

                sendDater = Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(sendDater, 0, sendDater.Length);

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                if (Logger.Logger.VERBOSE_LOG)
                {
                    Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
                }
            }



        }

        public bool recvMessage(string operation, byte pin)
        {


            try
            {
                int port = 456;
                bool isAvailable = false;
                var rand = new Random();
                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
                while (isAvailable == false)
                {
                    port = rand.Next(1024, 65535);

                    foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
                    {
                        if (tcpi.LocalEndPoint.Port == port)
                        {
                            isAvailable = false;
                            return false;
                        }
                        else
                        {
                            ASCIIEncoding ascii = new ASCIIEncoding();
                            TcpListener listener = new TcpListener(IPAddress.Any, port);
                            SendPin(operation, pin, port);
                            listener.Start();
                            TcpClient client = listener.AcceptTcpClient();
                            NetworkStream stream = client.GetStream();
                            byte[] bytes = new byte[1024];
                            stream.Read(bytes, 0, bytes.Length);
                            stream.Close();
                            client.Close();
                            return BitConverter.ToInt32(bytes) == 49;

                        }
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

        public bool recvSensor(string operation, string method)
        {


            try
            {
                int port = 456;
                bool isAvailable = false;
                var rand = new Random();
                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
                while (isAvailable == false)
                {
                    port = rand.Next(1024, 65535);

                    foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
                    {
                        if (tcpi.LocalEndPoint.Port == port)
                        {
                            isAvailable = false;
                            return false;
                        }
                        else
                        {
                            ASCIIEncoding ascii = new ASCIIEncoding();
                            TcpListener listener = new TcpListener(IPAddress.Any, port);
                            SendMessage(operation, method, port);
                            listener.Start();
                            TcpClient client = listener.AcceptTcpClient();
                            NetworkStream stream = client.GetStream();
                            byte[] bytes = new byte[1024];
                            stream.Read(bytes, 0, bytes.Length);
                            stream.Close();
                            client.Close();
                            return BitConverter.ToInt32(bytes) == 49;

                        }
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



    }
}
