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
    public partial class AddAlarmToDevcies : Form
    {
        private DataGridView DeviceAlarmGVRef;
        public AddAlarmToDevcies()
        {
            InitializeComponent();
        }

        public AddAlarmToDevcies(ref DataGridView devicealarm)
        {
            InitializeComponent();
            DeviceAlarmGVRef = devicealarm;
        }

        private void AddAlarmToDevcies_Load(object sender, EventArgs e)
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                Connection.Open();
                string query = "Select deviceid, device_name from devices";
                MySqlDataAdapter devices = new MySqlDataAdapter(query, Connection);
                DataSet deviceunitsdata = new DataSet();
                devices.Fill(deviceunitsdata, "devices");
                DataTable tbldevices = new DataTable();
                tbldevices = deviceunitsdata.Tables["devices"];

                cmbDeviceSelection.DataSource = tbldevices;
                cmbDeviceSelection.ValueMember = "deviceid";
                cmbDeviceSelection.DisplayMember = "device_name";
            }
        }
        private bool SavetoDB()
        {
            try
            {
                if (!(validate_form()))
                {
                    return false;
                }
                using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
                {

                    string SQL = "Insert into device_alarm(deviceid,alarm_index,alarm_value)" +
                                  "Values(" + cmbDeviceSelection.SelectedValue + "," + txtIndexValue.Text +
                                  ",'" + txtAlarmValue.Text + "')";

                    MySqlCommand cmdadddevice = new MySqlCommand();
                    cmdadddevice.CommandType = CommandType.Text;
                    cmdadddevice.CommandText = SQL;
                    cmdadddevice.Connection = Connection;
                    Connection.Open();
                    cmdadddevice.ExecuteNonQuery();
                    lblStatus.Text = "Alarm value added to database";
                    txtIndexValue.Text = "";
                    txtAlarmValue.Text = "";
                    return true;
                }
            }
            catch (Exception err)
            {
                lblStatus.Text = "Unable to add device" + err.Message;
                return false;
            }
        }
        private Boolean validate_form()
        {
            int outvalue = 0;
            if (txtIndexValue.Text == "")
            {
                txtIndexValue.Focus();
                lblStatus.Text = "Index value is required";
                return false;
            }

            if (!(int.TryParse(txtIndexValue.Text, out outvalue)))
            {
                txtIndexValue.Focus();
                lblStatus.Text = "Index value is required and should be numeric";
                return false;
            }

            if (txtAlarmValue.Text == "")
            {
                txtAlarmValue.Focus();
                lblStatus.Text = "Alarm value is required";
                return false;
            }

            return true;
        }

        private void RefreshGridView()
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                DeviceAlarmGVRef.DataSource = null;
                DeviceAlarmGVRef.Rows.Clear();
                DeviceAlarmGVRef.Columns.Clear();

                Connection.Open();
                string query = "Select alarmID,deviceid,alarm_index,alarm_value from device_alarm";
                MySqlDataAdapter deviceresolutionadapter = new MySqlDataAdapter(query, Connection);
                DataSet deviceresolutiondata = new DataSet();
                deviceresolutionadapter.Fill(deviceresolutiondata, "device_alarm");
                DataTable tbldevicesalarm = new DataTable();
                tbldevicesalarm = deviceresolutiondata.Tables["device_alarm"];

                DeviceAlarmGVRef.DataSource = tbldevicesalarm;
                DeviceAlarmGVRef.Columns["alarmID"].ReadOnly = true;
                DeviceAlarmGVRef.Columns["deviceid"].ReadOnly = false;
                DeviceAlarmGVRef.Columns["alarm_index"].ReadOnly = false;
                DeviceAlarmGVRef.Columns["alarm_value"].ReadOnly = false;

                string querydevices = "Select deviceid,device_name from devices order by deviceid";

                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(querydevices, Connection);

                //units table dataset is defined   
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");

                //Data table for unitsofmesurement table is defined
                DataTable tbldevices = devicedata.Tables["devices"];

                DeviceAlarmGVRef.Columns[1].Visible = false;

                DataGridViewComboBoxCell bc = new DataGridViewComboBoxCell();

                //Combo source is set to datasource datatable of unitofmesurement table
                bc.DataSource = tbldevices;
                bc.DisplayMember = "device_name";// set  value to units column of unitofmesurement
                bc.ValueMember = "deviceid";// set index to unitid column of unitofmesurement

                //attach datagridcombo to a datagrid column
                DataGridViewColumn devices = new DataGridViewColumn(bc);
                devices.HeaderText = "Device Name";
                devices.Name = "Devices";

                //add new column to grid;
                DeviceAlarmGVRef.Columns.Insert(1, devices);

                //loop thru the grids invsible column units of channel table
                // and set the value to the combobox value
                foreach (DataGridViewRow item in DeviceAlarmGVRef.Rows)
                {
                    item.Cells[1].Value = item.Cells[2].Value;
                    item.Height = 30;

                }
                DeviceAlarmGVRef.Columns[0].Width = 125;
                DeviceAlarmGVRef.Columns[0].HeaderText = "Alarm ID";
                DeviceAlarmGVRef.Columns[1].Width = 200;
                DeviceAlarmGVRef.Columns[1].HeaderText = "Device Name";
                DeviceAlarmGVRef.Columns[3].Width = 150;
                DeviceAlarmGVRef.Columns[3].HeaderText = "Alarm Index";
                DeviceAlarmGVRef.Columns[4].Width = 150;
                DeviceAlarmGVRef.Columns[4].HeaderText = "Alarm Value";


                DeviceAlarmGVRef.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceAlarmGVRef.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceAlarmGVRef.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceAlarmGVRef.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceAlarmGVRef.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

                DeviceAlarmGVRef.AllowUserToAddRows = false;

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavetoDB();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            RefreshGridView();
            this.Close();
        }
    }
}
