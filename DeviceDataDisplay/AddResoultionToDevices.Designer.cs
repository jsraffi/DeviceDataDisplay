namespace DeviceDataDisplay
{
    partial class AddResoultionToDevices
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
            this.addunitsGB = new System.Windows.Forms.GroupBox();
            this.lblresolution = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldevices = new System.Windows.Forms.Label();
            this.txtIndexValue = new System.Windows.Forms.TextBox();
            this.cmbDeviceSelection = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDeviceResStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.addunitsGB.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addunitsGB
            // 
            this.addunitsGB.Controls.Add(this.txtResolution);
            this.addunitsGB.Controls.Add(this.lblresolution);
            this.addunitsGB.Controls.Add(this.label1);
            this.addunitsGB.Controls.Add(this.lbldevices);
            this.addunitsGB.Controls.Add(this.txtIndexValue);
            this.addunitsGB.Controls.Add(this.cmbDeviceSelection);
            this.addunitsGB.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addunitsGB.Location = new System.Drawing.Point(34, 11);
            this.addunitsGB.Name = "addunitsGB";
            this.addunitsGB.Size = new System.Drawing.Size(750, 153);
            this.addunitsGB.TabIndex = 4;
            this.addunitsGB.TabStop = false;
            this.addunitsGB.Text = "Add Resolution to Device";
            // 
            // lblresolution
            // 
            this.lblresolution.AutoSize = true;
            this.lblresolution.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblresolution.Location = new System.Drawing.Point(541, 62);
            this.lblresolution.Name = "lblresolution";
            this.lblresolution.Size = new System.Drawing.Size(193, 33);
            this.lblresolution.TabIndex = 5;
            this.lblresolution.Text = "Resolution Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(363, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "Index Value";
            // 
            // lbldevices
            // 
            this.lbldevices.AutoSize = true;
            this.lbldevices.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldevices.Location = new System.Drawing.Point(19, 62);
            this.lbldevices.Name = "lbldevices";
            this.lbldevices.Size = new System.Drawing.Size(99, 33);
            this.lbldevices.TabIndex = 3;
            this.lbldevices.Text = "Devices";
            // 
            // txtIndexValue
            // 
            this.txtIndexValue.Location = new System.Drawing.Point(369, 95);
            this.txtIndexValue.Name = "txtIndexValue";
            this.txtIndexValue.Size = new System.Drawing.Size(151, 34);
            this.txtIndexValue.TabIndex = 1;
            // 
            // cmbDeviceSelection
            // 
            this.cmbDeviceSelection.FormattingEnabled = true;
            this.cmbDeviceSelection.Location = new System.Drawing.Point(25, 95);
            this.cmbDeviceSelection.Name = "cmbDeviceSelection";
            this.cmbDeviceSelection.Size = new System.Drawing.Size(314, 34);
            this.cmbDeviceSelection.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(481, 181);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(259, 181);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDeviceResStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 235);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(830, 33);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDeviceResStatus
            // 
            this.lblDeviceResStatus.Name = "lblDeviceResStatus";
            this.lblDeviceResStatus.Size = new System.Drawing.Size(96, 28);
            this.lblDeviceResStatus.Text = "Messages";
            // 
            // txtResolution
            // 
            this.txtResolution.Location = new System.Drawing.Point(547, 95);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.Size = new System.Drawing.Size(151, 34);
            this.txtResolution.TabIndex = 6;
            // 
            // AddResoultionToDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(830, 268);
            this.Controls.Add(this.addunitsGB);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddResoultionToDevices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddResoultionToDevices";
            this.Load += new System.EventHandler(this.AddResoultionToDevices_Load);
            this.addunitsGB.ResumeLayout(false);
            this.addunitsGB.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox addunitsGB;
        private System.Windows.Forms.Label lblresolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldevices;
        private System.Windows.Forms.TextBox txtIndexValue;
        private System.Windows.Forms.ComboBox cmbDeviceSelection;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceResStatus;
        private System.Windows.Forms.TextBox txtResolution;
    }
}