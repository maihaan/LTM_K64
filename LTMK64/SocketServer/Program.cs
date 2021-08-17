using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("May chu bat dau hoat dong ...");

            String serverIP = "127.0.0.1";
            int port = 12000;

            // Khoi tao socket de lang nghe
            Socket sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(serverIP), port);
            sk.Bind(ep);
            sk.Listen(100);

            while(true)
            {
                // Neu co ket noi den thi chap nhan ket noi
                Socket skXL = sk.Accept();

                // Nhan du lieu
                Byte[] duLieu = new byte[1024];
                int demNhan = skXL.Receive(duLieu);

                // Chuyen du lieu nhan duoc ve dang van ban
                String noiDung = Encoding.UTF8.GetString(duLieu, 0, demNhan);

                // Hien thi len giao dien
                Console.WriteLine("Da nhan: " + noiDung);

                // Tra loi cho client
                byte[] traLoi = Encoding.UTF8.GetBytes("Đã nhận");
                skXL.Send(traLoi);

                // Dong ket noi
                skXL.Close();
                skXL.Dispose();
            }    
        }
    }
}
