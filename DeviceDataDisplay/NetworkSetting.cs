using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;

namespace DeviceDataDisplay
{
    public partial class NetworkSetting : Form
    {
        public NetworkSetting()
        {
            InitializeComponent();
        }

        private void grpNetworkSetting_Enter(object sender, EventArgs e)
        {

        }

        private void NetworkSetting_Load(object sender, EventArgs e)
        {
            using (
                MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"])
                )
            {
                Connection.Open();
                string query = "select * from networksettings";

                MySqlCommand command = new MySqlCommand(query, Connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtIpaddress.Text = reader.GetString(1);
                        txtSubnetmask.Text = reader.GetString(2);
                        txtGateway.Text = reader.GetString(3);
                        txtDNSserver1.Text = reader.GetString(4);
                        txtDNSserrver2.Text = reader.GetString(5);
                    }
                }

            }
        }

        private bool ChkValidipaddress(string ipaddress)
        {

            string[] parts = ipaddress.Split('.');
            if (parts.Length < 4)
            {

                return false;
            }
            else
            {
                foreach (string part in parts)
                {
                    byte checkPart = 0;
                    if (!byte.TryParse(part, out checkPart))
                    {
                        return false;
                    }
                }
                // it is a valid IPv4 string in X.X.X.X format
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            using (
                MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"])
                )
            {
                Connection.Open();
                MySqlTransaction transaction = Connection.BeginTransaction();
                try
                {


                    string query = "update networksettings set ipaddress='"+txtIpaddress.Text+"' , netmask='"+
                                   txtSubnetmask.Text+"' , gateway='"+txtGateway.Text+"' , dnsnameserver1='" +
                                   txtDNSserver1.Text+"' , dnsnameserver2='"+txtDNSserrver2.Text +"'";

                    MySqlCommand command = new MySqlCommand(query, Connection);
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                    /*
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = "/home/modbus/bs/networkinterface.sh";
                    psi.UseShellExecute = false;
                    string arguments = txtIpaddress.Text + " " + txtSubnetmask.Text + " " + txtGateway.Text + " " +
                                           txtDNSserver1.Text + " " + txtDNSserrver2.Text;
                    
                    psi.Arguments = arguments
                    Process p = Process.Start(psi);
                    p.WaitForExit();
                */
                    transaction.Commit();
                    lblStatusmessage.Text = "Network settings updated";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    lblStatusmessage.Text = "Network settings fail to update";
                    Debug.WriteLine("Error" + ex.Message);
                }
            }

        }

    



        private void txtIpaddress_Leave(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox) sender;
            if (!ChkValidipaddress(txtbox.Text))
            {
                txtIpaddress.Focus();
                lblStatusmessage.Text = "IP address is not in valid ip format";
            }
            else
            {
                lblStatusmessage.Text = "Message center";
            }
        }

        private void txtSubnetmask_Leave(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (!ChkValidipaddress(txtbox.Text))
            {
                txtSubnetmask.Focus();
                lblStatusmessage.Text = "Subnet mask address is not in valid ip format ";
            }
            else
            {
                lblStatusmessage.Text = "Message center";
            }
        }

        private void txtGateway_Leave(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (!ChkValidipaddress(txtbox.Text))
            {
                txtGateway.Focus();
                lblStatusmessage.Text = "Default gateway address is not in valid ip format ";
            }
            else
            {
                lblStatusmessage.Text = "Message center";
            }

        }

        private void txtDNSserver1_Leave(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (!ChkValidipaddress(txtbox.Text))
            {
                txtDNSserver1.Focus();
                lblStatusmessage.Text = "DNS Server 1 address is not in valid ip format ";
            }
            else
            {
                lblStatusmessage.Text = "Message center";
            }

        }

        private void txtDNSserrver2_Leave(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (!ChkValidipaddress(txtbox.Text))
            {
                txtDNSserrver2.Focus();
                lblStatusmessage.Text = "DNS Server 2 address is not in valid ip format ";
            }
            else
            {
                lblStatusmessage.Text = "Message center";

            }

        }
    }
}
