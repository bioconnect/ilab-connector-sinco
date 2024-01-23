namespace sdms_connector
{
    partial class SubForm
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
            this.panBottomDetail = new System.Windows.Forms.Panel();
            this.panTopMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrivateInfo = new System.Windows.Forms.Label();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.btnFtpSetting = new System.Windows.Forms.Button();
            this.btnDataHistory = new System.Windows.Forms.Button();
            this.panTopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBottomDetail
            // 
            this.panBottomDetail.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panBottomDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBottomDetail.Location = new System.Drawing.Point(0, 88);
            this.panBottomDetail.Margin = new System.Windows.Forms.Padding(0);
            this.panBottomDetail.Name = "panBottomDetail";
            this.panBottomDetail.Size = new System.Drawing.Size(1160, 644);
            this.panBottomDetail.TabIndex = 1;
            // 
            // panTopMenu
            // 
            this.panTopMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.panTopMenu.Controls.Add(this.label1);
            this.panTopMenu.Controls.Add(this.lblPrivateInfo);
            this.panTopMenu.Controls.Add(this.btnSchedule);
            this.panTopMenu.Controls.Add(this.btnClient);
            this.panTopMenu.Controls.Add(this.btnFtpSetting);
            this.panTopMenu.Controls.Add(this.btnDataHistory);
            this.panTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTopMenu.ForeColor = System.Drawing.Color.Black;
            this.panTopMenu.Location = new System.Drawing.Point(0, 0);
            this.panTopMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panTopMenu.Name = "panTopMenu";
            this.panTopMenu.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            this.panTopMenu.Size = new System.Drawing.Size(1160, 88);
            this.panTopMenu.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(881, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 88);
            this.label1.TabIndex = 2;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrivateInfo
            // 
            this.lblPrivateInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.lblPrivateInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPrivateInfo.ForeColor = System.Drawing.SystemColors.Window;
            this.lblPrivateInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrivateInfo.Location = new System.Drawing.Point(923, 0);
            this.lblPrivateInfo.Name = "lblPrivateInfo";
            this.lblPrivateInfo.Padding = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.lblPrivateInfo.Size = new System.Drawing.Size(237, 88);
            this.lblPrivateInfo.TabIndex = 1;
            this.lblPrivateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnSchedule.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSchedule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(218)))), ((int)(((byte)(189)))));
            this.btnSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSchedule.Location = new System.Drawing.Point(707, 0);
            this.btnSchedule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(171, 88);
            this.btnSchedule.TabIndex = 0;
            this.btnSchedule.Text = "스케쥴";
            this.btnSchedule.UseVisualStyleBackColor = false;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnClient
            // 
            this.btnClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnClient.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClient.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClient.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(218)))), ((int)(((byte)(189)))));
            this.btnClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClient.Location = new System.Drawing.Point(365, 0);
            this.btnClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(171, 88);
            this.btnClient.TabIndex = 0;
            this.btnClient.Text = "클라이언트";
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // btnFtpSetting
            // 
            this.btnFtpSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFtpSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(81)))), ((int)(((byte)(97)))));
            this.btnFtpSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFtpSetting.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFtpSetting.ForeColor = System.Drawing.Color.White;
            this.btnFtpSetting.Image = global::sdms_connector.Properties.Resources.icon_menu02_FTPsetting;
            this.btnFtpSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFtpSetting.Location = new System.Drawing.Point(170, 0);
            this.btnFtpSetting.Name = "btnFtpSetting";
            this.btnFtpSetting.Size = new System.Drawing.Size(150, 70);
            this.btnFtpSetting.TabIndex = 0;
            this.btnFtpSetting.Text = "FTP 설정";
            this.btnFtpSetting.UseVisualStyleBackColor = true;
            this.btnFtpSetting.Visible = false;
            this.btnFtpSetting.Click += new System.EventHandler(this.btnFtpSetting_Click);
            // 
            // btnDataHistory
            // 
            this.btnDataHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnDataHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDataHistory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnDataHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataHistory.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDataHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(218)))), ((int)(((byte)(189)))));
            this.btnDataHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataHistory.Location = new System.Drawing.Point(23, 0);
            this.btnDataHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDataHistory.Name = "btnDataHistory";
            this.btnDataHistory.Size = new System.Drawing.Size(171, 88);
            this.btnDataHistory.TabIndex = 0;
            this.btnDataHistory.Text = "데이터 전송 이력";
            this.btnDataHistory.UseVisualStyleBackColor = false;
            this.btnDataHistory.Click += new System.EventHandler(this.btnDataHistory_Click);
            // 
            // SubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 732);
            this.Controls.Add(this.panBottomDetail);
            this.Controls.Add(this.panTopMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SubForm";
            this.Text = "SubForm";
            this.panTopMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panBottomDetail;
        private System.Windows.Forms.Panel panTopMenu;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnFtpSetting;
        private System.Windows.Forms.Button btnDataHistory;
        private System.Windows.Forms.Label lblPrivateInfo;
        private System.Windows.Forms.Label label1;
    }
}