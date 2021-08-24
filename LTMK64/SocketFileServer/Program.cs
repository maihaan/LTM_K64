using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketFileServer
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

            while (true)
            {
                // Neu co ket noi den thi chap nhan ket noi
                Socket skXL = sk.Accept();

                // Nhan du lieu
                List<byte> dt = new List<byte>();
                Byte[] duLieu = new byte[1024];                
                
                int demNhan = skXL.Receive(duLieu);
                for (int i = 0; i < demNhan; i++)
                    dt.Add(duLieu[i]);
                try
                {
                    while (skXL.Available > 0)
                    {
                        // Nhan tiep du lieu
                        demNhan = skXL.Receive(duLieu);
                        if (demNhan > 0)
                            for (int i = 0; i < demNhan; i++)
                                dt.Add(duLieu[i]);
                    }
                }
                catch { }

                // Xu ly du lieu nhan duoc
                int chieuDaiHeader = dt[0];
                if(chieuDaiHeader == 5)
                {
                    // Du lieu nhan duoc la tin nhan van ban
                    byte[] noiDungTinNhan = new byte[dt.Count - 6];
                    for (int i = 0; i < noiDungTinNhan.Length; i++)
                        noiDungTinNhan[i] = dt[i + 6];
                    // Hien thi tin nhan nhan duoc
                    String tinNhan = Encoding.UTF8.GetString(noiDungTinNhan);
                    Console.WriteLine("Da nhan: " + tinNhan);
                    // Phan hoi lai client
                    skXL.Send(Encoding.UTF8.GetBytes("Da nhan tin nhan"));
                }   
                else
                {
                    byte[] bHeader = new byte[chieuDaiHeader - 6];
                    for (int i = 7; i <= chieuDaiHeader; i++)
                        bHeader[i - 7] = dt[i];
                    String tenTep = Encoding.UTF8.GetString(bHeader);
                    String root = "D:\\DLNhanServer";
                    String duongDan = root + "\\" + tenTep;
                    byte[] noiDungTep = new byte[dt.Count - chieuDaiHeader - 1];
                    for (int i = chieuDaiHeader + 1; i < dt.Count; i++)
                        noiDungTep[i - chieuDaiHeader - 1] = dt[i];
                    // Ghi noi dung tep 
                    File.WriteAllBytes(duongDan, noiDungTep);

                    // Hien thi len giao dien
                    Console.WriteLine("Da nhan tep: " + tenTep);

                    // Tra loi cho client
                    byte[] traLoi = Encoding.UTF8.GetBytes("Đã nhận tệp: " + tenTep);
                    skXL.Send(traLoi);
                }

                // Dong ket noi
                skXL.Close();
                skXL.Dispose();
            }
        }
    }
}
