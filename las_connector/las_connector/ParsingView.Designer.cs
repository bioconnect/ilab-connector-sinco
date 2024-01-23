namespace sdms_connector
{
    partial class ParsingView
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
            this.panTitle = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panBody = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.wbParsing = new System.Windows.Forms.WebBrowser();
            this.panTitle.SuspendLayout();
            this.panBody.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.panTitle.Controls.Add(this.label3);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(1790, 46);
            this.panTitle.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Newtext Bk BT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.label3.Size = new System.Drawing.Size(118, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "Parsing View";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panBody
            // 
            this.panBody.BackColor = System.Drawing.Color.White;
            this.panBody.Controls.Add(this.groupBox1);
            this.panBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBody.Location = new System.Drawing.Point(0, 46);
            this.panBody.Margin = new System.Windows.Forms.Padding(0);
            this.panBody.Name = "panBody";
            this.panBody.Padding = new System.Windows.Forms.Padding(9, 0, 9, 10);
            this.panBody.Size = new System.Drawing.Size(1790, 1015);
            this.panBody.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.wbParsing);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(9, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(1772, 1005);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // wbParsing
            // 
            this.wbParsing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbParsing.Location = new System.Drawing.Point(5, 30);
            this.wbParsing.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.wbParsing.MinimumSize = new System.Drawing.Size(31, 35);
            this.wbParsing.Name = "wbParsing";
            this.wbParsing.Size = new System.Drawing.Size(1762, 970);
            this.wbParsing.TabIndex = 0;
            // 
            // ParsingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1790, 1061);
            this.Controls.Add(this.panBody);
            this.Controls.Add(this.panTitle);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ParsingView";
            this.Text = "Parsing View";
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.panBody.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panBody;
        private System.Windows.Forms.WebBrowser wbParsing;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}