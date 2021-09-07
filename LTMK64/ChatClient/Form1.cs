using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        Dictionary<String, String> danhBa = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tai ve danh ba vao ListBox va ComboBox
            // Cu phap tai danh ba: [DanhBa]
            String yeuCau = "[DanhBa]";
            String ketQua = Request(yeuCau);
            if(!String.IsNullOrEmpty(ketQua) && !ketQua.Equals("[NULL]"))
            {
                List<String> dsNguoiDung = ketQua.Split('^').ToList();
                if(dsNguoiDung != null && dsNguoiDung.Count > 0)
                {
                    DataTable tb = new DataTable();
                    tb.Columns.Add("ID", typeof(String));
                    tb.Columns.Add("TaiKhoan", typeof(String));
                    tb.Columns.Add("HoTen", typeof(String));

                    foreach (String nguoiDung in dsNguoiDung)
                    {
                        String id = nguoiDung.Split('~')[0];
                        String taiKhoan = nguoiDung.Split('~')[1];
                        String hoTen = nguoiDung.Split('~')[2];

                        DataRow r = tb.NewRow();
                        r["ID"] = id;
                        r["TaiKhoan"] = taiKhoan;
                        r["HoTen"] = hoTen;
                        tb.Rows.Add(r);

                        danhBa.Add(taiKhoan, hoTen);
                    }
                    DataTable tb1 = tb.Copy();

                    cbNguoiDung.DataSource = tb;
                    cbNguoiDung.DisplayMember = "HoTen";
                    cbNguoiDung.ValueMember = "TaiKhoan";

                    
                    lbDanhBa.DataSource = tb1;
                    lbDanhBa.DisplayMember = "HoTen";
                    lbDanhBa.ValueMember = "TaiKhoan";
                }    
            }

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Neu dong duoc chon trung voi gia tri dang chon o comboBox thi khong lam gi ca
            if (lbDanhBa.SelectedValue.Equals(cbNguoiDung.SelectedValue))
            {
                return;
            }

            // Cap nhat tin nhan giua hai nguoi dung theo cu phap: [?] ~ NguoiNhan
            String yeuCau = "[?]~" + lbDanhBa.SelectedValue + "~" + cbNguoiDung.SelectedValue;
            String ketQua = Request(yeuCau);
            if (!String.IsNullOrEmpty(ketQua) && !ketQua.Equals("[NULL]"))
            {
                List<String> dsTinNhan = ketQua.Split('^').ToList();
                if(dsTinNhan != null && dsTinNhan.Count > 0)
                {
                    foreach(String tinNhan in dsTinNhan)
                    {
                        String nguoiGui = tinNhan.Split('~')[0];
                        String noiDung = tinNhan.Split('~')[1];
                        String thoiGian = tinNhan.Split('~')[2];

                        tbLichSu.Text += danhBa[nguoiGui] + " (" + thoiGian + "): " + noiDung + "\r\n";
                    }    
                }    
            }    
        }

        private String Request(String yeuCau)
        {
            // Gui du lieu
            String serverIP = "127.0.0.1";
            int port = 12000;

            System.Net.Sockets.Socket sk = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Ket noi den may chu
                sk.Connect(IPAddress.Parse(serverIP), port);

                // Chuyen yeu cau sang dang mang byte
                byte[] duLieu = Encoding.UTF8.GetBytes(yeuCau);

                // Gui yeu cau
                int dem = sk.Send(duLieu);

                // Nhan tra loi va hien thi
                byte[] ketQua = new byte[102400];
                int demNhan = sk.Receive(ketQua);
                String traLoi = Encoding.UTF8.GetString(ketQua, 0, demNhan);                

                // Dong ket noi
                sk.Close();
                sk.Dispose();

                return traLoi;
            }
            catch
            {
                return null;
            }
        }

        private void lbDanhBa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Neu dong duoc chon trung voi gia tri dang chon o comboBox thi khong lam gi ca
            if (lbDanhBa.SelectedValue.Equals(cbNguoiDung.SelectedValue))
            {
                tbLichSu.Text = "";
                tbTinNhan.Text = "";
                tbTinNhan.Enabled = false;
                btGui.Enabled = false;
                return;
            }

            // Mo soan tin nhan va gui
            tbTinNhan.Enabled = true;
            btGui.Enabled = true;
            tbLichSu.Text = "";

            // Tai lich su nhan tin giua hai nguoi dung ve theo cu phap: [???] ~ NguoiNhan ~ NguoiGui
            String yeuCau = "[???]~" + cbNguoiDung.SelectedValue + "~" + lbDanhBa.SelectedValue;
            String ketQua = Request(yeuCau);
            if (!String.IsNullOrEmpty(ketQua) && !ketQua.Equals("[NULL]"))
            {
                List<String> dsTinNhan = ketQua.Split('^').ToList();
                if(dsTinNhan != null && dsTinNhan.Count > 0)
                {
                    foreach(String tinNhan in dsTinNhan)
                    {
                        String nguoiNhan = tinNhan.Split('~')[0];
                        String nguoiGui = tinNhan.Split('~')[1];
                        String noiDung = tinNhan.Split('~')[2];
                        String thoiGian = tinNhan.Split('~')[3];

                        tbLichSu.Text += danhBa[nguoiGui] + " (" + thoiGian + "): " + noiDung + "\r\n";
                    }    
                }
                else
                {
                    tbLichSu.Text = "Chưa có tin nhắn nào";
                }
            }    
            else
            {
                tbLichSu.Text = "Chưa có tin nhắn nào";
            }    
        }

        private void btGui_Click(object sender, EventArgs e)
        {
            if(tbTinNhan.Text.Length > 0)
            {
                String yeuCau = cbNguoiDung.SelectedValue + "~" + lbDanhBa.SelectedValue + "~" + tbTinNhan.Text;
                String ketQua = Request(yeuCau);
                if(ketQua.Equals("Server đã nhận"))
                {
                    tbLichSu.Text += cbNguoiDung.Text + " (" + DateTime.Now.ToString() + "): " + tbTinNhan.Text + "\r\n";
                    tbTinNhan.Text = "";
                }    
                else
                {
                    tbLichSu.Text += cbNguoiDung.Text + " (" + DateTime.Now.ToString() + "): " + tbTinNhan.Text + " (Gửi thất bại)\r\n";
                    tbTinNhan.Text = "";
                }    
            }    
        }
    }
}
