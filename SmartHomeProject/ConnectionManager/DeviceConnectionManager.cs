using System;
using System.Net.Sockets;
using System.Text;

namespace SmartHomeProject.Connections
{
    public class DeviceConnectionManager
    {
        private string _ip;
        private int _port;

        public DeviceConnectionManager(string ip, int port)
        {
            _port = port;
            _ip = ip;
        }

        public void SendMessage(string message)
        {
            Console.WriteLine("Try to send Message");
            TcpClient client = new TcpClient(_ip, _port);
            int byteCount = Encoding.ASCII.GetByteCount(message);
            byte[] sendDater = new byte[byteCount];
            sendDater = Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(sendDater, 0, sendDater.Length);
            stream.Close();
            client.Close();
        }
    }
}
