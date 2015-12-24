namespace DeviceDataDisplay
{
    partial class SetUnits
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
            this.ChannelsGV = new System.Windows.Forms.DataGridView();
            this.Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChannelsGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ChannelsGV
            // 
            this.ChannelsGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChannelsGV.Location = new System.Drawing.Point(1, 1);
            this.ChannelsGV.Margin = new System.Windows.Forms.Padding(5);
            this.ChannelsGV.Name = "ChannelsGV";
            this.ChannelsGV.RowTemplate.Height = 24;
            this.ChannelsGV.Size = new System.Drawing.Size(527, 518);
            this.ChannelsGV.TabIndex = 0;
            this.ChannelsGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ChannelsGV_EditingControlShowing);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(208, 528);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(121, 43);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // SetUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(554, 583);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.ChannelsGV);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetUnits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetUnits";
            this.Load += new System.EventHandler(this.SetUnits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChannelsGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ChannelsGV;
        private System.Windows.Forms.Button Save;
    }
}