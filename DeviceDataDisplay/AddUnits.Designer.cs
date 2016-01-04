namespace DeviceDataDisplay
{
    partial class AddUnits
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
            this.AddUnitsGV = new System.Windows.Forms.DataGridView();
            this.save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AddUnitsGV)).BeginInit();
            this.SuspendLayout();
            // 
            // AddUnitsGV
            // 
            this.AddUnitsGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AddUnitsGV.Location = new System.Drawing.Point(1, 1);
            this.AddUnitsGV.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.AddUnitsGV.Name = "AddUnitsGV";
            this.AddUnitsGV.RowTemplate.Height = 24;
            this.AddUnitsGV.Size = new System.Drawing.Size(417, 457);
            this.AddUnitsGV.TabIndex = 0;
            this.AddUnitsGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.AddUnitsGV_CellValueChanged);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(171, 475);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(111, 42);
            this.save.TabIndex = 1;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            // 
            // AddUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(465, 527);
            this.Controls.Add(this.save);
            this.Controls.Add(this.AddUnitsGV);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "AddUnits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUnits";
            this.Load += new System.EventHandler(this.AddUnits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AddUnitsGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView AddUnitsGV;
        private System.Windows.Forms.Button save;
    }
}