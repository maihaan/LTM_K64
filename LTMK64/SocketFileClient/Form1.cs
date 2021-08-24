using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SocketFileClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pbTep_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Multiselect = false;
            if(od.ShowDialog() == DialogResult.OK)
            {
                lblDuongDan.Text = od.FileName;
            }    
        }

        private void btGui_Click(object sender, EventArgs e)
        {
            // Kiem tra du lieu truoc khi gui
            if (String.IsNullOrEmpty(tbTinNhan.Text.Trim()) || lblDuongDan.Text.Length < 5)
            {
                MessageBox.Show("Bạn phải nhập nội dung tin nhắn hoặc chọn tệp tin cần gửi!");
                return;
            }

            // Gui du lieu
            String serverIP = "127.0.0.1";
            int port = 12000;

            System.Net.Sockets.Socket sk = new System.Net.Sockets.Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Cấu trúc dữ liệu client gửi đến server: chiều dài header - header - nội dung
            // byte đầu tiên, chỉ độ dài phần header là một số dạng byte 0-255
            // header: [FILE] + tên file hoặc [MSG]
            // nội dung: nội dung tin nhắn hoặc nội dung file

            try
            {
                // Gui tin nhan neu co noi dung tin nhan -----------------------------------
                // Ket noi den may chu
                sk.Connect(IPAddress.Parse(serverIP), port);
                if (tbTinNhan.Text.Length > 0)
                {
                    byte[] duLieu = Encoding.UTF8.GetBytes("[MSG]" + tbTinNhan.Text);

                    byte[] dt = new byte[duLieu.Length + 1];
                    dt[0] = 5;
                    for (int i = 0; i < duLieu.Length; i++)
                        dt[i + 1] = duLieu[i];
                    // Gui du lieu
                    int dem = sk.Send(dt);

                    // Nhan tra loi va hien thi
                    byte[] ketQua = new byte[1024];
                    int demNhan = sk.Receive(ketQua);
                    tbLichSu.Text += "Bạn (" + DateTime.Now.ToString("HH:mm dd-MM-yyyy") + "): " + tbTinNhan.Text;
                    tbLichSu.Text += "(" + Encoding.UTF8.GetString(ketQua, 0, demNhan) + ")\r\n";
                    tbTinNhan.Text = "";
                    tbTinNhan.Focus();
                }
                // Dong ket noi
                sk.Close();
                sk.Dispose();


                // Gui file neu co file ------------------------------------
                // Ket noi den may chu
                sk = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sk.Connect(IPAddress.Parse(serverIP), port);
                if (lblDuongDan.Text.Length > 5)
                {
                    // Chuan bi du lieu de gui
                    String tenTep = Path.GetFileName(lblDuongDan.Text);
                    tenTep = tenTep.Replace(" ", "_");
                    String header = "[FILE]" + tenTep;
                    byte[] bHeader = Encoding.UTF8.GetBytes(header);
                    byte[] noiDungTep = File.ReadAllBytes(lblDuongDan.Text);
                    byte[] dt = new byte[1 + bHeader.Length + noiDungTep.Length];
                    dt[0] = (byte)bHeader.Length;
                    // Ghep header vào mang byte gui di
                    for(int i = 0; i < bHeader.Length; i++)
                    {
                        dt[i + 1] = bHeader[i];
                    }    
                    // Ghep noi dung tep vao mang byte gui di
                    for(int i = 0; i < noiDungTep.Length; i++)
                    {
                        dt[i + 1 + bHeader.Length] = noiDungTep[i];
                    }
                    // gui du lieu di
                    int dem = sk.Send(dt);

                    // Nhan tra loi va hien thi
                    byte[] ketQua = new byte[1024];
                    int demNhan = sk.Receive(ketQua);
                    tbLichSu.Text += "Bạn (" + DateTime.Now.ToString("HH:mm dd-MM-yyyy") + "): " + tbTinNhan.Text;
                    tbLichSu.Text += "(" + Encoding.UTF8.GetString(ketQua, 0, demNhan) + ")\r\n";
                    tbTinNhan.Text = "";
                    tbTinNhan.Focus();
                }
                // Dong ket noi
                sk.Close();
                sk.Dispose();
            }
            catch
            {
                MessageBox.Show("Không kết nối được đến máy chủ!");
                return;
            }
        }
    }
}
