namespace sdms_connector
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panMain = new System.Windows.Forms.Panel();
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDataHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainClose = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Margin = new System.Windows.Forms.Padding(0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(1447, 1092);
            this.panMain.TabIndex = 0;
            // 
            // cmsMain
            // 
            this.cmsMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDataHistory,
            this.tsmiMainClose});
            this.cmsMain.Name = "contextMenuStrip1";
            this.cmsMain.Size = new System.Drawing.Size(223, 68);
            // 
            // tsmiDataHistory
            // 
            this.tsmiDataHistory.Enabled = false;
            this.tsmiDataHistory.Name = "tsmiDataHistory";
            this.tsmiDataHistory.Size = new System.Drawing.Size(222, 32);
            this.tsmiDataHistory.Text = "데이터 전송 이력";
            this.tsmiDataHistory.Click += new System.EventHandler(this.tsmiDataHistory_Click);
            // 
            // tsmiMainClose
            // 
            this.tsmiMainClose.Name = "tsmiMainClose";
            this.tsmiMainClose.Size = new System.Drawing.Size(222, 32);
            this.tsmiMainClose.Text = "종료";
            this.tsmiMainClose.Click += new System.EventHandler(this.tsmiMainClose_Click);
            // 
            // trayMain
            // 
            this.trayMain.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayMain.BalloonTipText = "SDMS Connector가 실행중입니다.";
            this.trayMain.BalloonTipTitle = "SDMS Connector";
            this.trayMain.ContextMenuStrip = this.cmsMain;
            this.trayMain.Icon = ((System.Drawing.Icon)(resources.GetObject("trayMain.Icon")));
            this.trayMain.Text = "SDMS Connector";
            this.trayMain.Visible = true;
            this.trayMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayMain_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1447, 1092);
            this.Controls.Add(this.panMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "SDMS Connector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainClose;
        private System.Windows.Forms.NotifyIcon trayMain;
    }
}