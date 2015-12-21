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
            ((System.ComponentModel.ISupportInitialize)(this.ChannelsGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ChannelsGV
            // 
            this.ChannelsGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChannelsGV.Location = new System.Drawing.Point(-2, 2);
            this.ChannelsGV.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ChannelsGV.Name = "ChannelsGV";
            this.ChannelsGV.RowTemplate.Height = 24;
            this.ChannelsGV.Size = new System.Drawing.Size(775, 904);
            this.ChannelsGV.TabIndex = 0;
            // 
            // SetUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.ChannelsGV);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
    }
}