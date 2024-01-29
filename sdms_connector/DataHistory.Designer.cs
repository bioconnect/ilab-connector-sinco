namespace sdms_connector
{
    partial class DataHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panTitle = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panSearch = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbFileNm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panBody = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTransHistory = new System.Windows.Forms.DataGridView();
            this.AUTO_YN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AUTO_YN_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILE_SIZE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REG_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REG_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANS_YN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRY_CNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRY_AGAIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SVR_TRANS_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEND_LOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REV_SUB_FOLDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FAIL_REASON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUB_FOLDER_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panTitle.SuspendLayout();
            this.panSearch.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panBody.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panTitle.Controls.Add(this.label6);
            this.panTitle.Controls.Add(this.label1);
            this.panTitle.Controls.Add(this.panSearch);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(1399, 105);
            this.panTitle.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(0, 34);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.label6.Size = new System.Drawing.Size(1399, 2);
            this.label6.TabIndex = 16;
            this.label6.Text = "Data";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "데이터이력";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panSearch
            // 
            this.panSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panSearch.Controls.Add(this.tableLayoutPanel1);
            this.panSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panSearch.Location = new System.Drawing.Point(0, 36);
            this.panSearch.Margin = new System.Windows.Forms.Padding(0);
            this.panSearch.Name = "panSearch";
            this.panSearch.Padding = new System.Windows.Forms.Padding(23, 26, 23, 34);
            this.panSearch.Size = new System.Drawing.Size(1399, 69);
            this.panSearch.TabIndex = 2;
            this.panSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.panSearch_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.92621F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.33376F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.07781F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.216791F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.17251F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.683389F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.16954F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.41999F));
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbFileNm, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpFrom, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpTo, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 26);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1353, 54);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(156)))), ((int)(((byte)(136)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(1212, 4);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 33);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbFileNm
            // 
            this.tbFileNm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFileNm.Location = new System.Drawing.Point(123, 4);
            this.tbFileNm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbFileNm.Name = "tbFileNm";
            this.tbFileNm.Size = new System.Drawing.Size(377, 28);
            this.tbFileNm.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 54);
            this.label4.TabIndex = 9;
            this.label4.Text = "파일명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.UseCompatibleTextRendering = true;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(531, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 54);
            this.label5.TabIndex = 11;
            this.label5.Text = "업로드 일시";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.UseCompatibleTextRendering = true;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(646, 4);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(251, 28);
            this.dtpFrom.TabIndex = 12;
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(954, 4);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(251, 28);
            this.dtpTo.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.label3.Location = new System.Drawing.Point(901, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 54);
            this.label3.TabIndex = 13;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.UseCompatibleTextRendering = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.ForeColor = System.Drawing.Color.Snow;
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(17, 19, 17, 19);
            this.groupBox1.Size = new System.Drawing.Size(1118, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panBody
            // 
            this.panBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panBody.Controls.Add(this.label2);
            this.panBody.Controls.Add(this.tableLayoutPanel2);
            this.panBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBody.Location = new System.Drawing.Point(0, 105);
            this.panBody.Margin = new System.Windows.Forms.Padding(0);
            this.panBody.Name = "panBody";
            this.panBody.Size = new System.Drawing.Size(1399, 756);
            this.panBody.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(1399, 2);
            this.label2.TabIndex = 7;
            this.label2.Text = "Data";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dgvTransHistory, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1399, 756);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // dgvTransHistory
            // 
            this.dgvTransHistory.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvTransHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AUTO_YN,
            this.AUTO_YN_NM,
            this.FILE_NM,
            this.FILE_SIZE,
            this.REG_ID,
            this.REG_DT,
            this.TRANS_YN,
            this.TRY_CNT,
            this.TRY_AGAIN,
            this.SVR_TRANS_DT,
            this.SEND_LOC,
            this.REV_SUB_FOLDER,
            this.FAIL_REASON,
            this.SUB_FOLDER_CD});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransHistory.EnableHeadersVisualStyles = false;
            this.dgvTransHistory.Location = new System.Drawing.Point(4, 6);
            this.dgvTransHistory.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvTransHistory.MultiSelect = false;
            this.dgvTransHistory.Name = "dgvTransHistory";
            this.dgvTransHistory.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTransHistory.RowHeadersWidth = 51;
            this.dgvTransHistory.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.dgvTransHistory.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTransHistory.RowTemplate.Height = 23;
            this.dgvTransHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransHistory.Size = new System.Drawing.Size(1391, 744);
            this.dgvTransHistory.TabIndex = 8;
            this.dgvTransHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransHistory_CellClick);
            // 
            // AUTO_YN
            // 
            this.AUTO_YN.HeaderText = "AUTO_YN";
            this.AUTO_YN.MinimumWidth = 8;
            this.AUTO_YN.Name = "AUTO_YN";
            this.AUTO_YN.ReadOnly = true;
            this.AUTO_YN.Width = 80;
            // 
            // AUTO_YN_NM
            // 
            this.AUTO_YN_NM.HeaderText = "AUTO_YN_NM";
            this.AUTO_YN_NM.MinimumWidth = 8;
            this.AUTO_YN_NM.Name = "AUTO_YN_NM";
            this.AUTO_YN_NM.ReadOnly = true;
            this.AUTO_YN_NM.Width = 80;
            // 
            // FILE_NM
            // 
            this.FILE_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FILE_NM.HeaderText = "FILE_NM";
            this.FILE_NM.MinimumWidth = 8;
            this.FILE_NM.Name = "FILE_NM";
            this.FILE_NM.ReadOnly = true;
            this.FILE_NM.Width = 400;
            // 
            // FILE_SIZE
            // 
            this.FILE_SIZE.HeaderText = "FILE_SIZE";
            this.FILE_SIZE.MinimumWidth = 8;
            this.FILE_SIZE.Name = "FILE_SIZE";
            this.FILE_SIZE.ReadOnly = true;
            this.FILE_SIZE.Width = 121;
            // 
            // REG_ID
            // 
            this.REG_ID.HeaderText = "REG_ID";
            this.REG_ID.MinimumWidth = 8;
            this.REG_ID.Name = "REG_ID";
            this.REG_ID.ReadOnly = true;
            this.REG_ID.Width = 80;
            // 
            // REG_DT
            // 
            this.REG_DT.HeaderText = "REG_DT";
            this.REG_DT.MinimumWidth = 8;
            this.REG_DT.Name = "REG_DT";
            this.REG_DT.ReadOnly = true;
            this.REG_DT.Width = 130;
            // 
            // TRANS_YN
            // 
            this.TRANS_YN.HeaderText = "TRANS_YN";
            this.TRANS_YN.MinimumWidth = 8;
            this.TRANS_YN.Name = "TRANS_YN";
            this.TRANS_YN.ReadOnly = true;
            this.TRANS_YN.Width = 80;
            // 
            // TRY_CNT
            // 
            this.TRY_CNT.HeaderText = "TRY_CNT";
            this.TRY_CNT.MinimumWidth = 8;
            this.TRY_CNT.Name = "TRY_CNT";
            this.TRY_CNT.ReadOnly = true;
            this.TRY_CNT.Width = 80;
            // 
            // TRY_AGAIN
            // 
            this.TRY_AGAIN.HeaderText = "TRY_AGAIN";
            this.TRY_AGAIN.MinimumWidth = 8;
            this.TRY_AGAIN.Name = "TRY_AGAIN";
            this.TRY_AGAIN.ReadOnly = true;
            this.TRY_AGAIN.Width = 80;
            // 
            // SVR_TRANS_DT
            // 
            this.SVR_TRANS_DT.HeaderText = "SVR_TRANS_DT";
            this.SVR_TRANS_DT.MinimumWidth = 8;
            this.SVR_TRANS_DT.Name = "SVR_TRANS_DT";
            this.SVR_TRANS_DT.ReadOnly = true;
            this.SVR_TRANS_DT.Width = 172;
            // 
            // SEND_LOC
            // 
            this.SEND_LOC.HeaderText = "SEND_LOC";
            this.SEND_LOC.MinimumWidth = 8;
            this.SEND_LOC.Name = "SEND_LOC";
            this.SEND_LOC.ReadOnly = true;
            this.SEND_LOC.Width = 200;
            // 
            // REV_SUB_FOLDER
            // 
            this.REV_SUB_FOLDER.HeaderText = "REV_SUB_FOLDER";
            this.REV_SUB_FOLDER.MinimumWidth = 8;
            this.REV_SUB_FOLDER.Name = "REV_SUB_FOLDER";
            this.REV_SUB_FOLDER.ReadOnly = true;
            this.REV_SUB_FOLDER.Width = 300;
            // 
            // FAIL_REASON
            // 
            this.FAIL_REASON.HeaderText = "FAIL_REASON";
            this.FAIL_REASON.MinimumWidth = 8;
            this.FAIL_REASON.Name = "FAIL_REASON";
            this.FAIL_REASON.ReadOnly = true;
            this.FAIL_REASON.Width = 156;
            // 
            // SUB_FOLDER_CD
            // 
            this.SUB_FOLDER_CD.HeaderText = "SUB_FOLDER_CD";
            this.SUB_FOLDER_CD.MinimumWidth = 8;
            this.SUB_FOLDER_CD.Name = "SUB_FOLDER_CD";
            this.SUB_FOLDER_CD.ReadOnly = true;
            this.SUB_FOLDER_CD.Width = 182;
            // 
            // DataHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 861);
            this.Controls.Add(this.panBody);
            this.Controls.Add(this.panTitle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataHistory";
            this.Text = "DataHistory";
            this.Resize += new System.EventHandler(this.DataHistory_Resize);
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.panSearch.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panBody.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.Panel panSearch;
        private System.Windows.Forms.Panel panBody;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTransHistory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFileNm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AUTO_YN;
        private System.Windows.Forms.DataGridViewTextBoxColumn AUTO_YN_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILE_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILE_SIZE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REG_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn REG_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANS_YN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRY_CNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRY_AGAIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SVR_TRANS_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEND_LOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn REV_SUB_FOLDER;
        private System.Windows.Forms.DataGridViewTextBoxColumn FAIL_REASON;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUB_FOLDER_CD;
    }
}