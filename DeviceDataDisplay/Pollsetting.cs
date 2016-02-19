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
            string[] commandInterval = new string[] { "50","100","150","200","250","300","350","400","450","500" };

            string[] firstTimeinteval = new string[] { "32000", "50000", "64000" };

            string[] baudrates = { "230400", "115200", "57600", "38400", "19200", "9600" };

            string[] portnames = { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13", "COM14", "COM15", "COM16" };

            cmbCommandInterval.Items.AddRange(commandInterval);
            cmbFirstTimePollInterval.Items.AddRange(firstTimeinteval);
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
            cmbCommandInterval.SelectedIndex = cmbCommandInterval.FindStringExact(tblpoll_setting.Rows[0].Field<int>("command_interval").ToString());
            cmbFirstTimePollInterval.SelectedIndex = cmbFirstTimePollInterval.FindStringExact(tblpoll_setting.Rows[0].Field<int>("poll_interval").ToString());
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                MySqlCommand cmdminmaxUpdate = new MySqlCommand();
                cmdminmaxUpdate.CommandText = "Update poll_setting  set com_port ='" + (CmbPortNames.SelectedItem as Object).ToString()  + "' , baud_rate =" + (CmbBaudRates.SelectedItem as Object).ToString() + ", command_interval = " + (cmbCommandInterval.SelectedItem as Object).ToString() + ", poll_interval = " + (cmbFirstTimePollInterval.SelectedItem as Object).ToString() + " where pollID=1";
                

                cmdminmaxUpdate.CommandType = CommandType.Text;
                cmdminmaxUpdate.Connection = conn;

                conn.Open();
                cmdminmaxUpdate.ExecuteNonQuery();
            }

            if (System.Windows.Forms.Application.OpenForms["DeviceDataDisplay"] != null)
            {

                (System.Windows.Forms.Application.OpenForms["DeviceDataDisplay"] as DeviceDataDisplay).getPollSetting();
            }
        }
    }
}
