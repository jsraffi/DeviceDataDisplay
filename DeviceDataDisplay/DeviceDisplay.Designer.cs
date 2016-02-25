namespace DeviceDataDisplay
{
    partial class DeviceDisplay
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
            this.DevicesGV = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.statusDeviceDisplay = new System.Windows.Forms.StatusStrip();
            this.lblDeviceDisplayStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesGV)).BeginInit();
            this.statusDeviceDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // DevicesGV
            // 
            this.DevicesGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DevicesGV.Location = new System.Drawing.Point(2, 1);
            this.DevicesGV.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DevicesGV.Name = "DevicesGV";
            this.DevicesGV.RowTemplate.Height = 24;
            this.DevicesGV.Size = new System.Drawing.Size(1354, 359);
            this.DevicesGV.TabIndex = 0;
            this.DevicesGV.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DevicesGV_CellLeave);
            this.DevicesGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DevicesGV_CellValidating);
            this.DevicesGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DevicesGV_EditingControlShowing);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(552, 382);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(162, 37);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Update Devices";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(743, 383);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 36);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Device";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // statusDeviceDisplay
            // 
            this.statusDeviceDisplay.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusDeviceDisplay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDeviceDisplayStatus});
            this.statusDeviceDisplay.Location = new System.Drawing.Point(0, 425);
            this.statusDeviceDisplay.Name = "statusDeviceDisplay";
            this.statusDeviceDisplay.Size = new System.Drawing.Size(1367, 38);
            this.statusDeviceDisplay.TabIndex = 3;
            this.statusDeviceDisplay.Text = "statusStrip1";
            // 
            // lblDeviceDisplayStatus
            // 
            this.lblDeviceDisplayStatus.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceDisplayStatus.Name = "lblDeviceDisplayStatus";
            this.lblDeviceDisplayStatus.Size = new System.Drawing.Size(83, 33);
            this.lblDeviceDisplayStatus.Text = "Ready";
            // 
            // DeviceDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(1367, 463);
            this.Controls.Add(this.statusDeviceDisplay);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.DevicesGV);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeviceDiaplay";
            this.Load += new System.EventHandler(this.DeviceDiaplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DevicesGV)).EndInit();
            this.statusDeviceDisplay.ResumeLayout(false);
            this.statusDeviceDisplay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DevicesGV;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.StatusStrip statusDeviceDisplay;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceDisplayStatus;
    }
}