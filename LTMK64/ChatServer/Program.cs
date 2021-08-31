﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatServer
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
                Byte[] duLieu = new byte[10240];
                int demNhan = skXL.Receive(duLieu);

                // Boc tach du lieu nhan duoc theo quy tac: NguoiGui ~ NguoiNhan ~ TinNhan
                String noiDung = Encoding.UTF8.GetString(duLieu, 0, demNhan);
                if (noiDung.StartsWith("[?]"))
                {
                    // Hoi thong tin moi theo cu phap: [?] ~ NguoiNhan
                    String nguoiNhan = noiDung.Split('~')[1];

                    // Truy van du lieu trong CSDL xem co tin nhan nao moi gui den cho nguoi nhan hay khong
                    DataAccess da = new DataAccess();
                    String truyVan = "Select * From tbTinNhan Where NguoiNhan=N'" + nguoiNhan + "' And TrangThai=N'Đã gửi'";
                    DataTable tb = da.Doc(truyVan);
                    String traLoi = "";
                    if(tb != null && tb.Rows.Count > 0)
                    {
                        // Co tin nhan tra loi theo cau truc: NguoiGui ~ TinNhan ~ ThoiGian ^ NguoiGui ~ TinNhan ...
                        foreach(DataRow r in tb.Rows)
                        {
                            traLoi += r["NguoiGui"].ToString() + "~" + r["TinNhan"].ToString() + "~" + r["ThoiGian"].ToString() + "^";
                        }
                        traLoi = traLoi.Substring(0, traLoi.Length - 1);
                    }   
                    else
                    {
                        // Khong co tin nhan
                        traLoi = "[NULL]";
                    }
                    
                    // Gui tra loi cho client
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));

                    // Cap nhat trang thai cho cac tin nhan la "Đã nhận"
                    foreach(DataRow r in tb.Rows)
                    {
                        String truyVanCN = "Update tbTinNhan Set TrangThai=N'Đã nhận' Where ID=" + r["ID"].ToString();
                        da.Ghi(truyVanCN);
                    }    
                }
                else
                {
                    // Nhan tin binh thuong
                    String nguoiGui = noiDung.Split('~')[0];
                    String nguoiNhan = noiDung.Split('~')[1];
                    String tinNhan = noiDung.Split('~')[2];

                    // Luu tru vao CSDL
                    Console.WriteLine("Da nhan: " + noiDung);
                    DataAccess da = new DataAccess();
                    String truyVan = "Insert Into tbTinNhan(NguoiGui, NguoiNhan, TinNhan, ThoiGian) Values(N'"
                        + nguoiGui + "', N'"
                        + nguoiNhan + "', N'"
                        + tinNhan + "', N'"
                        + DateTime.Now.ToString() + "')";
                    da.Ghi(truyVan);

                    // Tra loi cho client
                    byte[] traLoi = Encoding.UTF8.GetBytes("Đã nhận");
                    skXL.Send(traLoi);
                }

                // Dong ket noi
                skXL.Close();
                skXL.Dispose();
            }
        }
    }
}
