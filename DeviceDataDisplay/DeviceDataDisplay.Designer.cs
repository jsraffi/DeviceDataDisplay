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
            this.addUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowChannels = new System.Windows.Forms.ToolStripComboBox();
            this.lblSelectChannel = new System.Windows.Forms.Label();
            this.poller = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.deviceSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.setLevelToolStripMenuItem,
            this.addUnitsToolStripMenuItem,
            this.pollSettingsToolStripMenuItem,
            this.deviceSettingsToolStripMenuItem});
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
            this.setUnitsToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.setUnitsToolStripMenuItem.Text = "Set Units";
            this.setUnitsToolStripMenuItem.Click += new System.EventHandler(this.setUnitsToolStripMenuItem_Click);
            // 
            // setLevelToolStripMenuItem
            // 
            this.setLevelToolStripMenuItem.Name = "setLevelToolStripMenuItem";
            this.setLevelToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.setLevelToolStripMenuItem.Text = "Set Level";
            this.setLevelToolStripMenuItem.Click += new System.EventHandler(this.setLevelToolStripMenuItem_Click);
            // 
            // addUnitsToolStripMenuItem
            // 
            this.addUnitsToolStripMenuItem.Name = "addUnitsToolStripMenuItem";
            this.addUnitsToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.addUnitsToolStripMenuItem.Text = "Add Units";
            this.addUnitsToolStripMenuItem.Click += new System.EventHandler(this.addUnitsToolStripMenuItem_Click);
            // 
            // pollSettingsToolStripMenuItem
            // 
            this.pollSettingsToolStripMenuItem.Name = "pollSettingsToolStripMenuItem";
            this.pollSettingsToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.pollSettingsToolStripMenuItem.Text = "Poll Settings";
            this.pollSettingsToolStripMenuItem.Click += new System.EventHandler(this.pollSettingsToolStripMenuItem_Click);
            // 
            // ShowChannels
            // 
            this.ShowChannels.Name = "ShowChannels";
            this.ShowChannels.Size = new System.Drawing.Size(121, 32);
            this.ShowChannels.SelectedIndexChanged += new System.EventHandler(this.ShowChannels_SelectedIndexChanged);
            // 
            // lblSelectChannel
            // 
            this.lblSelectChannel.Font = new System.Drawing.Font("Arial Unicode MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectChannel.ForeColor = System.Drawing.Color.Black;
            this.lblSelectChannel.Location = new System.Drawing.Point(228, 2);
            this.lblSelectChannel.Name = "lblSelectChannel";
            this.lblSelectChannel.Size = new System.Drawing.Size(130, 26);
            this.lblSelectChannel.TabIndex = 2;
            this.lblSelectChannel.Text = "Select Channels";
            this.lblSelectChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // poller
            // 
            this.poller.FlatAppearance.BorderSize = 0;
            this.poller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.poller.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poller.Location = new System.Drawing.Point(359, 1);
            this.poller.Name = "poller";
            this.poller.Size = new System.Drawing.Size(97, 27);
            this.poller.TabIndex = 3;
            this.poller.TabStop = false;
            this.poller.Text = "Connect";
            this.poller.UseVisualStyleBackColor = false;
            this.poller.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial Unicode MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(458, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(58, 23);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Click += new System.EventHandler(this.label1_Click);
            // 
            // deviceSettingsToolStripMenuItem
            // 
            this.deviceSettingsToolStripMenuItem.Name = "deviceSettingsToolStripMenuItem";
            this.deviceSettingsToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.deviceSettingsToolStripMenuItem.Text = "Device Settings";
            this.deviceSettingsToolStripMenuItem.Click += new System.EventHandler(this.deviceSettingsToolStripMenuItem_Click);
            // 
            // DeviceDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(767, 285);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.poller);
            this.Controls.Add(this.lblSelectChannel);
            this.Controls.Add(this.mainmenuStrip);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "DeviceDataDisplay";
            this.RightToLeftLayout = true;
            this.Text = "Devices Data Display";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeviceDataDisplay_FormClosing);
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
        private System.Windows.Forms.Label lblSelectChannel;
        private System.Windows.Forms.ToolStripComboBox ShowChannels;
        private System.Windows.Forms.ToolStripMenuItem addUnitsToolStripMenuItem;
        private System.Windows.Forms.Button poller;
        private System.Windows.Forms.ToolStripMenuItem pollSettingsToolStripMenuItem;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ToolStripMenuItem deviceSettingsToolStripMenuItem;
    }
}

