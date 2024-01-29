namespace sdms_connector
{
    partial class Login
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSvrSetting = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbPlant = new System.Windows.Forms.ComboBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUserID
            // 
            this.tbUserID.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserID.Enabled = false;
            this.tbUserID.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.tbUserID.ForeColor = System.Drawing.Color.Gray;
            this.tbUserID.Location = new System.Drawing.Point(4, 4);
            this.tbUserID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(364, 24);
            this.tbUserID.TabIndex = 1;
            this.tbUserID.Text = "ID";
            this.tbUserID.Leave += new System.EventHandler(this.tbUserID_Leave);
            // 
            // tbPwd
            // 
            this.tbPwd.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPwd.Enabled = false;
            this.tbPwd.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.tbPwd.ForeColor = System.Drawing.Color.Gray;
            this.tbPwd.Location = new System.Drawing.Point(4, 64);
            this.tbPwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.Size = new System.Drawing.Size(364, 24);
            this.tbPwd.TabIndex = 2;
            this.tbPwd.Text = "PASSWORD";
            this.tbPwd.Leave += new System.EventHandler(this.tbPwd_Leave);
            // 
            // tbServer
            // 
            this.tbServer.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbServer.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbServer.Enabled = false;
            this.tbServer.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.tbServer.Location = new System.Drawing.Point(0, 0);
            this.tbServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(330, 24);
            this.tbServer.TabIndex = 5;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(120)))), ((int)(((byte)(115)))));
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(120)))), ((int)(((byte)(115)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLogin.Location = new System.Drawing.Point(4, 4);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(374, 58);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSvrSetting
            // 
            this.btnSvrSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSvrSetting.FlatAppearance.BorderSize = 0;
            this.btnSvrSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSvrSetting.Image = global::sdms_connector.Properties.Resources.icon_menu02_FTPsetting1;
            this.btnSvrSetting.Location = new System.Drawing.Point(332, 0);
            this.btnSvrSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSvrSetting.Name = "btnSvrSetting";
            this.btnSvrSetting.Size = new System.Drawing.Size(36, 28);
            this.btnSvrSetting.TabIndex = 6;
            this.btnSvrSetting.UseVisualStyleBackColor = false;
            this.btnSvrSetting.Click += new System.EventHandler(this.btnSvrSetting_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbPwd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbUserID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbPlant, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbLanguage, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(374, 180);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbServer);
            this.panel2.Controls.Add(this.btnSvrSetting);
            this.panel2.Location = new System.Drawing.Point(4, 124);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 50);
            this.panel2.TabIndex = 5;
            // 
            // cbPlant
            // 
            this.cbPlant.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cbPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlant.Enabled = false;
            this.cbPlant.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.cbPlant.FormattingEnabled = true;
            this.cbPlant.Location = new System.Drawing.Point(4, 184);
            this.cbPlant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPlant.Name = "cbPlant";
            this.cbPlant.Size = new System.Drawing.Size(362, 22);
            this.cbPlant.TabIndex = 4;
            this.cbPlant.Visible = false;
            this.cbPlant.SelectionChangeCommitted += new System.EventHandler(this.cbPlant_SelectionChangeCommitted);
            // 
            // cbLanguage
            // 
            this.cbLanguage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.Enabled = false;
            this.cbLanguage.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(4, 244);
            this.cbLanguage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(362, 22);
            this.cbLanguage.TabIndex = 3;
            this.cbLanguage.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(894, 404);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(382, 188);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(120)))), ((int)(((byte)(115)))));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnLogin, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(894, 598);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(382, 66);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::sdms_connector.Properties.Resources.ilab_base_login;
            this.ClientSize = new System.Drawing.Size(1370, 890);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Login";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSvrSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cbPlant;
        private System.Windows.Forms.ComboBox cbLanguage;
    }
}

