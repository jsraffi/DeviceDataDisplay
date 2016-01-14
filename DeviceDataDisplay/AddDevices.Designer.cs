namespace DeviceDataDisplay
{
    partial class AddDevices
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
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbldevicename = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.lblSlaveID = new System.Windows.Forms.Label();
            this.txtSlaveID = new System.Windows.Forms.TextBox();
            this.lblValueAddress = new System.Windows.Forms.Label();
            this.txtValueAddress = new System.Windows.Forms.TextBox();
            this.lblValueDatatype = new System.Windows.Forms.Label();
            this.grpUnitsResolution = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnitAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbValueDatatype = new System.Windows.Forms.ComboBox();
            this.cmbUnitDatatype = new System.Windows.Forms.ComboBox();
            this.cmbResolutionDatatype = new System.Windows.Forms.ComboBox();
            this.lblUnitDatatype = new System.Windows.Forms.Label();
            this.txtResolutionAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEndianess = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbAlarmDatatype = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlarmAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.stsAddDevices = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.grpUnitsResolution.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.stsAddDevices.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(633, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 41);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbValueDatatype);
            this.groupBox1.Controls.Add(this.lblValueDatatype);
            this.groupBox1.Controls.Add(this.txtValueAddress);
            this.groupBox1.Controls.Add(this.lblValueAddress);
            this.groupBox1.Controls.Add(this.txtSlaveID);
            this.groupBox1.Controls.Add(this.lblSlaveID);
            this.groupBox1.Controls.Add(this.txtDeviceName);
            this.groupBox1.Controls.Add(this.lbldevicename);
            this.groupBox1.Location = new System.Drawing.Point(35, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(779, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Required Parameters";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lbldevicename
            // 
            this.lbldevicename.AutoSize = true;
            this.lbldevicename.Location = new System.Drawing.Point(31, 41);
            this.lbldevicename.Name = "lbldevicename";
            this.lbldevicename.Size = new System.Drawing.Size(131, 26);
            this.lbldevicename.TabIndex = 0;
            this.lbldevicename.Text = "Device Name";
            this.lbldevicename.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(36, 84);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(160, 34);
            this.txtDeviceName.TabIndex = 1;
            // 
            // lblSlaveID
            // 
            this.lblSlaveID.AutoSize = true;
            this.lblSlaveID.Location = new System.Drawing.Point(219, 41);
            this.lblSlaveID.Name = "lblSlaveID";
            this.lblSlaveID.Size = new System.Drawing.Size(86, 26);
            this.lblSlaveID.TabIndex = 2;
            this.lblSlaveID.Text = "Slave ID";
            // 
            // txtSlaveID
            // 
            this.txtSlaveID.Location = new System.Drawing.Point(217, 84);
            this.txtSlaveID.Name = "txtSlaveID";
            this.txtSlaveID.Size = new System.Drawing.Size(160, 34);
            this.txtSlaveID.TabIndex = 3;
            // 
            // lblValueAddress
            // 
            this.lblValueAddress.AutoSize = true;
            this.lblValueAddress.Location = new System.Drawing.Point(400, 41);
            this.lblValueAddress.Name = "lblValueAddress";
            this.lblValueAddress.Size = new System.Drawing.Size(141, 26);
            this.lblValueAddress.TabIndex = 4;
            this.lblValueAddress.Text = "Value Address";
            // 
            // txtValueAddress
            // 
            this.txtValueAddress.Location = new System.Drawing.Point(403, 84);
            this.txtValueAddress.Name = "txtValueAddress";
            this.txtValueAddress.Size = new System.Drawing.Size(160, 34);
            this.txtValueAddress.TabIndex = 5;
            // 
            // lblValueDatatype
            // 
            this.lblValueDatatype.AutoSize = true;
            this.lblValueDatatype.Location = new System.Drawing.Point(584, 41);
            this.lblValueDatatype.Name = "lblValueDatatype";
            this.lblValueDatatype.Size = new System.Drawing.Size(148, 26);
            this.lblValueDatatype.TabIndex = 6;
            this.lblValueDatatype.Text = "Value Datatype";
            // 
            // grpUnitsResolution
            // 
            this.grpUnitsResolution.Controls.Add(this.cmbResolutionDatatype);
            this.grpUnitsResolution.Controls.Add(this.lblUnitDatatype);
            this.grpUnitsResolution.Controls.Add(this.txtResolutionAddress);
            this.grpUnitsResolution.Controls.Add(this.label4);
            this.grpUnitsResolution.Controls.Add(this.cmbUnitDatatype);
            this.grpUnitsResolution.Controls.Add(this.label1);
            this.grpUnitsResolution.Controls.Add(this.txtUnitAddress);
            this.grpUnitsResolution.Controls.Add(this.label2);
            this.grpUnitsResolution.Location = new System.Drawing.Point(35, 191);
            this.grpUnitsResolution.Name = "grpUnitsResolution";
            this.grpUnitsResolution.Size = new System.Drawing.Size(779, 137);
            this.grpUnitsResolution.TabIndex = 2;
            this.grpUnitsResolution.TabStop = false;
            this.grpUnitsResolution.Text = "Optional units and resolution parameter";
            this.grpUnitsResolution.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Unit Datatype";
            // 
            // txtUnitAddress
            // 
            this.txtUnitAddress.Location = new System.Drawing.Point(29, 75);
            this.txtUnitAddress.Name = "txtUnitAddress";
            this.txtUnitAddress.Size = new System.Drawing.Size(160, 34);
            this.txtUnitAddress.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Unit Address";
            // 
            // cmbValueDatatype
            // 
            this.cmbValueDatatype.FormattingEnabled = true;
            this.cmbValueDatatype.Location = new System.Drawing.Point(589, 84);
            this.cmbValueDatatype.Name = "cmbValueDatatype";
            this.cmbValueDatatype.Size = new System.Drawing.Size(143, 34);
            this.cmbValueDatatype.TabIndex = 7;
            // 
            // cmbUnitDatatype
            // 
            this.cmbUnitDatatype.FormattingEnabled = true;
            this.cmbUnitDatatype.Location = new System.Drawing.Point(214, 75);
            this.cmbUnitDatatype.Name = "cmbUnitDatatype";
            this.cmbUnitDatatype.Size = new System.Drawing.Size(143, 34);
            this.cmbUnitDatatype.TabIndex = 8;
            // 
            // cmbResolutionDatatype
            // 
            this.cmbResolutionDatatype.FormattingEnabled = true;
            this.cmbResolutionDatatype.Location = new System.Drawing.Point(584, 75);
            this.cmbResolutionDatatype.Name = "cmbResolutionDatatype";
            this.cmbResolutionDatatype.Size = new System.Drawing.Size(143, 34);
            this.cmbResolutionDatatype.TabIndex = 11;
            // 
            // lblUnitDatatype
            // 
            this.lblUnitDatatype.AutoSize = true;
            this.lblUnitDatatype.Location = new System.Drawing.Point(581, 30);
            this.lblUnitDatatype.Name = "lblUnitDatatype";
            this.lblUnitDatatype.Size = new System.Drawing.Size(191, 26);
            this.lblUnitDatatype.TabIndex = 14;
            this.lblUnitDatatype.Text = "Resolution Datatype";
            // 
            // txtResolutionAddress
            // 
            this.txtResolutionAddress.Location = new System.Drawing.Point(390, 75);
            this.txtResolutionAddress.Name = "txtResolutionAddress";
            this.txtResolutionAddress.Size = new System.Drawing.Size(160, 34);
            this.txtResolutionAddress.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 26);
            this.label4.TabIndex = 12;
            this.label4.Text = "Resolution Address";
            // 
            // cmbEndianess
            // 
            this.cmbEndianess.FormattingEnabled = true;
            this.cmbEndianess.Location = new System.Drawing.Point(405, 77);
            this.cmbEndianess.Name = "cmbEndianess";
            this.cmbEndianess.Size = new System.Drawing.Size(143, 34);
            this.cmbEndianess.TabIndex = 15;
            this.cmbEndianess.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Endianess";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbAlarmDatatype);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtAlarmAddress);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbEndianess);
            this.groupBox2.Location = new System.Drawing.Point(35, 355);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(779, 127);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Optional alarm and required Endianess parameter";
            // 
            // cmbAlarmDatatype
            // 
            this.cmbAlarmDatatype.FormattingEnabled = true;
            this.cmbAlarmDatatype.Location = new System.Drawing.Point(223, 77);
            this.cmbAlarmDatatype.Name = "cmbAlarmDatatype";
            this.cmbAlarmDatatype.Size = new System.Drawing.Size(143, 34);
            this.cmbAlarmDatatype.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 26);
            this.label5.TabIndex = 20;
            this.label5.Text = "Alarm Datatype";
            // 
            // txtAlarmAddress
            // 
            this.txtAlarmAddress.Location = new System.Drawing.Point(29, 77);
            this.txtAlarmAddress.Name = "txtAlarmAddress";
            this.txtAlarmAddress.Size = new System.Drawing.Size(160, 34);
            this.txtAlarmAddress.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 26);
            this.label6.TabIndex = 18;
            this.label6.Text = "Alam Address";
            // 
            // stsAddDevices
            // 
            this.stsAddDevices.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsAddDevices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.stsAddDevices.Location = new System.Drawing.Point(0, 494);
            this.stsAddDevices.Name = "stsAddDevices";
            this.stsAddDevices.Size = new System.Drawing.Size(870, 25);
            this.stsAddDevices.TabIndex = 18;
            this.stsAddDevices.Text = "Ready";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 20);
            this.lblStatus.Text = "Ready";
            // 
            // AddDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(870, 519);
            this.Controls.Add(this.stsAddDevices);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpUnitsResolution);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDevices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddDevices";
            this.Load += new System.EventHandler(this.AddDevices_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpUnitsResolution.ResumeLayout(false);
            this.grpUnitsResolution.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.stsAddDevices.ResumeLayout(false);
            this.stsAddDevices.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbldevicename;
        private System.Windows.Forms.Label lblValueDatatype;
        private System.Windows.Forms.TextBox txtValueAddress;
        private System.Windows.Forms.Label lblValueAddress;
        private System.Windows.Forms.TextBox txtSlaveID;
        private System.Windows.Forms.Label lblSlaveID;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.GroupBox grpUnitsResolution;
        private System.Windows.Forms.ComboBox cmbValueDatatype;
        private System.Windows.Forms.ComboBox cmbUnitDatatype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnitAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbResolutionDatatype;
        private System.Windows.Forms.Label lblUnitDatatype;
        private System.Windows.Forms.TextBox txtResolutionAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEndianess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbAlarmDatatype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAlarmAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip stsAddDevices;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}