namespace DeviceDataDisplay
{
    partial class SetDeviceAlarm
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
            this.DeviceAlarmGV = new System.Windows.Forms.DataGridView();
            this.AddAlarm = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceAlarmGV)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceAlarmGV
            // 
            this.DeviceAlarmGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeviceAlarmGV.Location = new System.Drawing.Point(3, -1);
            this.DeviceAlarmGV.Name = "DeviceAlarmGV";
            this.DeviceAlarmGV.RowTemplate.Height = 24;
            this.DeviceAlarmGV.Size = new System.Drawing.Size(767, 408);
            this.DeviceAlarmGV.TabIndex = 1;
            this.DeviceAlarmGV.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeviceAlarmGV_CellLeave);
            this.DeviceAlarmGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DeviceAlarmGV_EditingControlShowing);
            // 
            // AddAlarm
            // 
            this.AddAlarm.Location = new System.Drawing.Point(391, 423);
            this.AddAlarm.Name = "AddAlarm";
            this.AddAlarm.Size = new System.Drawing.Size(246, 46);
            this.AddAlarm.TabIndex = 7;
            this.AddAlarm.Text = "Add Alarm to device";
            this.AddAlarm.UseVisualStyleBackColor = false;
            this.AddAlarm.Click += new System.EventHandler(this.AddAlarm_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(145, 423);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(116, 44);
            this.Update.TabIndex = 6;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = false;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 487);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(782, 33);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(96, 28);
            this.lblStatus.Text = "Messages";
            // 
            // SetDeviceAlarm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(782, 520);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.AddAlarm);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.DeviceAlarmGV);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetDeviceAlarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetDeviceAlarm";
            this.Load += new System.EventHandler(this.SetDeviceAlarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DeviceAlarmGV)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DeviceAlarmGV;
        private System.Windows.Forms.Button AddAlarm;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}