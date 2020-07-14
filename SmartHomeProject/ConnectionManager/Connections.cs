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

       

        public void SendMessage(string operation, byte pin){
            
            TcpClient client = new TcpClient(this._ip,this._port);

            string message = operation + ":" + pin;

            int byteCount = Encoding.ASCII.GetByteCount(message);

            byte[] sendDater = new byte[byteCount];

            sendDater = Encoding.ASCII.GetBytes(message);

            NetworkStream stream = client.GetStream();

            stream.Write(sendDater,0,sendDater.Length);

            

            stream.Close();    
            client.Close();
        }

        



    }
}
