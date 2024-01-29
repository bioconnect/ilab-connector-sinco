namespace sdms_connector
{
    partial class SubFolderPop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubFolderPop));
            this.tvProject = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panTitle = new System.Windows.Forms.Panel();
            this.hiddenProjCd = new System.Windows.Forms.TextBox();
            this.hiddenSubFolderCd = new System.Windows.Forms.TextBox();
            this.hiddenFolderCd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panBody = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.panBodySub = new System.Windows.Forms.Panel();
            this.tbSubFolderNm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panTitle.SuspendLayout();
            this.panBody.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panBodySub.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvProject
            // 
            this.tvProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.tvProject.ImageIndex = 0;
            this.tvProject.ImageList = this.imageList1;
            this.tvProject.Location = new System.Drawing.Point(10, 40);
            this.tvProject.Name = "tvProject";
            this.tvProject.SelectedImageIndex = 0;
            this.tvProject.Size = new System.Drawing.Size(345, 245);
            this.tvProject.TabIndex = 0;
            this.tvProject.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProject_AfterSelect);
            this.tvProject.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvProject_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon_close_folder.png");
            this.imageList1.Images.SetKeyName(1, "icon_open_folder.png");
            this.imageList1.Images.SetKeyName(2, "icon_file_pdf.png");
            this.imageList1.Images.SetKeyName(3, "icon_file_raw.png");
            this.imageList1.Images.SetKeyName(4, "icon_file_text.png");
            // 
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.panTitle.Controls.Add(this.hiddenProjCd);
            this.panTitle.Controls.Add(this.hiddenSubFolderCd);
            this.panTitle.Controls.Add(this.hiddenFolderCd);
            this.panTitle.Controls.Add(this.label1);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(365, 26);
            this.panTitle.TabIndex = 8;
            // 
            // hiddenProjCd
            // 
            this.hiddenProjCd.Location = new System.Drawing.Point(87, 3);
            this.hiddenProjCd.Name = "hiddenProjCd";
            this.hiddenProjCd.Size = new System.Drawing.Size(80, 21);
            this.hiddenProjCd.TabIndex = 34;
            this.hiddenProjCd.Text = "projCd";
            this.hiddenProjCd.Visible = false;
            // 
            // hiddenSubFolderCd
            // 
            this.hiddenSubFolderCd.Location = new System.Drawing.Point(257, 3);
            this.hiddenSubFolderCd.Name = "hiddenSubFolderCd";
            this.hiddenSubFolderCd.Size = new System.Drawing.Size(92, 21);
            this.hiddenSubFolderCd.TabIndex = 36;
            this.hiddenSubFolderCd.Text = "subFolderCd";
            this.hiddenSubFolderCd.Visible = false;
            // 
            // hiddenFolderCd
            // 
            this.hiddenFolderCd.Location = new System.Drawing.Point(173, 3);
            this.hiddenFolderCd.Name = "hiddenFolderCd";
            this.hiddenFolderCd.Size = new System.Drawing.Size(78, 21);
            this.hiddenFolderCd.TabIndex = 35;
            this.hiddenFolderCd.Text = "folderCd";
            this.hiddenFolderCd.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Newtext Bk BT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "서브폴더";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panBody
            // 
            this.panBody.BackColor = System.Drawing.Color.White;
            this.panBody.Controls.Add(this.flowLayoutPanel1);
            this.panBody.Controls.Add(this.panBodySub);
            this.panBody.Controls.Add(this.tvProject);
            this.panBody.Controls.Add(this.label2);
            this.panBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBody.Location = new System.Drawing.Point(0, 26);
            this.panBody.Margin = new System.Windows.Forms.Padding(0);
            this.panBody.Name = "panBody";
            this.panBody.Padding = new System.Windows.Forms.Padding(10);
            this.panBody.Size = new System.Drawing.Size(365, 383);
            this.panBody.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnConfirm);
            this.flowLayoutPanel1.Controls.Add(this.btnCancle);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 321);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(80, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(345, 52);
            this.flowLayoutPanel1.TabIndex = 30;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(155)))), ((int)(((byte)(221)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.Window;
            this.btnConfirm.Location = new System.Drawing.Point(83, 13);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(85, 27);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "확인";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(172)))), ((int)(((byte)(195)))));
            this.btnCancle.FlatAppearance.BorderSize = 0;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCancle.Location = new System.Drawing.Point(174, 13);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(85, 27);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "취소";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // panBodySub
            // 
            this.panBodySub.Controls.Add(this.tbSubFolderNm);
            this.panBodySub.Controls.Add(this.label3);
            this.panBodySub.Dock = System.Windows.Forms.DockStyle.Top;
            this.panBodySub.Location = new System.Drawing.Point(10, 285);
            this.panBodySub.Name = "panBodySub";
            this.panBodySub.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panBodySub.Size = new System.Drawing.Size(345, 36);
            this.panBodySub.TabIndex = 2;
            // 
            // tbSubFolderNm
            // 
            this.tbSubFolderNm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSubFolderNm.Location = new System.Drawing.Point(94, 10);
            this.tbSubFolderNm.Name = "tbSubFolderNm";
            this.tbSubFolderNm.Size = new System.Drawing.Size(251, 21);
            this.tbSubFolderNm.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Newtext Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(0, 10);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.label3.Size = new System.Drawing.Size(94, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "서브폴더: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Newtext Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "서브폴더를 선택하세요.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SubFolderPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 409);
            this.Controls.Add(this.panBody);
            this.Controls.Add(this.panTitle);
            this.Name = "SubFolderPop";
            this.Text = "SubFolderPop";
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.panBody.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panBodySub.ResumeLayout(false);
            this.panBodySub.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvProject;
        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panBody;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panBodySub;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSubFolderNm;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.TextBox hiddenSubFolderCd;
        private System.Windows.Forms.TextBox hiddenFolderCd;
        private System.Windows.Forms.TextBox hiddenProjCd;
        private System.Windows.Forms.ImageList imageList1;
    }
}