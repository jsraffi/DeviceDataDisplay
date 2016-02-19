namespace DeviceDataDisplay
{
    partial class AddUnitsToDevice
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
            this.cmbDeviceSelection = new System.Windows.Forms.ComboBox();
            this.txtIndexValue = new System.Windows.Forms.TextBox();
            this.txtUnitsValue = new System.Windows.Forms.TextBox();
            this.lbldevices = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDeviceUnitsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.addunitsGB.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addunitsGB
            // 
            this.addunitsGB.Controls.Add(this.label2);
            this.addunitsGB.Controls.Add(this.label1);
            this.addunitsGB.Controls.Add(this.lbldevices);
            this.addunitsGB.Controls.Add(this.txtUnitsValue);
            this.addunitsGB.Controls.Add(this.txtIndexValue);
            this.addunitsGB.Controls.Add(this.cmbDeviceSelection);
            this.addunitsGB.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addunitsGB.Location = new System.Drawing.Point(22, 23);
            this.addunitsGB.Name = "addunitsGB";
            this.addunitsGB.Size = new System.Drawing.Size(715, 173);
            this.addunitsGB.TabIndex = 0;
            this.addunitsGB.TabStop = false;
            this.addunitsGB.Text = "Add Units to Device";
            // 
            // cmbDeviceSelection
            // 
            this.cmbDeviceSelection.FormattingEnabled = true;
            this.cmbDeviceSelection.Location = new System.Drawing.Point(25, 95);
            this.cmbDeviceSelection.Name = "cmbDeviceSelection";
            this.cmbDeviceSelection.Size = new System.Drawing.Size(314, 34);
            this.cmbDeviceSelection.TabIndex = 0;
            // 
            // txtIndexValue
            // 
            this.txtIndexValue.Location = new System.Drawing.Point(365, 94);
            this.txtIndexValue.Name = "txtIndexValue";
            this.txtIndexValue.Size = new System.Drawing.Size(151, 34);
            this.txtIndexValue.TabIndex = 1;
            // 
            // txtUnitsValue
            // 
            this.txtUnitsValue.Location = new System.Drawing.Point(542, 95);
            this.txtUnitsValue.Name = "txtUnitsValue";
            this.txtUnitsValue.Size = new System.Drawing.Size(149, 34);
            this.txtUnitsValue.TabIndex = 2;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(541, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "Units Value";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDeviceUnitsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 261);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(758, 33);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDeviceUnitsStatus
            // 
            this.lblDeviceUnitsStatus.Name = "lblDeviceUnitsStatus";
            this.lblDeviceUnitsStatus.Size = new System.Drawing.Size(96, 28);
            this.lblDeviceUnitsStatus.Text = "Messages";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(213, 213);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 35);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(435, 213);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AddUnitsToDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(758, 294);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.addunitsGB);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUnitsToDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUnitsToDevice";
            this.Load += new System.EventHandler(this.AddUnitsToDevice_Load);
            this.addunitsGB.ResumeLayout(false);
            this.addunitsGB.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox addunitsGB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldevices;
        private System.Windows.Forms.TextBox txtUnitsValue;
        private System.Windows.Forms.TextBox txtIndexValue;
        private System.Windows.Forms.ComboBox cmbDeviceSelection;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceUnitsStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}