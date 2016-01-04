using MySql.Data.MySqlClient;
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

namespace DeviceDataDisplay
{
    public partial class Pollsetting : Form
    {
        public Pollsetting()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Pollsetting_Load(object sender, EventArgs e)
        {
            string[] channels = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32" };

            string[] baudrates = { "230400", "115200", "57600", "38400", "19200", "9600" };

            string[] portnames = { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13", "COM14", "COM15", "COM16" };

            CmbNoOfChannels.Items.AddRange(channels);
            CmbBaudRates.Items.AddRange(baudrates);
            CmbPortNames.Items.AddRange(portnames);

            MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]);
            Connection.Open();
            string query = "Select * from poll_setting";
            MySqlDataAdapter channeladapter = new MySqlDataAdapter(query, Connection);
            DataSet channelsdata = new DataSet();
            channeladapter.Fill(channelsdata, "poll_setting");

            DataTable tblpoll_setting = channelsdata.Tables["poll_setting"];

            CmbPortNames.SelectedIndex = CmbPortNames.FindStringExact(tblpoll_setting.Rows[0].Field<string>("com_port"));
            CmbBaudRates.SelectedIndex = CmbBaudRates.FindStringExact(tblpoll_setting.Rows[0].Field<int>("baud_rate").ToString());
            CmbNoOfChannels.SelectedIndex = CmbNoOfChannels.FindStringExact(tblpoll_setting.Rows[0].Field<int>("no_channels").ToString());
            txtPollInterval.Text = tblpoll_setting.Rows[0].Field<int>("poll_interval").ToString();
        }

        private void txtPollInterval_Validated(object sender, EventArgs e)
        {
            TextBox txtpollinterval = (TextBox)sender;

            int outvalue = 0;
            if(!(int.TryParse(txtpollinterval.Text, out outvalue))&& txtpollinterval.Text!=null)
            {
                txtpollinterval.Text = "Only Numbers";
                txtpollinterval.Focus();
                txtpollinterval.ForeColor = Color.Red;
            }
            else
            {
                txtpollinterval.ForeColor = Color.Black;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                MySqlCommand cmdminmaxUpdate = new MySqlCommand();
                cmdminmaxUpdate.CommandText = "Update poll_setting  set com_port ='" + (CmbPortNames.SelectedItem as Object).ToString()  + "' , baud_rate =" + (CmbBaudRates.SelectedItem as Object).ToString() + ", no_channels = " + (CmbNoOfChannels.SelectedItem as Object).ToString() + ", poll_interval = " + txtPollInterval.Text + " where pollID=1";
                

                cmdminmaxUpdate.CommandType = CommandType.Text;
                cmdminmaxUpdate.Connection = conn;

                conn.Open();
                cmdminmaxUpdate.ExecuteNonQuery();
            }
        }
    }
}
