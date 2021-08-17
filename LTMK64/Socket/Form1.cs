using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btGui_Click(object sender, EventArgs e)
        {
            // Kiem tra du lieu truoc khi gui
            if(String.IsNullOrEmpty(tbTinNhan.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập nội dung tin nhắn!");
                return;
            }

            // Gui du lieu
            String serverIP = "127.0.0.1";
            int port = 12000;

            System.Net.Sockets.Socket sk = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, 
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Ket noi den may chu
                sk.Connect(IPAddress.Parse(serverIP), port);

                // Chuyen du lieu can gui sang dang mang byte
                byte[] duLieu = Encoding.UTF8.GetBytes(tbTinNhan.Text);

                // Gui du lieu
                int dem = sk.Send(duLieu);

                // Nhan tra loi va hien thi
                byte[] ketQua = new byte[1024];
                int demNhan = sk.Receive(ketQua);
                tbLichSu.Text += "Bạn (" + DateTime.Now.ToString("HH:mm dd-MM-yyyy") + "): " + tbTinNhan.Text;
                tbLichSu.Text += "(" + Encoding.UTF8.GetString(ketQua, 0, demNhan) + ")\r\n";
                tbTinNhan.Text = "";
                tbTinNhan.Focus();

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

        private void Form1_Load(object sender, EventArgs e)
        {
            tbTinNhan.Focus();
        }

        private void tbTinNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btGui_Click(sender, e);                
            }
        }
    }
}
