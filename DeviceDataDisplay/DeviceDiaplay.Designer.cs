﻿namespace DeviceDataDisplay
{
    partial class DeviceDiaplay
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
            ((System.ComponentModel.ISupportInitialize)(this.DevicesGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DevicesGV
            // 
            this.DevicesGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DevicesGV.Location = new System.Drawing.Point(2, 1);
            this.DevicesGV.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DevicesGV.Name = "DevicesGV";
            this.DevicesGV.RowTemplate.Height = 24;
            this.DevicesGV.Size = new System.Drawing.Size(1354, 330);
            this.DevicesGV.TabIndex = 0;
            this.DevicesGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DevicesGV_CellValidating);
            this.DevicesGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DevicesGV_CellValueChanged);
            this.DevicesGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DevicesGV_EditingControlShowing);
            this.DevicesGV.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DevicesGV_NewRowNeeded);
            this.DevicesGV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DevicesGV_RowEnter);
            this.DevicesGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DevicesGV_RowsAdded);
            this.DevicesGV.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DevicesGV_RowValidating);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(646, 348);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 37);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DeviceDiaplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(1367, 402);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.DevicesGV);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceDiaplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeviceDiaplay";
            this.Load += new System.EventHandler(this.DeviceDiaplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DevicesGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DevicesGV;
        private System.Windows.Forms.Button btnSave;
    }
}