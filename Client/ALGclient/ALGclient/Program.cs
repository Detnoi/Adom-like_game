using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ALGclient
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] remdata = new byte[1024];
            TcpClient Client = new TcpClient();
            Socket Sock;
            Client.Connect("localhost", 8020);
            Sock = Client.Client;
            Sock.Send(Encoding.ASCII.GetBytes("test\r\n\r\n"));
            Console.ReadLine();
            Sock.Disconnect(true);
        }
    }
}
