namespace LASConnector
{
    partial class DeviceMng
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblClientList = new System.Windows.Forms.Label();
            this.panBody = new System.Windows.Forms.Panel();
            this.tblBody = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDevice = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panTitle = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.devNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parsRuleNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ptcType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnProtocolSetting = new System.Windows.Forms.DataGridViewButtonColumn();
            this.devWatchFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnWatchFolder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnParsingView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.connYn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panBody.SuspendLayout();
            this.tblBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).BeginInit();
            this.panTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblClientList
            // 
            this.lblClientList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblClientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClientList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.lblClientList.ForeColor = System.Drawing.Color.White;
            this.lblClientList.Location = new System.Drawing.Point(3, 0);
            this.lblClientList.Name = "lblClientList";
            this.lblClientList.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.lblClientList.Size = new System.Drawing.Size(1112, 50);
            this.lblClientList.TabIndex = 7;
            this.lblClientList.Text = "장비현황 목록";
            this.lblClientList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblClientList.Click += new System.EventHandler(this.lblClientList_Click);
            // 
            // panBody
            // 
            this.panBody.BackColor = System.Drawing.SystemColors.Window;
            this.panBody.Controls.Add(this.tblBody);
            this.panBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBody.Location = new System.Drawing.Point(0, 39);
            this.panBody.Margin = new System.Windows.Forms.Padding(0);
            this.panBody.Name = "panBody";
            this.panBody.Size = new System.Drawing.Size(1118, 719);
            this.panBody.TabIndex = 6;
            // 
            // tblBody
            // 
            this.tblBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.tblBody.ColumnCount = 1;
            this.tblBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBody.Controls.Add(this.lblClientList, 0, 0);
            this.tblBody.Controls.Add(this.dgvDevice, 0, 1);
            this.tblBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBody.Location = new System.Drawing.Point(0, 0);
            this.tblBody.Margin = new System.Windows.Forms.Padding(0);
            this.tblBody.Name = "tblBody";
            this.tblBody.RowCount = 3;
            this.tblBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tblBody.Size = new System.Drawing.Size(1118, 719);
            this.tblBody.TabIndex = 8;
            // 
            // dgvDevice
            // 
            this.dgvDevice.AllowUserToAddRows = false;
            this.dgvDevice.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDevice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.devNm,
            this.parsRuleNm,
            this.ptcType,
            this.btnProtocolSetting,
            this.devWatchFolder,
            this.btnWatchFolder,
            this.btnParsingView,
            this.connYn});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDevice.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevice.EnableHeadersVisualStyles = false;
            this.dgvDevice.Location = new System.Drawing.Point(3, 54);
            this.dgvDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDevice.Name = "dgvDevice";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDevice.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDevice.RowHeadersWidth = 51;
            this.dgvDevice.RowTemplate.Height = 23;
            this.dgvDevice.Size = new System.Drawing.Size(1112, 644);
            this.dgvDevice.TabIndex = 8;
            this.dgvDevice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevice_CellClick);
            this.dgvDevice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevice_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "장비현황관리";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panTitle.Controls.Add(this.label2);
            this.panTitle.Controls.Add(this.label1);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(1118, 39);
            this.panTitle.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(0, 38);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(1118, 1);
            this.label2.TabIndex = 17;
            this.label2.Text = "클라이언트 목록";
            // 
            // devNm
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.devNm.DefaultCellStyle = dataGridViewCellStyle2;
            this.devNm.HeaderText = "장비명";
            this.devNm.MinimumWidth = 6;
            this.devNm.Name = "devNm";
            this.devNm.ReadOnly = true;
            this.devNm.Width = 125;
            // 
            // parsRuleNm
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.parsRuleNm.DefaultCellStyle = dataGridViewCellStyle3;
            this.parsRuleNm.HeaderText = "Rule Name";
            this.parsRuleNm.MinimumWidth = 6;
            this.parsRuleNm.Name = "parsRuleNm";
            this.parsRuleNm.ReadOnly = true;
            this.parsRuleNm.Width = 125;
            // 
            // ptcType
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ptcType.DefaultCellStyle = dataGridViewCellStyle4;
            this.ptcType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ptcType.HeaderText = "프로토콜타입";
            this.ptcType.Items.AddRange(new object[] {
            "TCP/IP",
            "RS-232C"});
            this.ptcType.MinimumWidth = 6;
            this.ptcType.Name = "ptcType";
            this.ptcType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ptcType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ptcType.Width = 125;
            // 
            // btnProtocolSetting
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(156)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.btnProtocolSetting.DefaultCellStyle = dataGridViewCellStyle5;
            this.btnProtocolSetting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProtocolSetting.HeaderText = "프로토콜설정";
            this.btnProtocolSetting.MinimumWidth = 6;
            this.btnProtocolSetting.Name = "btnProtocolSetting";
            this.btnProtocolSetting.ReadOnly = true;
            this.btnProtocolSetting.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnProtocolSetting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnProtocolSetting.Text = "설정";
            this.btnProtocolSetting.Width = 125;
            // 
            // devWatchFolder
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.devWatchFolder.DefaultCellStyle = dataGridViewCellStyle6;
            this.devWatchFolder.HeaderText = "장비감시폴더";
            this.devWatchFolder.MinimumWidth = 6;
            this.devWatchFolder.Name = "devWatchFolder";
            this.devWatchFolder.ReadOnly = true;
            this.devWatchFolder.Width = 125;
            // 
            // btnWatchFolder
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(156)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.btnWatchFolder.DefaultCellStyle = dataGridViewCellStyle7;
            this.btnWatchFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWatchFolder.HeaderText = "장비감시폴더설정";
            this.btnWatchFolder.MinimumWidth = 6;
            this.btnWatchFolder.Name = "btnWatchFolder";
            this.btnWatchFolder.ReadOnly = true;
            this.btnWatchFolder.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnWatchFolder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnWatchFolder.Text = "찾아보기";
            this.btnWatchFolder.Width = 125;
            // 
            // btnParsingView
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(165)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.btnParsingView.DefaultCellStyle = dataGridViewCellStyle8;
            this.btnParsingView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnParsingView.HeaderText = "Parsing View";
            this.btnParsingView.MinimumWidth = 6;
            this.btnParsingView.Name = "btnParsingView";
            this.btnParsingView.ReadOnly = true;
            this.btnParsingView.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnParsingView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnParsingView.Text = "View";
            this.btnParsingView.Visible = false;
            this.btnParsingView.Width = 125;
            // 
            // connYn
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.connYn.DefaultCellStyle = dataGridViewCellStyle9;
            this.connYn.HeaderText = "연결상태";
            this.connYn.MinimumWidth = 6;
            this.connYn.Name = "connYn";
            this.connYn.ReadOnly = true;
            this.connYn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.connYn.Width = 125;
            // 
            // DeviceMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1118, 758);
            this.Controls.Add(this.panBody);
            this.Controls.Add(this.panTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DeviceMng";
            this.Text = "ClientMng";
            this.panBody.ResumeLayout(false);
            this.tblBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).EndInit();
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblClientList;
        private System.Windows.Forms.Panel panBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.TableLayoutPanel tblBody;
        private System.Windows.Forms.DataGridView dgvDevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn devNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn parsRuleNm;
        private System.Windows.Forms.DataGridViewComboBoxColumn ptcType;
        private System.Windows.Forms.DataGridViewButtonColumn btnProtocolSetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn devWatchFolder;
        private System.Windows.Forms.DataGridViewButtonColumn btnWatchFolder;
        private System.Windows.Forms.DataGridViewButtonColumn btnParsingView;
        private System.Windows.Forms.DataGridViewTextBoxColumn connYn;
    }
}