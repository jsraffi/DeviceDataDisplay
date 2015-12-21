namespace DeviceDataDisplay
{
    partial class DeviceDataDisplay
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
            this.toolstripmenu = new System.Windows.Forms.ToolStrip();
            this.lblShowChannels = new System.Windows.Forms.ToolStripLabel();
            this.ShowNoOfChannels = new System.Windows.Forms.ToolStripComboBox();
            this.toolstripmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolstripmenu
            // 
            this.toolstripmenu.BackColor = System.Drawing.Color.RoyalBlue;
            this.toolstripmenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolstripmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblShowChannels,
            this.ShowNoOfChannels});
            this.toolstripmenu.Location = new System.Drawing.Point(0, 0);
            this.toolstripmenu.Name = "toolstripmenu";
            this.toolstripmenu.Size = new System.Drawing.Size(767, 28);
            this.toolstripmenu.TabIndex = 0;
            // 
            // lblShowChannels
            // 
            this.lblShowChannels.Name = "lblShowChannels";
            this.lblShowChannels.Size = new System.Drawing.Size(112, 25);
            this.lblShowChannels.Text = "Select Channels";
            // 
            // ShowNoOfChannels
            // 
            this.ShowNoOfChannels.AccessibleName = "Select Channels";
            this.ShowNoOfChannels.MaxDropDownItems = 32;
            this.ShowNoOfChannels.Name = "ShowNoOfChannels";
            this.ShowNoOfChannels.Size = new System.Drawing.Size(121, 28);
            this.ShowNoOfChannels.SelectedIndexChanged += new System.EventHandler(this.ShowNoOfChannels_SelectedIndexChanged);
            // 
            // DeviceDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(767, 285);
            this.Controls.Add(this.toolstripmenu);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "DeviceDataDisplay";
            this.RightToLeftLayout = true;
            this.Text = "Devices Data Display";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DeviceDataDisplay_Load);
            this.toolstripmenu.ResumeLayout(false);
            this.toolstripmenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolstripmenu;
        private System.Windows.Forms.ToolStripComboBox ShowNoOfChannels;
        private System.Windows.Forms.ToolStripLabel lblShowChannels;
    }
}

