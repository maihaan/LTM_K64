
namespace ChatClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbDanhBa = new System.Windows.Forms.ListBox();
            this.tbLichSu = new System.Windows.Forms.TextBox();
            this.tbTinNhan = new System.Windows.Forms.TextBox();
            this.btGui = new System.Windows.Forms.Button();
            this.cbNguoiDung = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbDanhBa
            // 
            this.lbDanhBa.FormattingEnabled = true;
            this.lbDanhBa.ItemHeight = 16;
            this.lbDanhBa.Location = new System.Drawing.Point(17, 48);
            this.lbDanhBa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDanhBa.Name = "lbDanhBa";
            this.lbDanhBa.Size = new System.Drawing.Size(263, 436);
            this.lbDanhBa.TabIndex = 0;
            this.lbDanhBa.SelectedIndexChanged += new System.EventHandler(this.lbDanhBa_SelectedIndexChanged);
            // 
            // tbLichSu
            // 
            this.tbLichSu.Location = new System.Drawing.Point(288, 16);
            this.tbLichSu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLichSu.Multiline = true;
            this.tbLichSu.Name = "tbLichSu";
            this.tbLichSu.ReadOnly = true;
            this.tbLichSu.Size = new System.Drawing.Size(655, 397);
            this.tbLichSu.TabIndex = 1;
            // 
            // tbTinNhan
            // 
            this.tbTinNhan.Location = new System.Drawing.Point(288, 422);
            this.tbTinNhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTinNhan.Multiline = true;
            this.tbTinNhan.Name = "tbTinNhan";
            this.tbTinNhan.Size = new System.Drawing.Size(511, 62);
            this.tbTinNhan.TabIndex = 2;
            // 
            // btGui
            // 
            this.btGui.Location = new System.Drawing.Point(807, 422);
            this.btGui.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btGui.Name = "btGui";
            this.btGui.Size = new System.Drawing.Size(136, 63);
            this.btGui.TabIndex = 3;
            this.btGui.Text = "Gửi";
            this.btGui.UseVisualStyleBackColor = true;
            this.btGui.Click += new System.EventHandler(this.btGui_Click);
            // 
            // cbNguoiDung
            // 
            this.cbNguoiDung.FormattingEnabled = true;
            this.cbNguoiDung.Location = new System.Drawing.Point(17, 16);
            this.cbNguoiDung.Name = "cbNguoiDung";
            this.cbNguoiDung.Size = new System.Drawing.Size(263, 24);
            this.cbNguoiDung.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 507);
            this.Controls.Add(this.cbNguoiDung);
            this.Controls.Add(this.btGui);
            this.Controls.Add(this.tbTinNhan);
            this.Controls.Add(this.tbLichSu);
            this.Controls.Add(this.lbDanhBa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Chat Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbDanhBa;
        private System.Windows.Forms.TextBox tbLichSu;
        private System.Windows.Forms.TextBox tbTinNhan;
        private System.Windows.Forms.Button btGui;
        private System.Windows.Forms.ComboBox cbNguoiDung;
        private System.Windows.Forms.Timer timer1;
    }
}

