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
            this.lblValueDatatype = new System.Windows.Forms.Label();
            this.txtValueAddress = new System.Windows.Forms.TextBox();
            this.lblValueAddress = new System.Windows.Forms.Label();
            this.txtSlaveID = new System.Windows.Forms.TextBox();
            this.lblSlaveID = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.lbldevicename = new System.Windows.Forms.Label();
            this.cmbEndianess = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.stsAddDevices = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnitAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAlarmAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlarmStatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResolutionAddress = new System.Windows.Forms.TextBox();
            this.lblUnitDatatype = new System.Windows.Forms.Label();
            this.grpUnitsResolution = new System.Windows.Forms.GroupBox();
            this.txtChannelNameAddr = new System.Windows.Forms.TextBox();
            this.txtChannelNameLength = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMaxLevelLength = new System.Windows.Forms.TextBox();
            this.txtMaxLevelAddr = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMinLevelLength = new System.Windows.Forms.TextBox();
            this.txtMinLevelAddr = new System.Windows.Forms.TextBox();
            this.txtValueLength = new System.Windows.Forms.TextBox();
            this.txtUnitsLength = new System.Windows.Forms.TextBox();
            this.txtResLength = new System.Windows.Forms.TextBox();
            this.txtAlarmLength = new System.Windows.Forms.TextBox();
            this.txtAlarmStatusLength = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.stsAddDevices.SuspendLayout();
            this.grpUnitsResolution.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(667, 488);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 41);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUnitsLength);
            this.groupBox1.Controls.Add(this.txtValueLength);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUnitAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblValueDatatype);
            this.groupBox1.Controls.Add(this.txtValueAddress);
            this.groupBox1.Controls.Add(this.lblValueAddress);
            this.groupBox1.Controls.Add(this.txtSlaveID);
            this.groupBox1.Controls.Add(this.lblSlaveID);
            this.groupBox1.Controls.Add(this.txtDeviceName);
            this.groupBox1.Controls.Add(this.lbldevicename);
            this.groupBox1.Location = new System.Drawing.Point(35, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1111, 151);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Expect Units all parameters are required";
            // 
            // lblValueDatatype
            // 
            this.lblValueDatatype.AutoSize = true;
            this.lblValueDatatype.Location = new System.Drawing.Point(570, 41);
            this.lblValueDatatype.Name = "lblValueDatatype";
            this.lblValueDatatype.Size = new System.Drawing.Size(129, 26);
            this.lblValueDatatype.TabIndex = 6;
            this.lblValueDatatype.Text = "Value Length";
            // 
            // txtValueAddress
            // 
            this.txtValueAddress.Location = new System.Drawing.Point(389, 84);
            this.txtValueAddress.Name = "txtValueAddress";
            this.txtValueAddress.Size = new System.Drawing.Size(160, 34);
            this.txtValueAddress.TabIndex = 4;
            // 
            // lblValueAddress
            // 
            this.lblValueAddress.AutoSize = true;
            this.lblValueAddress.Location = new System.Drawing.Point(386, 41);
            this.lblValueAddress.Name = "lblValueAddress";
            this.lblValueAddress.Size = new System.Drawing.Size(141, 26);
            this.lblValueAddress.TabIndex = 4;
            this.lblValueAddress.Text = "Value Address";
            // 
            // txtSlaveID
            // 
            this.txtSlaveID.AcceptsTab = true;
            this.txtSlaveID.Location = new System.Drawing.Point(203, 84);
            this.txtSlaveID.Name = "txtSlaveID";
            this.txtSlaveID.Size = new System.Drawing.Size(160, 34);
            this.txtSlaveID.TabIndex = 3;
            // 
            // lblSlaveID
            // 
            this.lblSlaveID.AutoSize = true;
            this.lblSlaveID.Location = new System.Drawing.Point(205, 41);
            this.lblSlaveID.Name = "lblSlaveID";
            this.lblSlaveID.Size = new System.Drawing.Size(86, 26);
            this.lblSlaveID.TabIndex = 2;
            this.lblSlaveID.Text = "Slave ID";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(22, 84);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(160, 34);
            this.txtDeviceName.TabIndex = 2;
            // 
            // lbldevicename
            // 
            this.lbldevicename.AutoSize = true;
            this.lbldevicename.Location = new System.Drawing.Point(17, 41);
            this.lbldevicename.Name = "lbldevicename";
            this.lbldevicename.Size = new System.Drawing.Size(131, 26);
            this.lbldevicename.TabIndex = 0;
            this.lbldevicename.Text = "Device Name";
            // 
            // cmbEndianess
            // 
            this.cmbEndianess.FormattingEnabled = true;
            this.cmbEndianess.Location = new System.Drawing.Point(471, 492);
            this.cmbEndianess.Name = "cmbEndianess";
            this.cmbEndianess.Size = new System.Drawing.Size(143, 34);
            this.cmbEndianess.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 495);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Endianess";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtMinLevelLength);
            this.groupBox2.Controls.Add(this.txtMinLevelAddr);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtMaxLevelLength);
            this.groupBox2.Controls.Add(this.txtMaxLevelAddr);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtChannelNameLength);
            this.groupBox2.Controls.Add(this.txtChannelNameAddr);
            this.groupBox2.Location = new System.Drawing.Point(30, 355);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1117, 127);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Optional parameter";
            // 
            // stsAddDevices
            // 
            this.stsAddDevices.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsAddDevices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.stsAddDevices.Location = new System.Drawing.Point(0, 536);
            this.stsAddDevices.Name = "stsAddDevices";
            this.stsAddDevices.Size = new System.Drawing.Size(1170, 37);
            this.stsAddDevices.TabIndex = 18;
            this.stsAddDevices.Text = "Ready";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 32);
            this.lblStatus.Text = "Ready";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(922, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "Unit Length";
            // 
            // txtUnitAddress
            // 
            this.txtUnitAddress.Location = new System.Drawing.Point(751, 85);
            this.txtUnitAddress.Name = "txtUnitAddress";
            this.txtUnitAddress.Size = new System.Drawing.Size(160, 34);
            this.txtUnitAddress.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(748, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 26);
            this.label2.TabIndex = 13;
            this.label2.Text = "Unit Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 26);
            this.label6.TabIndex = 18;
            this.label6.Text = "Alam Address";
            // 
            // txtAlarmAddress
            // 
            this.txtAlarmAddress.Location = new System.Drawing.Point(383, 75);
            this.txtAlarmAddress.Name = "txtAlarmAddress";
            this.txtAlarmAddress.Size = new System.Drawing.Size(160, 34);
            this.txtAlarmAddress.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(565, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 26);
            this.label5.TabIndex = 20;
            this.label5.Text = "Alarm Length";
            // 
            // txtAlarmStatus
            // 
            this.txtAlarmStatus.Location = new System.Drawing.Point(741, 75);
            this.txtAlarmStatus.Name = "txtAlarmStatus";
            this.txtAlarmStatus.Size = new System.Drawing.Size(160, 34);
            this.txtAlarmStatus.TabIndex = 13;
            this.txtAlarmStatus.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(737, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 26);
            this.label7.TabIndex = 22;
            this.label7.Text = "Alam Status Addr";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(922, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 26);
            this.label8.TabIndex = 23;
            this.label8.Text = "Alarm Status Length";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 26);
            this.label4.TabIndex = 12;
            this.label4.Text = "Res Address";
            // 
            // txtResolutionAddress
            // 
            this.txtResolutionAddress.Location = new System.Drawing.Point(26, 75);
            this.txtResolutionAddress.Name = "txtResolutionAddress";
            this.txtResolutionAddress.Size = new System.Drawing.Size(160, 34);
            this.txtResolutionAddress.TabIndex = 9;
            // 
            // lblUnitDatatype
            // 
            this.lblUnitDatatype.AutoSize = true;
            this.lblUnitDatatype.Location = new System.Drawing.Point(206, 30);
            this.lblUnitDatatype.Name = "lblUnitDatatype";
            this.lblUnitDatatype.Size = new System.Drawing.Size(114, 26);
            this.lblUnitDatatype.TabIndex = 14;
            this.lblUnitDatatype.Text = "Res Length";
            // 
            // grpUnitsResolution
            // 
            this.grpUnitsResolution.Controls.Add(this.txtAlarmStatusLength);
            this.grpUnitsResolution.Controls.Add(this.txtAlarmLength);
            this.grpUnitsResolution.Controls.Add(this.txtResLength);
            this.grpUnitsResolution.Controls.Add(this.label8);
            this.grpUnitsResolution.Controls.Add(this.lblUnitDatatype);
            this.grpUnitsResolution.Controls.Add(this.label7);
            this.grpUnitsResolution.Controls.Add(this.txtResolutionAddress);
            this.grpUnitsResolution.Controls.Add(this.txtAlarmStatus);
            this.grpUnitsResolution.Controls.Add(this.label4);
            this.grpUnitsResolution.Controls.Add(this.label5);
            this.grpUnitsResolution.Controls.Add(this.label6);
            this.grpUnitsResolution.Controls.Add(this.txtAlarmAddress);
            this.grpUnitsResolution.Location = new System.Drawing.Point(30, 191);
            this.grpUnitsResolution.Name = "grpUnitsResolution";
            this.grpUnitsResolution.Size = new System.Drawing.Size(1117, 143);
            this.grpUnitsResolution.TabIndex = 8;
            this.grpUnitsResolution.TabStop = false;
            this.grpUnitsResolution.Text = "Optional parameters";
            // 
            // txtChannelNameAddr
            // 
            this.txtChannelNameAddr.Location = new System.Drawing.Point(27, 69);
            this.txtChannelNameAddr.Name = "txtChannelNameAddr";
            this.txtChannelNameAddr.Size = new System.Drawing.Size(160, 34);
            this.txtChannelNameAddr.TabIndex = 16;
            // 
            // txtChannelNameLength
            // 
            this.txtChannelNameLength.Location = new System.Drawing.Point(212, 69);
            this.txtChannelNameLength.Name = "txtChannelNameLength";
            this.txtChannelNameLength.Size = new System.Drawing.Size(142, 34);
            this.txtChannelNameLength.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 26);
            this.label9.TabIndex = 24;
            this.label9.Text = "Channel Addr";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(209, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 26);
            this.label10.TabIndex = 26;
            this.label10.Text = "Channel Length";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(570, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(163, 26);
            this.label11.TabIndex = 30;
            this.label11.Text = "Max level Length";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(384, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(151, 26);
            this.label12.TabIndex = 27;
            this.label12.Text = "Max Level Addr";
            // 
            // txtMaxLevelLength
            // 
            this.txtMaxLevelLength.Location = new System.Drawing.Point(573, 69);
            this.txtMaxLevelLength.Name = "txtMaxLevelLength";
            this.txtMaxLevelLength.Size = new System.Drawing.Size(142, 34);
            this.txtMaxLevelLength.TabIndex = 19;
            // 
            // txtMaxLevelAddr
            // 
            this.txtMaxLevelAddr.Location = new System.Drawing.Point(388, 69);
            this.txtMaxLevelAddr.Name = "txtMaxLevelAddr";
            this.txtMaxLevelAddr.Size = new System.Drawing.Size(160, 34);
            this.txtMaxLevelAddr.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(932, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(157, 26);
            this.label13.TabIndex = 34;
            this.label13.Text = "Min level Length";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(740, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 26);
            this.label14.TabIndex = 31;
            this.label14.Text = "Min Level Addr";
            // 
            // txtMinLevelLength
            // 
            this.txtMinLevelLength.Location = new System.Drawing.Point(929, 67);
            this.txtMinLevelLength.Name = "txtMinLevelLength";
            this.txtMinLevelLength.Size = new System.Drawing.Size(162, 34);
            this.txtMinLevelLength.TabIndex = 21;
            // 
            // txtMinLevelAddr
            // 
            this.txtMinLevelAddr.Location = new System.Drawing.Point(744, 67);
            this.txtMinLevelAddr.Name = "txtMinLevelAddr";
            this.txtMinLevelAddr.Size = new System.Drawing.Size(160, 34);
            this.txtMinLevelAddr.TabIndex = 20;
            // 
            // txtValueLength
            // 
            this.txtValueLength.Location = new System.Drawing.Point(567, 84);
            this.txtValueLength.Name = "txtValueLength";
            this.txtValueLength.Size = new System.Drawing.Size(160, 34);
            this.txtValueLength.TabIndex = 5;
            // 
            // txtUnitsLength
            // 
            this.txtUnitsLength.Location = new System.Drawing.Point(926, 84);
            this.txtUnitsLength.Name = "txtUnitsLength";
            this.txtUnitsLength.Size = new System.Drawing.Size(160, 34);
            this.txtUnitsLength.TabIndex = 7;
            // 
            // txtResLength
            // 
            this.txtResLength.Location = new System.Drawing.Point(203, 75);
            this.txtResLength.Name = "txtResLength";
            this.txtResLength.Size = new System.Drawing.Size(160, 34);
            this.txtResLength.TabIndex = 10;
            // 
            // txtAlarmLength
            // 
            this.txtAlarmLength.Location = new System.Drawing.Point(567, 75);
            this.txtAlarmLength.Name = "txtAlarmLength";
            this.txtAlarmLength.Size = new System.Drawing.Size(160, 34);
            this.txtAlarmLength.TabIndex = 12;
            // 
            // txtAlarmStatusLength
            // 
            this.txtAlarmStatusLength.Location = new System.Drawing.Point(929, 75);
            this.txtAlarmStatusLength.Name = "txtAlarmStatusLength";
            this.txtAlarmStatusLength.Size = new System.Drawing.Size(160, 34);
            this.txtAlarmStatusLength.TabIndex = 14;
            // 
            // AddDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(1170, 573);
            this.Controls.Add(this.stsAddDevices);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpUnitsResolution);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbEndianess);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.stsAddDevices.ResumeLayout(false);
            this.stsAddDevices.PerformLayout();
            this.grpUnitsResolution.ResumeLayout(false);
            this.grpUnitsResolution.PerformLayout();
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
        private System.Windows.Forms.ComboBox cmbEndianess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip stsAddDevices;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.TextBox txtUnitsLength;
        private System.Windows.Forms.TextBox txtValueLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnitAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMinLevelLength;
        private System.Windows.Forms.TextBox txtMinLevelAddr;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMaxLevelLength;
        private System.Windows.Forms.TextBox txtMaxLevelAddr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtChannelNameLength;
        private System.Windows.Forms.TextBox txtChannelNameAddr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAlarmAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAlarmStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResolutionAddress;
        private System.Windows.Forms.Label lblUnitDatatype;
        private System.Windows.Forms.GroupBox grpUnitsResolution;
        private System.Windows.Forms.TextBox txtAlarmStatusLength;
        private System.Windows.Forms.TextBox txtAlarmLength;
        private System.Windows.Forms.TextBox txtResLength;
    }
}