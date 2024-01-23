namespace sdms_connector
{
    partial class ScheduleMng
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
            this.label1 = new System.Windows.Forms.Label();
            this.panTitle = new System.Windows.Forms.Panel();
            this.hiddenSubFolderCd = new System.Windows.Forms.TextBox();
            this.hiddenFolderCd = new System.Windows.Forms.TextBox();
            this.hiddenProjCd = new System.Windows.Forms.TextBox();
            this.hiddenScheduleSeq = new System.Windows.Forms.TextBox();
            this.panScheduleList = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panBody = new System.Windows.Forms.Panel();
            this.gbScheduleInfo = new System.Windows.Forms.GroupBox();
            this.tlpScheduleInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.subPan5 = new System.Windows.Forms.Panel();
            this.tbFileExt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFileNm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.subPan4 = new System.Windows.Forms.Panel();
            this.dtpUploadTime = new System.Windows.Forms.DateTimePicker();
            this.rbOneAday = new System.Windows.Forms.RadioButton();
            this.rbRealtime = new System.Windows.Forms.RadioButton();
            this.subPan3 = new System.Windows.Forms.Panel();
            this.dtpUploadToTime = new System.Windows.Forms.DateTimePicker();
            this.dtpUploadToDt = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpUploadFromTime = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpUploadFromDt = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.subPan2 = new System.Windows.Forms.Panel();
            this.rbDeactivate = new System.Windows.Forms.RadioButton();
            this.rbActivate = new System.Windows.Forms.RadioButton();
            this.subPan1 = new System.Windows.Forms.Panel();
            this.tbSubFolderNm = new System.Windows.Forms.TextBox();
            this.btnSearchSubFolder = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panTitle.SuspendLayout();
            this.panScheduleList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.panBody.SuspendLayout();
            this.gbScheduleInfo.SuspendLayout();
            this.tlpScheduleInfo.SuspendLayout();
            this.subPan5.SuspendLayout();
            this.subPan4.SuspendLayout();
            this.subPan3.SuspendLayout();
            this.subPan2.SuspendLayout();
            this.subPan1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "스케쥴";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panTitle.Controls.Add(this.hiddenSubFolderCd);
            this.panTitle.Controls.Add(this.label1);
            this.panTitle.Controls.Add(this.hiddenFolderCd);
            this.panTitle.Controls.Add(this.hiddenProjCd);
            this.panTitle.Controls.Add(this.hiddenScheduleSeq);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.ForeColor = System.Drawing.Color.White;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(1066, 47);
            this.panTitle.TabIndex = 7;
            this.panTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.panTitle_Paint);
            // 
            // hiddenSubFolderCd
            // 
            this.hiddenSubFolderCd.Location = new System.Drawing.Point(820, 20);
            this.hiddenSubFolderCd.Name = "hiddenSubFolderCd";
            this.hiddenSubFolderCd.Size = new System.Drawing.Size(213, 21);
            this.hiddenSubFolderCd.TabIndex = 33;
            this.hiddenSubFolderCd.Text = "subFolderCd";
            this.hiddenSubFolderCd.Visible = false;
            // 
            // hiddenFolderCd
            // 
            this.hiddenFolderCd.Location = new System.Drawing.Point(601, 20);
            this.hiddenFolderCd.Name = "hiddenFolderCd";
            this.hiddenFolderCd.Size = new System.Drawing.Size(213, 21);
            this.hiddenFolderCd.TabIndex = 32;
            this.hiddenFolderCd.Text = "folderCd";
            this.hiddenFolderCd.Visible = false;
            // 
            // hiddenProjCd
            // 
            this.hiddenProjCd.Location = new System.Drawing.Point(382, 20);
            this.hiddenProjCd.Name = "hiddenProjCd";
            this.hiddenProjCd.Size = new System.Drawing.Size(213, 21);
            this.hiddenProjCd.TabIndex = 31;
            this.hiddenProjCd.Text = "projCd";
            this.hiddenProjCd.Visible = false;
            // 
            // hiddenScheduleSeq
            // 
            this.hiddenScheduleSeq.Location = new System.Drawing.Point(163, 20);
            this.hiddenScheduleSeq.Name = "hiddenScheduleSeq";
            this.hiddenScheduleSeq.Size = new System.Drawing.Size(213, 21);
            this.hiddenScheduleSeq.TabIndex = 30;
            this.hiddenScheduleSeq.Text = "0";
            this.hiddenScheduleSeq.Visible = false;
            // 
            // panScheduleList
            // 
            this.panScheduleList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panScheduleList.Controls.Add(this.btnNew);
            this.panScheduleList.Controls.Add(this.dgvSchedule);
            this.panScheduleList.Controls.Add(this.label2);
            this.panScheduleList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panScheduleList.Location = new System.Drawing.Point(0, 47);
            this.panScheduleList.Margin = new System.Windows.Forms.Padding(0);
            this.panScheduleList.Name = "panScheduleList";
            this.panScheduleList.Padding = new System.Windows.Forms.Padding(20, 5, 20, 20);
            this.panScheduleList.Size = new System.Drawing.Size(1066, 236);
            this.panScheduleList.TabIndex = 8;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(156)))), ((int)(((byte)(136)))));
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.ForeColor = System.Drawing.SystemColors.Window;
            this.btnNew.Location = new System.Drawing.Point(961, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(85, 27);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "추가";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSchedule.EnableHeadersVisualStyles = false;
            this.dgvSchedule.Location = new System.Drawing.Point(20, 35);
            this.dgvSchedule.Margin = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.dgvSchedule.MultiSelect = false;
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchedule.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSchedule.RowHeadersWidth = 62;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.dgvSchedule.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSchedule.RowTemplate.Height = 23;
            this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedule.Size = new System.Drawing.Size(1026, 186);
            this.dgvSchedule.TabIndex = 10;
            this.dgvSchedule.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedule_CellClick);
            this.dgvSchedule.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSchedule_DataBindingComplete);
            this.dgvSchedule.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvSchedule_RowPostPaint);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(20, 5);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(1026, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "스케쥴 목록";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panBody
            // 
            this.panBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panBody.Controls.Add(this.gbScheduleInfo);
            this.panBody.Controls.Add(this.label3);
            this.panBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBody.Location = new System.Drawing.Point(0, 283);
            this.panBody.Margin = new System.Windows.Forms.Padding(0);
            this.panBody.Name = "panBody";
            this.panBody.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.panBody.Size = new System.Drawing.Size(1066, 424);
            this.panBody.TabIndex = 9;
            // 
            // gbScheduleInfo
            // 
            this.gbScheduleInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.gbScheduleInfo.Controls.Add(this.tlpScheduleInfo);
            this.gbScheduleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbScheduleInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbScheduleInfo.Location = new System.Drawing.Point(20, 50);
            this.gbScheduleInfo.Margin = new System.Windows.Forms.Padding(15, 5, 15, 15);
            this.gbScheduleInfo.Name = "gbScheduleInfo";
            this.gbScheduleInfo.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.gbScheduleInfo.Size = new System.Drawing.Size(1026, 354);
            this.gbScheduleInfo.TabIndex = 11;
            this.gbScheduleInfo.TabStop = false;
            // 
            // tlpScheduleInfo
            // 
            this.tlpScheduleInfo.AutoScroll = true;
            this.tlpScheduleInfo.ColumnCount = 2;
            this.tlpScheduleInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpScheduleInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpScheduleInfo.Controls.Add(this.label9, 0, 2);
            this.tlpScheduleInfo.Controls.Add(this.label8, 0, 0);
            this.tlpScheduleInfo.Controls.Add(this.label10, 0, 1);
            this.tlpScheduleInfo.Controls.Add(this.label4, 0, 3);
            this.tlpScheduleInfo.Controls.Add(this.label5, 0, 4);
            this.tlpScheduleInfo.Controls.Add(this.subPan5, 1, 0);
            this.tlpScheduleInfo.Controls.Add(this.subPan4, 1, 1);
            this.tlpScheduleInfo.Controls.Add(this.subPan3, 1, 2);
            this.tlpScheduleInfo.Controls.Add(this.subPan2, 1, 3);
            this.tlpScheduleInfo.Controls.Add(this.subPan1, 1, 4);
            this.tlpScheduleInfo.Controls.Add(this.flowLayoutPanel1, 1, 5);
            this.tlpScheduleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpScheduleInfo.Location = new System.Drawing.Point(15, 29);
            this.tlpScheduleInfo.Name = "tlpScheduleInfo";
            this.tlpScheduleInfo.RowCount = 6;
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpScheduleInfo.Size = new System.Drawing.Size(996, 310);
            this.tlpScheduleInfo.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 60);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(249, 30);
            this.label9.TabIndex = 11;
            this.label9.Text = "업로드 기간";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.UseCompatibleTextRendering = true;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(249, 30);
            this.label8.TabIndex = 10;
            this.label8.Text = "이름 패턴";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.UseCompatibleTextRendering = true;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(249, 30);
            this.label10.TabIndex = 12;
            this.label10.Text = "업로드 시점";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 30);
            this.label4.TabIndex = 23;
            this.label4.Text = "활성화 여부";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 120);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "서브폴더 선택";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.UseCompatibleTextRendering = true;
            // 
            // subPan5
            // 
            this.subPan5.Controls.Add(this.tbFileExt);
            this.subPan5.Controls.Add(this.label6);
            this.subPan5.Controls.Add(this.tbFileNm);
            this.subPan5.Controls.Add(this.label7);
            this.subPan5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subPan5.Location = new System.Drawing.Point(252, 3);
            this.subPan5.Name = "subPan5";
            this.subPan5.Size = new System.Drawing.Size(741, 24);
            this.subPan5.TabIndex = 25;
            // 
            // tbFileExt
            // 
            this.tbFileExt.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbFileExt.Location = new System.Drawing.Point(420, 0);
            this.tbFileExt.Name = "tbFileExt";
            this.tbFileExt.Size = new System.Drawing.Size(213, 21);
            this.tbFileExt.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(361, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label6.Size = new System.Drawing.Size(59, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "확장자";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // tbFileNm
            // 
            this.tbFileNm.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbFileNm.Location = new System.Drawing.Point(115, 0);
            this.tbFileNm.Name = "tbFileNm";
            this.tbFileNm.Size = new System.Drawing.Size(246, 21);
            this.tbFileNm.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 24);
            this.label7.TabIndex = 19;
            this.label7.Text = "파일명(시작이름)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.UseCompatibleTextRendering = true;
            // 
            // subPan4
            // 
            this.subPan4.Controls.Add(this.dtpUploadTime);
            this.subPan4.Controls.Add(this.rbOneAday);
            this.subPan4.Controls.Add(this.rbRealtime);
            this.subPan4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subPan4.Location = new System.Drawing.Point(252, 33);
            this.subPan4.Name = "subPan4";
            this.subPan4.Size = new System.Drawing.Size(741, 24);
            this.subPan4.TabIndex = 22;
            // 
            // dtpUploadTime
            // 
            this.dtpUploadTime.CustomFormat = "HH:mm";
            this.dtpUploadTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpUploadTime.Enabled = false;
            this.dtpUploadTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUploadTime.Location = new System.Drawing.Point(154, 0);
            this.dtpUploadTime.Name = "dtpUploadTime";
            this.dtpUploadTime.ShowUpDown = true;
            this.dtpUploadTime.Size = new System.Drawing.Size(100, 21);
            this.dtpUploadTime.TabIndex = 5;
            // 
            // rbOneAday
            // 
            this.rbOneAday.AutoSize = true;
            this.rbOneAday.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbOneAday.ForeColor = System.Drawing.Color.White;
            this.rbOneAday.Location = new System.Drawing.Point(59, 0);
            this.rbOneAday.Name = "rbOneAday";
            this.rbOneAday.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.rbOneAday.Size = new System.Drawing.Size(95, 24);
            this.rbOneAday.TabIndex = 2;
            this.rbOneAday.Text = "1회/1일";
            this.rbOneAday.UseVisualStyleBackColor = true;
            this.rbOneAday.CheckedChanged += new System.EventHandler(this.rbRealtime_CheckedChanged);
            // 
            // rbRealtime
            // 
            this.rbRealtime.AutoSize = true;
            this.rbRealtime.Checked = true;
            this.rbRealtime.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbRealtime.ForeColor = System.Drawing.Color.White;
            this.rbRealtime.Location = new System.Drawing.Point(0, 0);
            this.rbRealtime.Name = "rbRealtime";
            this.rbRealtime.Size = new System.Drawing.Size(59, 24);
            this.rbRealtime.TabIndex = 1;
            this.rbRealtime.TabStop = true;
            this.rbRealtime.Text = "실시간";
            this.rbRealtime.UseVisualStyleBackColor = true;
            this.rbRealtime.CheckedChanged += new System.EventHandler(this.rbRealtime_CheckedChanged);
            // 
            // subPan3
            // 
            this.subPan3.Controls.Add(this.dtpUploadToTime);
            this.subPan3.Controls.Add(this.dtpUploadToDt);
            this.subPan3.Controls.Add(this.label13);
            this.subPan3.Controls.Add(this.dtpUploadFromTime);
            this.subPan3.Controls.Add(this.label12);
            this.subPan3.Controls.Add(this.dtpUploadFromDt);
            this.subPan3.Controls.Add(this.label11);
            this.subPan3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subPan3.Location = new System.Drawing.Point(252, 63);
            this.subPan3.Name = "subPan3";
            this.subPan3.Size = new System.Drawing.Size(741, 24);
            this.subPan3.TabIndex = 28;
            // 
            // dtpUploadToTime
            // 
            this.dtpUploadToTime.CustomFormat = "HH:mm";
            this.dtpUploadToTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpUploadToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUploadToTime.Location = new System.Drawing.Point(577, 0);
            this.dtpUploadToTime.Name = "dtpUploadToTime";
            this.dtpUploadToTime.ShowUpDown = true;
            this.dtpUploadToTime.Size = new System.Drawing.Size(100, 21);
            this.dtpUploadToTime.TabIndex = 18;
            // 
            // dtpUploadToDt
            // 
            this.dtpUploadToDt.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpUploadToDt.Location = new System.Drawing.Point(407, 0);
            this.dtpUploadToDt.Name = "dtpUploadToDt";
            this.dtpUploadToDt.Size = new System.Drawing.Size(170, 21);
            this.dtpUploadToDt.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(340, 0);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.label13.Size = new System.Drawing.Size(67, 24);
            this.label13.TabIndex = 16;
            this.label13.Text = "종료";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.UseCompatibleTextRendering = true;
            // 
            // dtpUploadFromTime
            // 
            this.dtpUploadFromTime.CustomFormat = "HH:mm";
            this.dtpUploadFromTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpUploadFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUploadFromTime.Location = new System.Drawing.Point(240, 0);
            this.dtpUploadFromTime.Name = "dtpUploadFromTime";
            this.dtpUploadFromTime.ShowUpDown = true;
            this.dtpUploadFromTime.Size = new System.Drawing.Size(100, 21);
            this.dtpUploadFromTime.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(230, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 24);
            this.label12.TabIndex = 15;
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.UseCompatibleTextRendering = true;
            // 
            // dtpUploadFromDt
            // 
            this.dtpUploadFromDt.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpUploadFromDt.Location = new System.Drawing.Point(60, 0);
            this.dtpUploadFromDt.Name = "dtpUploadFromDt";
            this.dtpUploadFromDt.Size = new System.Drawing.Size(170, 21);
            this.dtpUploadFromDt.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 24);
            this.label11.TabIndex = 12;
            this.label11.Text = "스케쥴";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.UseCompatibleTextRendering = true;
            // 
            // subPan2
            // 
            this.subPan2.Controls.Add(this.rbDeactivate);
            this.subPan2.Controls.Add(this.rbActivate);
            this.subPan2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subPan2.Location = new System.Drawing.Point(252, 93);
            this.subPan2.Name = "subPan2";
            this.subPan2.Size = new System.Drawing.Size(741, 24);
            this.subPan2.TabIndex = 26;
            // 
            // rbDeactivate
            // 
            this.rbDeactivate.AutoSize = true;
            this.rbDeactivate.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbDeactivate.ForeColor = System.Drawing.Color.White;
            this.rbDeactivate.Location = new System.Drawing.Point(59, 0);
            this.rbDeactivate.Name = "rbDeactivate";
            this.rbDeactivate.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.rbDeactivate.Size = new System.Drawing.Size(101, 24);
            this.rbDeactivate.TabIndex = 4;
            this.rbDeactivate.Text = "비활성화";
            this.rbDeactivate.UseVisualStyleBackColor = true;
            // 
            // rbActivate
            // 
            this.rbActivate.AutoSize = true;
            this.rbActivate.Checked = true;
            this.rbActivate.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbActivate.ForeColor = System.Drawing.Color.White;
            this.rbActivate.Location = new System.Drawing.Point(0, 0);
            this.rbActivate.Name = "rbActivate";
            this.rbActivate.Size = new System.Drawing.Size(59, 24);
            this.rbActivate.TabIndex = 3;
            this.rbActivate.TabStop = true;
            this.rbActivate.Text = "활성화";
            this.rbActivate.UseVisualStyleBackColor = true;
            // 
            // subPan1
            // 
            this.subPan1.Controls.Add(this.tbSubFolderNm);
            this.subPan1.Controls.Add(this.btnSearchSubFolder);
            this.subPan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subPan1.Location = new System.Drawing.Point(252, 123);
            this.subPan1.Name = "subPan1";
            this.subPan1.Size = new System.Drawing.Size(741, 24);
            this.subPan1.TabIndex = 27;
            // 
            // tbSubFolderNm
            // 
            this.tbSubFolderNm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSubFolderNm.Location = new System.Drawing.Point(0, 0);
            this.tbSubFolderNm.Name = "tbSubFolderNm";
            this.tbSubFolderNm.Size = new System.Drawing.Size(711, 21);
            this.tbSubFolderNm.TabIndex = 20;
            // 
            // btnSearchSubFolder
            // 
            this.btnSearchSubFolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearchSubFolder.FlatAppearance.BorderSize = 0;
            this.btnSearchSubFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchSubFolder.Image = global::sdms_connector.Properties.Resources.icon_search_folder;
            this.btnSearchSubFolder.Location = new System.Drawing.Point(711, 0);
            this.btnSearchSubFolder.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearchSubFolder.Name = "btnSearchSubFolder";
            this.btnSearchSubFolder.Size = new System.Drawing.Size(30, 24);
            this.btnSearchSubFolder.TabIndex = 21;
            this.btnSearchSubFolder.UseVisualStyleBackColor = true;
            this.btnSearchSubFolder.Click += new System.EventHandler(this.btnSearchSubFolder_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(252, 153);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(741, 154);
            this.flowLayoutPanel1.TabIndex = 29;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(172)))), ((int)(((byte)(195)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDelete.Location = new System.Drawing.Point(653, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 27);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(155)))), ((int)(((byte)(221)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSave.Location = new System.Drawing.Point(562, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 27);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 20);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(1026, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "스케쥴 정보";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScheduleMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 707);
            this.Controls.Add(this.panBody);
            this.Controls.Add(this.panScheduleList);
            this.Controls.Add(this.panTitle);
            this.Name = "ScheduleMng";
            this.Text = "ScheduleMng";
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.panScheduleList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.panBody.ResumeLayout(false);
            this.gbScheduleInfo.ResumeLayout(false);
            this.tlpScheduleInfo.ResumeLayout(false);
            this.subPan5.ResumeLayout(false);
            this.subPan5.PerformLayout();
            this.subPan4.ResumeLayout(false);
            this.subPan4.PerformLayout();
            this.subPan3.ResumeLayout(false);
            this.subPan2.ResumeLayout(false);
            this.subPan2.PerformLayout();
            this.subPan1.ResumeLayout(false);
            this.subPan1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.Panel panScheduleList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Panel panBody;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbScheduleInfo;
        private System.Windows.Forms.TableLayoutPanel tlpScheduleInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel subPan4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel subPan5;
        private System.Windows.Forms.Panel subPan2;
        private System.Windows.Forms.Panel subPan1;
        private System.Windows.Forms.Panel subPan3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFileExt;
        private System.Windows.Forms.TextBox tbFileNm;
        private System.Windows.Forms.RadioButton rbRealtime;
        private System.Windows.Forms.RadioButton rbOneAday;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rbDeactivate;
        private System.Windows.Forms.RadioButton rbActivate;
        private System.Windows.Forms.TextBox tbSubFolderNm;
        private System.Windows.Forms.Button btnSearchSubFolder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpUploadTime;
        private System.Windows.Forms.DateTimePicker dtpUploadFromDt;
        private System.Windows.Forms.DateTimePicker dtpUploadFromTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpUploadToTime;
        private System.Windows.Forms.DateTimePicker dtpUploadToDt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox hiddenScheduleSeq;
        private System.Windows.Forms.TextBox hiddenProjCd;
        private System.Windows.Forms.TextBox hiddenSubFolderCd;
        private System.Windows.Forms.TextBox hiddenFolderCd;
        private System.Windows.Forms.Button btnNew;
    }
}