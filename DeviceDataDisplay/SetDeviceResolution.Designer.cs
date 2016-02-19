namespace DeviceDataDisplay
{
    partial class SetDeviceResolution
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
            this.DeviceResolutionGV = new System.Windows.Forms.DataGridView();
            this.AddResolution = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceResolutionGV)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceResolutionGV
            // 
            this.DeviceResolutionGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeviceResolutionGV.Location = new System.Drawing.Point(2, 12);
            this.DeviceResolutionGV.Name = "DeviceResolutionGV";
            this.DeviceResolutionGV.RowTemplate.Height = 24;
            this.DeviceResolutionGV.Size = new System.Drawing.Size(797, 408);
            this.DeviceResolutionGV.TabIndex = 0;
            this.DeviceResolutionGV.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeviceResolutionGV_CellLeave);
            this.DeviceResolutionGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DeviceResolutionGV_EditingControlShowing);
            // 
            // AddResolution
            // 
            this.AddResolution.Location = new System.Drawing.Point(428, 439);
            this.AddResolution.Name = "AddResolution";
            this.AddResolution.Size = new System.Drawing.Size(246, 46);
            this.AddResolution.TabIndex = 5;
            this.AddResolution.Text = "Add Resolution to device";
            this.AddResolution.UseVisualStyleBackColor = false;
            this.AddResolution.Click += new System.EventHandler(this.AddResolution_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(182, 439);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(116, 44);
            this.Update.TabIndex = 4;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = false;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(820, 33);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(96, 28);
            this.lblStatus.Text = "Messages";
            // 
            // SetDeviceResolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(820, 535);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.AddResolution);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.DeviceResolutionGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetDeviceResolution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetDeviceResolution";
            this.Load += new System.EventHandler(this.SetDeviceResolution_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DeviceResolutionGV)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DeviceResolutionGV;
        private System.Windows.Forms.Button AddResolution;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}