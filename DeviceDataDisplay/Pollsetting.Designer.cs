﻿namespace DeviceDataDisplay
{
    partial class Pollsetting
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPortName = new System.Windows.Forms.Label();
            this.CmbPortNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbBaudRates = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbNoOfChannels = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPollInterval = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPollInterval);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CmbNoOfChannels);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbBaudRates);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CmbPortNames);
            this.groupBox1.Controls.Add(this.lblPortName);
            this.groupBox1.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(40, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Poll Settings";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblPortName
            // 
            this.lblPortName.AutoSize = true;
            this.lblPortName.Location = new System.Drawing.Point(31, 47);
            this.lblPortName.Name = "lblPortName";
            this.lblPortName.Size = new System.Drawing.Size(108, 26);
            this.lblPortName.TabIndex = 0;
            this.lblPortName.Text = "Port Name";
            // 
            // CmbPortNames
            // 
            this.CmbPortNames.FormattingEnabled = true;
            this.CmbPortNames.Location = new System.Drawing.Point(204, 44);
            this.CmbPortNames.Name = "CmbPortNames";
            this.CmbPortNames.Size = new System.Drawing.Size(143, 34);
            this.CmbPortNames.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Baud Rate";
            // 
            // CmbBaudRates
            // 
            this.CmbBaudRates.FormattingEnabled = true;
            this.CmbBaudRates.Location = new System.Drawing.Point(204, 90);
            this.CmbBaudRates.Name = "CmbBaudRates";
            this.CmbBaudRates.Size = new System.Drawing.Size(143, 34);
            this.CmbBaudRates.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "No of channels";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // CmbNoOfChannels
            // 
            this.CmbNoOfChannels.FormattingEnabled = true;
            this.CmbNoOfChannels.Location = new System.Drawing.Point(204, 139);
            this.CmbNoOfChannels.Name = "CmbNoOfChannels";
            this.CmbNoOfChannels.Size = new System.Drawing.Size(143, 34);
            this.CmbNoOfChannels.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Poll interval / ms";
            // 
            // txtPollInterval
            // 
            this.txtPollInterval.Location = new System.Drawing.Point(204, 195);
            this.txtPollInterval.Name = "txtPollInterval";
            this.txtPollInterval.Size = new System.Drawing.Size(143, 34);
            this.txtPollInterval.TabIndex = 7;
            this.txtPollInterval.Validated += new System.EventHandler(this.txtPollInterval_Validated);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(200, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 37);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Pollsetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(495, 340);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pollsetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pollsetting";
            this.Load += new System.EventHandler(this.Pollsetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbBaudRates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbPortNames;
        private System.Windows.Forms.Label lblPortName;
        private System.Windows.Forms.TextBox txtPollInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbNoOfChannels;
        private System.Windows.Forms.Button btnSave;
    }
}