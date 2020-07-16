using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SmartHomeProject.Connections
{
    public class Connections
    {
        string _ip;
        int _port;
        
        public Connections(string ip, int port){
            
            this._port = port;
            this._ip = ip;
          

        }

       

        public bool SendMessage(string operation, byte pin){
            
            TcpClient client = new TcpClient(this._ip,this._port);

            string message = operation + ":" + pin;

            int byteCount = Encoding.ASCII.GetByteCount(message);

            byte[] sendDater = new byte[byteCount];

            sendDater = Encoding.ASCII.GetBytes(message);

            NetworkStream stream = client.GetStream();

            stream.Write(sendDater,0,sendDater.Length);
            
            stream.Close();    
            client.Close();

            TcpListener listener = new TcpListener(IPAddress.Any, 334);
            listener.Start();
            TcpClient clientrecv = listener.AcceptTcpClient();
            NetworkStream streamrecv = client.GetStream();
            byte[] bytes = new byte[1024];
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            client.Close();
            return BitConverter.ToInt32(bytes) == 1;

        }

        public bool recvMessage() 
        {
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Any, 334);
                listener.Start();
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                byte[] bytes = new byte[1024];
                stream.Read(bytes, 0, bytes.Length);
                stream.Close();
                client.Close();
                return BitConverter.ToInt32(bytes) == 1;
            }

            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
           
        }

        



    }
}
