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
            this.minThresholdTrackbar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxThresholdTrackbar = new System.Windows.Forms.TrackBar();
            this.minThresholdValue = new System.Windows.Forms.Label();
            this.maxThresholdValue = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minThresholdTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxThresholdTrackbar)).BeginInit();
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
            // minThresholdTrackbar
            // 
            this.minThresholdTrackbar.LargeChange = 10;
            this.minThresholdTrackbar.Location = new System.Drawing.Point(12, 419);
            this.minThresholdTrackbar.Maximum = 255;
            this.minThresholdTrackbar.Name = "minThresholdTrackbar";
            this.minThresholdTrackbar.Size = new System.Drawing.Size(357, 45);
            this.minThresholdTrackbar.SmallChange = 5;
            this.minThresholdTrackbar.TabIndex = 7;
            this.minThresholdTrackbar.Value = 10;
            this.minThresholdTrackbar.Visible = false;
            this.minThresholdTrackbar.Scroll += new System.EventHandler(this.thresholdBinaryTrackbar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "MinThreshold";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 465);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "MaxThreshold";
            this.label2.Visible = false;
            // 
            // maxThresholdTrackbar
            // 
            this.maxThresholdTrackbar.LargeChange = 10;
            this.maxThresholdTrackbar.Location = new System.Drawing.Point(15, 481);
            this.maxThresholdTrackbar.Maximum = 255;
            this.maxThresholdTrackbar.Name = "maxThresholdTrackbar";
            this.maxThresholdTrackbar.Size = new System.Drawing.Size(357, 45);
            this.maxThresholdTrackbar.SmallChange = 5;
            this.maxThresholdTrackbar.TabIndex = 9;
            this.maxThresholdTrackbar.Value = 10;
            this.maxThresholdTrackbar.Visible = false;
            this.maxThresholdTrackbar.Scroll += new System.EventHandler(this.maxThresholdTrackbar_Scroll);
            // 
            // minThresholdValue
            // 
            this.minThresholdValue.AutoSize = true;
            this.minThresholdValue.Location = new System.Drawing.Point(334, 403);
            this.minThresholdValue.Name = "minThresholdValue";
            this.minThresholdValue.Size = new System.Drawing.Size(35, 13);
            this.minThresholdValue.TabIndex = 11;
            this.minThresholdValue.Text = "label3";
            this.minThresholdValue.Visible = false;
            // 
            // maxThresholdValue
            // 
            this.maxThresholdValue.AutoSize = true;
            this.maxThresholdValue.Location = new System.Drawing.Point(334, 467);
            this.maxThresholdValue.Name = "maxThresholdValue";
            this.maxThresholdValue.Size = new System.Drawing.Size(35, 13);
            this.maxThresholdValue.TabIndex = 12;
            this.maxThresholdValue.Text = "label4";
            this.maxThresholdValue.Visible = false;
            // 
            // FormTextDetection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 952);
            this.Controls.Add(this.maxThresholdValue);
            this.Controls.Add(this.minThresholdValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxThresholdTrackbar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minThresholdTrackbar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.contrastBox);
            this.Name = "FormTextDetection";
            this.Text = "FormTextDetection";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minThresholdTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxThresholdTrackbar)).EndInit();
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
        private System.Windows.Forms.TrackBar minThresholdTrackbar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar maxThresholdTrackbar;
        private System.Windows.Forms.Label minThresholdValue;
        private System.Windows.Forms.Label maxThresholdValue;
    }
}

