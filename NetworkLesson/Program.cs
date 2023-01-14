using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkLesson
{
    internal class Program
    {
        #region Socket, IP Adress
        static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            var ipAdress = IPAddress.Parse("104.21.70.39"); // google IP adress

            var port = 80;

            IPEndPoint endpoint = new IPEndPoint(ipAdress, port);

            try
            {
                // qosulmaq ucun
                socket.Connect(endpoint);
                if (socket.Connected)
                {
                    string str = $@"GET / HTTP / 1.1\r\nHost {ipAdress} \r\nConnection:
                                    Close\r\n\r\n";

                    var bytes = Encoding.ASCII.GetBytes(str);

                    socket.Send(bytes);

                    var length = 0;
                    var buffer = new byte[1500];
                    do
                    {
                        // aximin icinde olan datani buffere yazir
                        length = socket.Receive(buffer);
                        var response = Encoding.ASCII.GetString(buffer);
                        Console.WriteLine(response);
                    } while (length > 0);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
