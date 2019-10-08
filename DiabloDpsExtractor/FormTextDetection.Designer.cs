namespace DiabloDpsExtractor
{
    partial class FormTextDetection
    {/// <summary>
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputBox = new System.Windows.Forms.PictureBox();
            this.contrastBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1429, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startRecordingToolStripMenuItem,
            this.openVideoToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startRecordingToolStripMenuItem
            // 
            this.startRecordingToolStripMenuItem.Name = "startRecordingToolStripMenuItem";
            this.startRecordingToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.startRecordingToolStripMenuItem.Text = "Start Recording Screen";
            this.startRecordingToolStripMenuItem.Click += new System.EventHandler(this.startStripMenuItem_Click);
            // 
            // openVideoToolStripMenuItem
            // 
            this.openVideoToolStripMenuItem.Name = "openVideoToolStripMenuItem";
            this.openVideoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.openVideoToolStripMenuItem.Text = "Open Video...";
            this.openVideoToolStripMenuItem.Click += new System.EventHandler(this.OpenVideoToolStripMenuItem_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(375, 40);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(1042, 876);
            this.outputBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outputBox.TabIndex = 6;
            this.outputBox.TabStop = false;
            // 
            // contrastBox
            // 
            this.contrastBox.Location = new System.Drawing.Point(12, 40);
            this.contrastBox.Name = "contrastBox";
            this.contrastBox.Size = new System.Drawing.Size(357, 341);
            this.contrastBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.contrastBox.TabIndex = 5;
            this.contrastBox.TabStop = false;
            // 
            // FormTextDetection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 952);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.contrastBox);
            this.Name = "FormTextDetection";
            this.Text = "FormTextDetection";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startRecordingToolStripMenuItem;
        private System.Windows.Forms.PictureBox outputBox;
        private System.Windows.Forms.PictureBox contrastBox;
        private System.Windows.Forms.ToolStripMenuItem openVideoToolStripMenuItem;
    }
}

