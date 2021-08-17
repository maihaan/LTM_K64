
namespace SocketClient
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
            this.tbLichSu = new System.Windows.Forms.TextBox();
            this.tbTinNhan = new System.Windows.Forms.TextBox();
            this.btGui = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbLichSu
            // 
            this.tbLichSu.Location = new System.Drawing.Point(13, 13);
            this.tbLichSu.Multiline = true;
            this.tbLichSu.Name = "tbLichSu";
            this.tbLichSu.ReadOnly = true;
            this.tbLichSu.Size = new System.Drawing.Size(335, 335);
            this.tbLichSu.TabIndex = 0;
            // 
            // tbTinNhan
            // 
            this.tbTinNhan.Location = new System.Drawing.Point(13, 377);
            this.tbTinNhan.Multiline = true;
            this.tbTinNhan.Name = "tbTinNhan";
            this.tbTinNhan.Size = new System.Drawing.Size(335, 63);
            this.tbTinNhan.TabIndex = 1;
            this.tbTinNhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTinNhan_KeyDown);
            // 
            // btGui
            // 
            this.btGui.Location = new System.Drawing.Point(13, 447);
            this.btGui.Name = "btGui";
            this.btGui.Size = new System.Drawing.Size(75, 23);
            this.btGui.TabIndex = 2;
            this.btGui.Text = "Gửi";
            this.btGui.UseVisualStyleBackColor = true;
            this.btGui.Click += new System.EventHandler(this.btGui_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nội dung tin nhắn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 483);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btGui);
            this.Controls.Add(this.tbTinNhan);
            this.Controls.Add(this.tbLichSu);
            this.Name = "Form1";
            this.Text = "Socket Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLichSu;
        private System.Windows.Forms.TextBox tbTinNhan;
        private System.Windows.Forms.Button btGui;
        private System.Windows.Forms.Label label1;
    }
}

