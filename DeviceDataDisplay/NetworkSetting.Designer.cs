namespace DeviceDataDisplay
{
    partial class NetworkSetting
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
            this.grpNetworkSetting = new System.Windows.Forms.GroupBox();
            this.txtDNSserrver2 = new System.Windows.Forms.TextBox();
            this.lbldnsserver2 = new System.Windows.Forms.Label();
            this.txtDNSserver1 = new System.Windows.Forms.TextBox();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.txtSubnetmask = new System.Windows.Forms.TextBox();
            this.txtIpaddress = new System.Windows.Forms.TextBox();
            this.lbldnsnameserrver = new System.Windows.Forms.Label();
            this.lblgateway = new System.Windows.Forms.Label();
            this.lblnetmask = new System.Windows.Forms.Label();
            this.lblipaddress = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtNetworkstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusmessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpNetworkSetting.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNetworkSetting
            // 
            this.grpNetworkSetting.Controls.Add(this.txtDNSserrver2);
            this.grpNetworkSetting.Controls.Add(this.lbldnsserver2);
            this.grpNetworkSetting.Controls.Add(this.txtDNSserver1);
            this.grpNetworkSetting.Controls.Add(this.txtGateway);
            this.grpNetworkSetting.Controls.Add(this.txtSubnetmask);
            this.grpNetworkSetting.Controls.Add(this.txtIpaddress);
            this.grpNetworkSetting.Controls.Add(this.lbldnsnameserrver);
            this.grpNetworkSetting.Controls.Add(this.lblgateway);
            this.grpNetworkSetting.Controls.Add(this.lblnetmask);
            this.grpNetworkSetting.Controls.Add(this.lblipaddress);
            this.grpNetworkSetting.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNetworkSetting.ForeColor = System.Drawing.Color.White;
            this.grpNetworkSetting.Location = new System.Drawing.Point(25, 31);
            this.grpNetworkSetting.Name = "grpNetworkSetting";
            this.grpNetworkSetting.Size = new System.Drawing.Size(597, 331);
            this.grpNetworkSetting.TabIndex = 0;
            this.grpNetworkSetting.TabStop = false;
            this.grpNetworkSetting.Text = "Network Setting";
            this.grpNetworkSetting.Enter += new System.EventHandler(this.grpNetworkSetting_Enter);
            // 
            // txtDNSserrver2
            // 
            this.txtDNSserrver2.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNSserrver2.Location = new System.Drawing.Point(272, 260);
            this.txtDNSserrver2.Name = "txtDNSserrver2";
            this.txtDNSserrver2.Size = new System.Drawing.Size(276, 38);
            this.txtDNSserrver2.TabIndex = 9;
            this.txtDNSserrver2.Leave += new System.EventHandler(this.txtDNSserrver2_Leave);
            // 
            // lbldnsserver2
            // 
            this.lbldnsserver2.AutoSize = true;
            this.lbldnsserver2.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldnsserver2.ForeColor = System.Drawing.Color.White;
            this.lbldnsserver2.Location = new System.Drawing.Point(40, 263);
            this.lbldnsserver2.Name = "lbldnsserver2";
            this.lbldnsserver2.Size = new System.Drawing.Size(231, 33);
            this.lbldnsserver2.TabIndex = 8;
            this.lbldnsserver2.Text = "DNS Name Server 2";
            // 
            // txtDNSserver1
            // 
            this.txtDNSserver1.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNSserver1.Location = new System.Drawing.Point(272, 205);
            this.txtDNSserver1.Name = "txtDNSserver1";
            this.txtDNSserver1.Size = new System.Drawing.Size(276, 38);
            this.txtDNSserver1.TabIndex = 7;
            this.txtDNSserver1.Leave += new System.EventHandler(this.txtDNSserver1_Leave);
            // 
            // txtGateway
            // 
            this.txtGateway.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGateway.Location = new System.Drawing.Point(272, 152);
            this.txtGateway.Name = "txtGateway";
            this.txtGateway.Size = new System.Drawing.Size(276, 38);
            this.txtGateway.TabIndex = 6;
            this.txtGateway.Leave += new System.EventHandler(this.txtGateway_Leave);
            // 
            // txtSubnetmask
            // 
            this.txtSubnetmask.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubnetmask.Location = new System.Drawing.Point(272, 98);
            this.txtSubnetmask.Name = "txtSubnetmask";
            this.txtSubnetmask.Size = new System.Drawing.Size(276, 38);
            this.txtSubnetmask.TabIndex = 5;
            this.txtSubnetmask.Leave += new System.EventHandler(this.txtSubnetmask_Leave);
            // 
            // txtIpaddress
            // 
            this.txtIpaddress.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIpaddress.Location = new System.Drawing.Point(272, 42);
            this.txtIpaddress.Name = "txtIpaddress";
            this.txtIpaddress.Size = new System.Drawing.Size(276, 38);
            this.txtIpaddress.TabIndex = 4;
            this.txtIpaddress.Leave += new System.EventHandler(this.txtIpaddress_Leave);
            // 
            // lbldnsnameserrver
            // 
            this.lbldnsnameserrver.AutoSize = true;
            this.lbldnsnameserrver.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldnsnameserrver.ForeColor = System.Drawing.Color.White;
            this.lbldnsnameserrver.Location = new System.Drawing.Point(40, 209);
            this.lbldnsnameserrver.Name = "lbldnsnameserrver";
            this.lbldnsnameserrver.Size = new System.Drawing.Size(231, 33);
            this.lbldnsnameserrver.TabIndex = 3;
            this.lbldnsnameserrver.Text = "DNS Name Server 1";
            // 
            // lblgateway
            // 
            this.lblgateway.AutoSize = true;
            this.lblgateway.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgateway.ForeColor = System.Drawing.Color.White;
            this.lblgateway.Location = new System.Drawing.Point(42, 157);
            this.lblgateway.Name = "lblgateway";
            this.lblgateway.Size = new System.Drawing.Size(191, 33);
            this.lblgateway.TabIndex = 2;
            this.lblgateway.Text = "Default Gateway";
            // 
            // lblnetmask
            // 
            this.lblnetmask.AutoSize = true;
            this.lblnetmask.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnetmask.ForeColor = System.Drawing.Color.White;
            this.lblnetmask.Location = new System.Drawing.Point(42, 101);
            this.lblnetmask.Name = "lblnetmask";
            this.lblnetmask.Size = new System.Drawing.Size(206, 33);
            this.lblnetmask.TabIndex = 1;
            this.lblnetmask.Text = "Net mask(Subnet)";
            // 
            // lblipaddress
            // 
            this.lblipaddress.AutoSize = true;
            this.lblipaddress.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblipaddress.ForeColor = System.Drawing.Color.White;
            this.lblipaddress.Location = new System.Drawing.Point(42, 42);
            this.lblipaddress.Name = "lblipaddress";
            this.lblipaddress.Size = new System.Drawing.Size(132, 33);
            this.lblipaddress.TabIndex = 0;
            this.lblipaddress.Text = "IP Address";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtNetworkstatus,
            this.toolStripStatusLabel1,
            this.lblStatusmessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 433);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(666, 38);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtNetworkstatus
            // 
            this.txtNetworkstatus.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetworkstatus.Name = "txtNetworkstatus";
            this.txtNetworkstatus.Size = new System.Drawing.Size(0, 33);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 33);
            // 
            // lblStatusmessage
            // 
            this.lblStatusmessage.ForeColor = System.Drawing.Color.Red;
            this.lblStatusmessage.Name = "lblStatusmessage";
            this.lblStatusmessage.Size = new System.Drawing.Size(202, 33);
            this.lblStatusmessage.Text = "Messaage Center";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(253, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(159, 45);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // NetworkSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(666, 471);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpNetworkSetting);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NetworkSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetworkSetting";
            this.Load += new System.EventHandler(this.NetworkSetting_Load);
            this.grpNetworkSetting.ResumeLayout(false);
            this.grpNetworkSetting.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNetworkSetting;
        private System.Windows.Forms.Label lbldnsnameserrver;
        private System.Windows.Forms.Label lblgateway;
        private System.Windows.Forms.Label lblnetmask;
        private System.Windows.Forms.Label lblipaddress;
        private System.Windows.Forms.TextBox txtDNSserver1;
        private System.Windows.Forms.TextBox txtGateway;
        private System.Windows.Forms.TextBox txtSubnetmask;
        private System.Windows.Forms.TextBox txtIpaddress;
        private System.Windows.Forms.TextBox txtDNSserrver2;
        private System.Windows.Forms.Label lbldnsserver2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtNetworkstatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusmessage;
    }
}