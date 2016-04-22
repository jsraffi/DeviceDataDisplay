namespace DeviceDataDisplay
{
    partial class SetDeviceUnits
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
            this.DeviceUnits = new System.Windows.Forms.DataGridView();
            this.Update = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDeviceUnitsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.AddUnits = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceUnits)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceUnits
            // 
            this.DeviceUnits.AllowDrop = true;
            this.DeviceUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeviceUnits.Location = new System.Drawing.Point(0, 3);
            this.DeviceUnits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeviceUnits.Name = "DeviceUnits";
            this.DeviceUnits.RowTemplate.Height = 24;
            this.DeviceUnits.Size = new System.Drawing.Size(720, 510);
            this.DeviceUnits.TabIndex = 0;
            this.DeviceUnits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeviceUnits_CellContentClick);
            this.DeviceUnits.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeviceUnits_CellLeave);
            this.DeviceUnits.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DeviceUnits_EditingControlShowing);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(168, 530);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(116, 34);
            this.Update.TabIndex = 1;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = false;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDeviceUnitsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 580);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(720, 33);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDeviceUnitsStatus
            // 
            this.lblDeviceUnitsStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceUnitsStatus.Name = "lblDeviceUnitsStatus";
            this.lblDeviceUnitsStatus.Size = new System.Drawing.Size(96, 28);
            this.lblDeviceUnitsStatus.Text = "Messages";
            // 
            // AddUnits
            // 
            this.AddUnits.Location = new System.Drawing.Point(414, 530);
            this.AddUnits.Name = "AddUnits";
            this.AddUnits.Size = new System.Drawing.Size(206, 36);
            this.AddUnits.TabIndex = 3;
            this.AddUnits.Text = "Add units to device";
            this.AddUnits.UseVisualStyleBackColor = false;
            this.AddUnits.Click += new System.EventHandler(this.AddUnits_Click);
            // 
            // SetDeviceUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(720, 613);
            this.Controls.Add(this.AddUnits);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.DeviceUnits);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetDeviceUnits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetDeviceUnits";
            this.Load += new System.EventHandler(this.SetDeviceUnits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DeviceUnits)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DeviceUnits;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceUnitsStatus;
        private System.Windows.Forms.Button AddUnits;
    }
}