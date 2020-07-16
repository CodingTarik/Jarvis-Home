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



        public void SendMessage(string operation, byte pin, int port)
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

        public bool recvMessage(string operation, byte pin)
        {


            try
            {
                int port = 456; 
                bool isAvailable = true;
                var rand = new Random();

                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
                do
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
                            TcpListener listener = new TcpListener(IPAddress.Any, port);
                            SendMessage(operation, pin, port);
                            Console.WriteLine("Versuche zu starten");
                            listener.Start();
                            TcpClient client = listener.AcceptTcpClient();
                            NetworkStream stream = client.GetStream();
                            byte[] bytes = new byte[1024];
                            stream.Read(bytes, 0, bytes.Length);
                            Console.WriteLine("Habe gestartet");
                            stream.Close();
                            client.Close();
                            Console.WriteLine(BitConverter.ToInt32(bytes));
                            return BitConverter.ToInt32(bytes) == 1;

                        }
                    }
                } while (isAvailable == false);
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
