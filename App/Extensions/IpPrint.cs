using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace App.Extensions
{
    public class IpPrint
    {

        public void PrinttoIP(String PrinterIP,String filename)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.NoDelay = true;

            IPAddress ip = IPAddress.Parse(PrinterIP);
            IPEndPoint ipep = new IPEndPoint(ip, 9100);
            clientSocket.Connect(ipep);

            byte[] fileBytes = File.ReadAllBytes(filename);

            clientSocket.Send(fileBytes);
            clientSocket.Close();

            
        }
    }
}
