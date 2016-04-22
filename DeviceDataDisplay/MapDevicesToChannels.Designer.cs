namespace DeviceDataDisplay
{
    partial class MapDevicesToChannels
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
            this.DeviceMapGV = new System.Windows.Forms.DataGridView();
            this.statusStripMapDevices = new System.Windows.Forms.StatusStrip();
            this.lblDeviceMapStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceMapGV)).BeginInit();
            this.statusStripMapDevices.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceMapGV
            // 
            this.DeviceMapGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeviceMapGV.Location = new System.Drawing.Point(5, 0);
            this.DeviceMapGV.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.DeviceMapGV.Name = "DeviceMapGV";
            this.DeviceMapGV.RowTemplate.Height = 24;
            this.DeviceMapGV.Size = new System.Drawing.Size(854, 530);
            this.DeviceMapGV.TabIndex = 0;
            this.DeviceMapGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeviceMapGV_CellContentClick);
            this.DeviceMapGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DeviceMapGV_EditingControlShowing);
            // 
            // statusStripMapDevices
            // 
            this.statusStripMapDevices.BackColor = System.Drawing.Color.AliceBlue;
            this.statusStripMapDevices.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStripMapDevices.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMapDevices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDeviceMapStatus});
            this.statusStripMapDevices.Location = new System.Drawing.Point(0, 610);
            this.statusStripMapDevices.Name = "statusStripMapDevices";
            this.statusStripMapDevices.Size = new System.Drawing.Size(909, 22);
            this.statusStripMapDevices.TabIndex = 1;
            // 
            // lblDeviceMapStatus
            // 
            this.lblDeviceMapStatus.ForeColor = System.Drawing.Color.Red;
            this.lblDeviceMapStatus.Name = "lblDeviceMapStatus";
            this.lblDeviceMapStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // MapDevicesToChannels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(909, 632);
            this.Controls.Add(this.statusStripMapDevices);
            this.Controls.Add(this.DeviceMapGV);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapDevicesToChannels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MapDevicesToChannels";
            this.Load += new System.EventHandler(this.MapDevicesToChannels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DeviceMapGV)).EndInit();
            this.statusStripMapDevices.ResumeLayout(false);
            this.statusStripMapDevices.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DeviceMapGV;
        private System.Windows.Forms.StatusStrip statusStripMapDevices;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceMapStatus;
    }
}