namespace LASConnector
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
            this.label5 = new System.Windows.Forms.Label();
            this.hiddenScheduleSeq = new System.Windows.Forms.TextBox();
            this.panScheduleList = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tbScheduleNm = new System.Windows.Forms.TextBox();
            this.panBody = new System.Windows.Forms.Panel();
            this.tlpScheduleInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.subPan2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.rbDeactivate = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.rbActivate = new System.Windows.Forms.RadioButton();
            this.subPan3 = new System.Windows.Forms.Panel();
            this.dtpUploadToTime = new System.Windows.Forms.DateTimePicker();
            this.dtpUploadToDt = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpUploadFromTime = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpUploadFromDt = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.subPan4 = new System.Windows.Forms.Panel();
            this.dtpUploadTime = new System.Windows.Forms.DateTimePicker();
            this.rbRealtime = new System.Windows.Forms.RadioButton();
            this.rbOneAday = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbDevInfo = new System.Windows.Forms.ComboBox();
            this.subPan1 = new System.Windows.Forms.Panel();
            this.tbDevWatchFolder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panTitle.SuspendLayout();
            this.panScheduleList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.panBody.SuspendLayout();
            this.tlpScheduleInfo.SuspendLayout();
            this.subPan2.SuspendLayout();
            this.subPan3.SuspendLayout();
            this.subPan4.SuspendLayout();
            this.subPan1.SuspendLayout();
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
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panTitle.Controls.Add(this.label5);
            this.panTitle.Controls.Add(this.label1);
            this.panTitle.Controls.Add(this.hiddenScheduleSeq);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.ForeColor = System.Drawing.Color.White;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(1398, 47);
            this.panTitle.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(0, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(32, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(1398, 1);
            this.label5.TabIndex = 31;
            this.label5.Text = "클라이언트 목록";
            // 
            // hiddenScheduleSeq
            // 
            this.hiddenScheduleSeq.Location = new System.Drawing.Point(232, 30);
            this.hiddenScheduleSeq.Margin = new System.Windows.Forms.Padding(5);
            this.hiddenScheduleSeq.Name = "hiddenScheduleSeq";
            this.hiddenScheduleSeq.Size = new System.Drawing.Size(303, 28);
            this.hiddenScheduleSeq.TabIndex = 30;
            this.hiddenScheduleSeq.Text = "0";
            this.hiddenScheduleSeq.Visible = false;
            // 
            // panScheduleList
            // 
            this.panScheduleList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panScheduleList.Controls.Add(this.label3);
            this.panScheduleList.Controls.Add(this.btnNew);
            this.panScheduleList.Controls.Add(this.dgvSchedule);
            this.panScheduleList.Controls.Add(this.label2);
            this.panScheduleList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panScheduleList.Location = new System.Drawing.Point(0, 47);
            this.panScheduleList.Margin = new System.Windows.Forms.Padding(0);
            this.panScheduleList.Name = "panScheduleList";
            this.panScheduleList.Padding = new System.Windows.Forms.Padding(29, 7, 29, 30);
            this.panScheduleList.Size = new System.Drawing.Size(1398, 419);
            this.panScheduleList.TabIndex = 8;
            this.panScheduleList.Paint += new System.Windows.Forms.PaintEventHandler(this.panScheduleList_Paint);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(29, 388);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(1340, 1);
            this.label3.TabIndex = 0;
            this.label3.Text = "스케쥴정보";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(156)))), ((int)(((byte)(136)))));
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.SystemColors.Window;
            this.btnNew.Location = new System.Drawing.Point(1232, 7);
            this.btnNew.Margin = new System.Windows.Forms.Padding(5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(136, 29);
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
            this.dgvSchedule.Location = new System.Drawing.Point(29, 51);
            this.dgvSchedule.Margin = new System.Windows.Forms.Padding(21, 16, 21, 23);
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
            this.dgvSchedule.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.dgvSchedule.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSchedule.RowTemplate.Height = 23;
            this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedule.Size = new System.Drawing.Size(1340, 314);
            this.dgvSchedule.TabIndex = 10;
            this.dgvSchedule.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedule_CellClick);
            this.dgvSchedule.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSchedule_DataBindingComplete);
            this.dgvSchedule.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvSchedule_RowPostPaint);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(1340, 44);
            this.label2.TabIndex = 0;
            this.label2.Text = "스케쥴목록";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbScheduleNm
            // 
            this.tbScheduleNm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbScheduleNm.Location = new System.Drawing.Point(211, 5);
            this.tbScheduleNm.Margin = new System.Windows.Forms.Padding(5);
            this.tbScheduleNm.Name = "tbScheduleNm";
            this.tbScheduleNm.Size = new System.Drawing.Size(1124, 28);
            this.tbScheduleNm.TabIndex = 18;
            // 
            // panBody
            // 
            this.panBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panBody.Controls.Add(this.tlpScheduleInfo);
            this.panBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBody.ForeColor = System.Drawing.Color.White;
            this.panBody.Location = new System.Drawing.Point(0, 466);
            this.panBody.Margin = new System.Windows.Forms.Padding(0);
            this.panBody.Name = "panBody";
            this.panBody.Padding = new System.Windows.Forms.Padding(29, 7, 29, 30);
            this.panBody.Size = new System.Drawing.Size(1398, 444);
            this.panBody.TabIndex = 9;
            // 
            // tlpScheduleInfo
            // 
            this.tlpScheduleInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.tlpScheduleInfo.ColumnCount = 2;
            this.tlpScheduleInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.39179F));
            this.tlpScheduleInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.60821F));
            this.tlpScheduleInfo.Controls.Add(this.tbScheduleNm, 1, 0);
            this.tlpScheduleInfo.Controls.Add(this.label9, 0, 4);
            this.tlpScheduleInfo.Controls.Add(this.label10, 0, 3);
            this.tlpScheduleInfo.Controls.Add(this.label6, 0, 1);
            this.tlpScheduleInfo.Controls.Add(this.label7, 0, 2);
            this.tlpScheduleInfo.Controls.Add(this.subPan2, 1, 5);
            this.tlpScheduleInfo.Controls.Add(this.subPan3, 1, 4);
            this.tlpScheduleInfo.Controls.Add(this.subPan4, 1, 3);
            this.tlpScheduleInfo.Controls.Add(this.flowLayoutPanel1, 1, 6);
            this.tlpScheduleInfo.Controls.Add(this.cbDevInfo, 1, 1);
            this.tlpScheduleInfo.Controls.Add(this.subPan1, 1, 2);
            this.tlpScheduleInfo.Controls.Add(this.label8, 0, 0);
            this.tlpScheduleInfo.Controls.Add(this.label4, 0, 5);
            this.tlpScheduleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpScheduleInfo.Enabled = false;
            this.tlpScheduleInfo.Location = new System.Drawing.Point(29, 7);
            this.tlpScheduleInfo.Margin = new System.Windows.Forms.Padding(5);
            this.tlpScheduleInfo.Name = "tlpScheduleInfo";
            this.tlpScheduleInfo.RowCount = 7;
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tlpScheduleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpScheduleInfo.Size = new System.Drawing.Size(1340, 407);
            this.tlpScheduleInfo.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 179);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 42);
            this.label9.TabIndex = 11;
            this.label9.Text = "업로드기간";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.UseCompatibleTextRendering = true;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label10.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 132);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(205, 44);
            this.label10.TabIndex = 12;
            this.label10.Text = "업로드시점";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 44);
            this.label6.TabIndex = 30;
            this.label6.Text = "장비명";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 88);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 44);
            this.label7.TabIndex = 31;
            this.label7.Text = "장비감시폴더";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.UseCompatibleTextRendering = true;
            // 
            // subPan2
            // 
            this.subPan2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.subPan2.Controls.Add(this.btnSave);
            this.subPan2.Controls.Add(this.rbDeactivate);
            this.subPan2.Controls.Add(this.btnDelete);
            this.subPan2.Controls.Add(this.rbActivate);
            this.subPan2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subPan2.Location = new System.Drawing.Point(211, 226);
            this.subPan2.Margin = new System.Windows.Forms.Padding(5);
            this.subPan2.Name = "subPan2";
            this.subPan2.Size = new System.Drawing.Size(1124, 73);
            this.subPan2.TabIndex = 26;
            this.subPan2.Paint += new System.Windows.Forms.PaintEventHandler(this.subPan2_Paint);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(155)))), ((int)(((byte)(221)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSave.Location = new System.Drawing.Point(993, 28);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 41);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rbDeactivate
            // 
            this.rbDeactivate.AutoSize = true;
            this.rbDeactivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.rbDeactivate.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbDeactivate.ForeColor = System.Drawing.Color.White;
            this.rbDeactivate.Location = new System.Drawing.Point(87, 0);
            this.rbDeactivate.Margin = new System.Windows.Forms.Padding(5);
            this.rbDeactivate.Name = "rbDeactivate";
            this.rbDeactivate.Padding = new System.Windows.Forms.Padding(42, 0, 0, 0);
            this.rbDeactivate.Size = new System.Drawing.Size(147, 73);
            this.rbDeactivate.TabIndex = 4;
            this.rbDeactivate.Text = "비활성화";
            this.rbDeactivate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(172)))), ((int)(((byte)(195)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDelete.Location = new System.Drawing.Point(863, 28);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 41);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // rbActivate
            // 
            this.rbActivate.AutoSize = true;
            this.rbActivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.rbActivate.Checked = true;
            this.rbActivate.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbActivate.ForeColor = System.Drawing.Color.White;
            this.rbActivate.Location = new System.Drawing.Point(0, 0);
            this.rbActivate.Margin = new System.Windows.Forms.Padding(5);
            this.rbActivate.Name = "rbActivate";
            this.rbActivate.Size = new System.Drawing.Size(87, 73);
            this.rbActivate.TabIndex = 3;
            this.rbActivate.TabStop = true;
            this.rbActivate.Text = "활성화";
            this.rbActivate.UseVisualStyleBackColor = false;
            // 
            // subPan3
            // 
            this.subPan3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.subPan3.Controls.Add(this.dtpUploadToTime);
            this.subPan3.Controls.Add(this.dtpUploadToDt);
            this.subPan3.Controls.Add(this.label13);
            this.subPan3.Controls.Add(this.dtpUploadFromTime);
            this.subPan3.Controls.Add(this.label12);
            this.subPan3.Controls.Add(this.dtpUploadFromDt);
            this.subPan3.Controls.Add(this.label11);
            this.subPan3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subPan3.Location = new System.Drawing.Point(211, 184);
            this.subPan3.Margin = new System.Windows.Forms.Padding(5);
            this.subPan3.Name = "subPan3";
            this.subPan3.Size = new System.Drawing.Size(1124, 32);
            this.subPan3.TabIndex = 28;
            // 
            // dtpUploadToTime
            // 
            this.dtpUploadToTime.CustomFormat = "HH:mm";
            this.dtpUploadToTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpUploadToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUploadToTime.Location = new System.Drawing.Point(821, 0);
            this.dtpUploadToTime.Margin = new System.Windows.Forms.Padding(5);
            this.dtpUploadToTime.Name = "dtpUploadToTime";
            this.dtpUploadToTime.ShowUpDown = true;
            this.dtpUploadToTime.Size = new System.Drawing.Size(142, 28);
            this.dtpUploadToTime.TabIndex = 18;
            // 
            // dtpUploadToDt
            // 
            this.dtpUploadToDt.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpUploadToDt.Location = new System.Drawing.Point(579, 0);
            this.dtpUploadToDt.Margin = new System.Windows.Forms.Padding(5);
            this.dtpUploadToDt.Name = "dtpUploadToDt";
            this.dtpUploadToDt.Size = new System.Drawing.Size(242, 28);
            this.dtpUploadToDt.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(484, 0);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(42, 0, 0, 0);
            this.label13.Size = new System.Drawing.Size(95, 32);
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
            this.dtpUploadFromTime.Location = new System.Drawing.Point(342, 0);
            this.dtpUploadFromTime.Margin = new System.Windows.Forms.Padding(5);
            this.dtpUploadFromTime.Name = "dtpUploadFromTime";
            this.dtpUploadFromTime.ShowUpDown = true;
            this.dtpUploadFromTime.Size = new System.Drawing.Size(142, 28);
            this.dtpUploadFromTime.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.label12.Location = new System.Drawing.Point(327, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 32);
            this.label12.TabIndex = 15;
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.UseCompatibleTextRendering = true;
            // 
            // dtpUploadFromDt
            // 
            this.dtpUploadFromDt.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpUploadFromDt.Location = new System.Drawing.Point(85, 0);
            this.dtpUploadFromDt.Margin = new System.Windows.Forms.Padding(5);
            this.dtpUploadFromDt.Name = "dtpUploadFromDt";
            this.dtpUploadFromDt.Size = new System.Drawing.Size(242, 28);
            this.dtpUploadFromDt.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 32);
            this.label11.TabIndex = 12;
            this.label11.Text = "시작";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.UseCompatibleTextRendering = true;
            // 
            // subPan4
            // 
            this.subPan4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.subPan4.Controls.Add(this.dtpUploadTime);
            this.subPan4.Controls.Add(this.rbRealtime);
            this.subPan4.Controls.Add(this.rbOneAday);
            this.subPan4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subPan4.Location = new System.Drawing.Point(211, 137);
            this.subPan4.Margin = new System.Windows.Forms.Padding(5);
            this.subPan4.Name = "subPan4";
            this.subPan4.Size = new System.Drawing.Size(1124, 37);
            this.subPan4.TabIndex = 22;
            this.subPan4.Paint += new System.Windows.Forms.PaintEventHandler(this.subPan4_Paint);
            // 
            // dtpUploadTime
            // 
            this.dtpUploadTime.CustomFormat = "HH:mm";
            this.dtpUploadTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpUploadTime.Enabled = false;
            this.dtpUploadTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUploadTime.Location = new System.Drawing.Point(97, 0);
            this.dtpUploadTime.Margin = new System.Windows.Forms.Padding(5);
            this.dtpUploadTime.Name = "dtpUploadTime";
            this.dtpUploadTime.ShowUpDown = true;
            this.dtpUploadTime.Size = new System.Drawing.Size(142, 28);
            this.dtpUploadTime.TabIndex = 5;
            // 
            // rbRealtime
            // 
            this.rbRealtime.Location = new System.Drawing.Point(248, 4);
            this.rbRealtime.Margin = new System.Windows.Forms.Padding(4);
            this.rbRealtime.Name = "rbRealtime";
            this.rbRealtime.Size = new System.Drawing.Size(130, 29);
            this.rbRealtime.TabIndex = 6;
            this.rbRealtime.Text = "실시간";
            // 
            // rbOneAday
            // 
            this.rbOneAday.AutoSize = true;
            this.rbOneAday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.rbOneAday.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbOneAday.ForeColor = System.Drawing.Color.White;
            this.rbOneAday.Location = new System.Drawing.Point(0, 0);
            this.rbOneAday.Margin = new System.Windows.Forms.Padding(5);
            this.rbOneAday.Name = "rbOneAday";
            this.rbOneAday.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbOneAday.Size = new System.Drawing.Size(97, 37);
            this.rbOneAday.TabIndex = 2;
            this.rbOneAday.Text = "1회/1일";
            this.rbOneAday.UseVisualStyleBackColor = false;
            this.rbOneAday.CheckedChanged += new System.EventHandler(this.rbRealtime_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(211, 309);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1124, 93);
            this.flowLayoutPanel1.TabIndex = 29;
            // 
            // cbDevInfo
            // 
            this.cbDevInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDevInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevInfo.FormattingEnabled = true;
            this.cbDevInfo.Location = new System.Drawing.Point(211, 49);
            this.cbDevInfo.Margin = new System.Windows.Forms.Padding(5);
            this.cbDevInfo.Name = "cbDevInfo";
            this.cbDevInfo.Size = new System.Drawing.Size(1124, 26);
            this.cbDevInfo.TabIndex = 34;
            this.cbDevInfo.SelectedIndexChanged += new System.EventHandler(this.cbDevInfo_SelectedIndexChanged);
            // 
            // subPan1
            // 
            this.subPan1.Controls.Add(this.tbDevWatchFolder);
            this.subPan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subPan1.Location = new System.Drawing.Point(211, 93);
            this.subPan1.Margin = new System.Windows.Forms.Padding(5);
            this.subPan1.Name = "subPan1";
            this.subPan1.Size = new System.Drawing.Size(1124, 34);
            this.subPan1.TabIndex = 35;
            // 
            // tbDevWatchFolder
            // 
            this.tbDevWatchFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDevWatchFolder.Enabled = false;
            this.tbDevWatchFolder.Location = new System.Drawing.Point(0, 0);
            this.tbDevWatchFolder.Margin = new System.Windows.Forms.Padding(5);
            this.tbDevWatchFolder.Name = "tbDevWatchFolder";
            this.tbDevWatchFolder.Size = new System.Drawing.Size(1124, 28);
            this.tbDevWatchFolder.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 44);
            this.label8.TabIndex = 10;
            this.label8.Text = "스케쥴명";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.UseCompatibleTextRendering = true;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 221);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 83);
            this.label4.TabIndex = 23;
            this.label4.Text = "활성화여부";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.UseCompatibleTextRendering = true;
            // 
            // ScheduleMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 910);
            this.Controls.Add(this.panBody);
            this.Controls.Add(this.panScheduleList);
            this.Controls.Add(this.panTitle);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ScheduleMng";
            this.Text = "ScheduleMng";
            this.Load += new System.EventHandler(this.ScheduleMng_Load);
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.panScheduleList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.panBody.ResumeLayout(false);
            this.tlpScheduleInfo.ResumeLayout(false);
            this.tlpScheduleInfo.PerformLayout();
            this.subPan2.ResumeLayout(false);
            this.subPan2.PerformLayout();
            this.subPan3.ResumeLayout(false);
            this.subPan4.ResumeLayout(false);
            this.subPan4.PerformLayout();
            this.subPan1.ResumeLayout(false);
            this.subPan1.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tlpScheduleInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel subPan4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel subPan2;
        private System.Windows.Forms.Panel subPan3;
        private System.Windows.Forms.TextBox tbScheduleNm;
        private System.Windows.Forms.RadioButton rbRealtime;
        private System.Windows.Forms.RadioButton rbOneAday;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rbDeactivate;
        private System.Windows.Forms.RadioButton rbActivate;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbDevInfo;
        private System.Windows.Forms.Panel subPan1;
        private System.Windows.Forms.TextBox tbDevWatchFolder;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label5;
    }
}