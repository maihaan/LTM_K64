
namespace SocketFileClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.btGui = new System.Windows.Forms.Button();
            this.tbTinNhan = new System.Windows.Forms.TextBox();
            this.tbLichSu = new System.Windows.Forms.TextBox();
            this.pbTep = new System.Windows.Forms.PictureBox();
            this.lblDuongDan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nội dung tin nhắn";
            // 
            // btGui
            // 
            this.btGui.Location = new System.Drawing.Point(12, 446);
            this.btGui.Name = "btGui";
            this.btGui.Size = new System.Drawing.Size(75, 23);
            this.btGui.TabIndex = 6;
            this.btGui.Text = "Gửi";
            this.btGui.UseVisualStyleBackColor = true;
            this.btGui.Click += new System.EventHandler(this.btGui_Click);
            // 
            // tbTinNhan
            // 
            this.tbTinNhan.Location = new System.Drawing.Point(12, 380);
            this.tbTinNhan.MaxLength = 1024;
            this.tbTinNhan.Multiline = true;
            this.tbTinNhan.Name = "tbTinNhan";
            this.tbTinNhan.Size = new System.Drawing.Size(335, 59);
            this.tbTinNhan.TabIndex = 5;
            // 
            // tbLichSu
            // 
            this.tbLichSu.Location = new System.Drawing.Point(12, 12);
            this.tbLichSu.Multiline = true;
            this.tbLichSu.Name = "tbLichSu";
            this.tbLichSu.ReadOnly = true;
            this.tbLichSu.Size = new System.Drawing.Size(335, 335);
            this.tbLichSu.TabIndex = 4;
            // 
            // pbTep
            // 
            this.pbTep.Image = global::SocketFileClient.Properties.Resources.AttackIcon20;
            this.pbTep.Location = new System.Drawing.Point(109, 351);
            this.pbTep.Name = "pbTep";
            this.pbTep.Size = new System.Drawing.Size(26, 23);
            this.pbTep.TabIndex = 8;
            this.pbTep.TabStop = false;
            this.pbTep.Click += new System.EventHandler(this.pbTep_Click);
            // 
            // lblDuongDan
            // 
            this.lblDuongDan.AutoSize = true;
            this.lblDuongDan.Location = new System.Drawing.Point(141, 354);
            this.lblDuongDan.Name = "lblDuongDan";
            this.lblDuongDan.Size = new System.Drawing.Size(16, 13);
            this.lblDuongDan.TabIndex = 9;
            this.lblDuongDan.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 480);
            this.Controls.Add(this.lblDuongDan);
            this.Controls.Add(this.pbTep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btGui);
            this.Controls.Add(this.tbTinNhan);
            this.Controls.Add(this.tbLichSu);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbTep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGui;
        private System.Windows.Forms.TextBox tbTinNhan;
        private System.Windows.Forms.TextBox tbLichSu;
        private System.Windows.Forms.PictureBox pbTep;
        private System.Windows.Forms.Label lblDuongDan;
    }
}

