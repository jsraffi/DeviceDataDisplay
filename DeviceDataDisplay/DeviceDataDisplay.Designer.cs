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
            this.mainmenuStrip = new System.Windows.Forms.MenuStrip();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowChannels = new System.Windows.Forms.ToolStripComboBox();
            this.mainmenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainmenuStrip
            // 
            this.mainmenuStrip.BackColor = System.Drawing.Color.Blue;
            this.mainmenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainmenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuToolStripMenuItem,
            this.ShowChannels});
            this.mainmenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainmenuStrip.Name = "mainmenuStrip";
            this.mainmenuStrip.Size = new System.Drawing.Size(767, 36);
            this.mainmenuStrip.TabIndex = 1;
            this.mainmenuStrip.Text = "menuStrip1";
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.BackColor = System.Drawing.Color.RoyalBlue;
            this.mainMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setUnitsToolStripMenuItem,
            this.setLevelToolStripMenuItem});
            this.mainMenuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mainMenuToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(123, 32);
            this.mainMenuToolStripMenuItem.Text = "Main Menu";
            this.mainMenuToolStripMenuItem.Click += new System.EventHandler(this.mainMneuToolStripMenuItem_Click);
            // 
            // setUnitsToolStripMenuItem
            // 
            this.setUnitsToolStripMenuItem.Name = "setUnitsToolStripMenuItem";
            this.setUnitsToolStripMenuItem.Size = new System.Drawing.Size(181, 32);
            this.setUnitsToolStripMenuItem.Text = "Set Units";
            this.setUnitsToolStripMenuItem.Click += new System.EventHandler(this.setUnitsToolStripMenuItem_Click);
            // 
            // setLevelToolStripMenuItem
            // 
            this.setLevelToolStripMenuItem.Name = "setLevelToolStripMenuItem";
            this.setLevelToolStripMenuItem.Size = new System.Drawing.Size(181, 32);
            this.setLevelToolStripMenuItem.Text = "Set Level";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(230, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Channels";
            // 
            // ShowChannels
            // 
            this.ShowChannels.Name = "ShowChannels";
            this.ShowChannels.Size = new System.Drawing.Size(121, 32);
            this.ShowChannels.SelectedIndexChanged += new System.EventHandler(this.ShowChannels_SelectedIndexChanged);
            // 
            // DeviceDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(767, 285);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainmenuStrip);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "DeviceDataDisplay";
            this.RightToLeftLayout = true;
            this.Text = "Devices Data Display";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DeviceDataDisplay_Load);
            this.mainmenuStrip.ResumeLayout(false);
            this.mainmenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainmenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUnitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setLevelToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripComboBox ShowChannels;
    }
}

