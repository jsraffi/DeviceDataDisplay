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
    public partial class SetDeviceAlarm : Form
    {
        private ComboBox cmbglobal = new ComboBox();
        private DataTable tbldevicesalarm;

        public SetDeviceAlarm()
        {
            InitializeComponent();
        }

        private void SetDeviceAlarm_Load(object sender, EventArgs e)
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                Connection.Open();
                string query = "Select alarmID,deviceid,alarm_index,alarm_value from device_alarm";
                MySqlDataAdapter deviceresolutionadapter = new MySqlDataAdapter(query, Connection);
                DataSet deviceresolutiondata = new DataSet();
                deviceresolutionadapter.Fill(deviceresolutiondata, "device_alarm");
                tbldevicesalarm = new DataTable();
                tbldevicesalarm = deviceresolutiondata.Tables["device_alarm"];

                DeviceAlarmGV.DataSource = tbldevicesalarm;
                DeviceAlarmGV.Columns["alarmID"].ReadOnly = true;
                DeviceAlarmGV.Columns["deviceid"].ReadOnly = false;
                DeviceAlarmGV.Columns["alarm_index"].ReadOnly = false;
                DeviceAlarmGV.Columns["alarm_value"].ReadOnly = false;

                string querydevices = "Select deviceid,device_name from devices order by deviceid";

                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(querydevices, Connection);

                //units table dataset is defined   
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");

                //Data table for unitsofmesurement table is defined
                DataTable tbldevices = devicedata.Tables["devices"];

                DeviceAlarmGV.Columns[1].Visible = false;

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
                DeviceAlarmGV.Columns.Insert(1, devices);

                //loop thru the grids invsible column units of channel table
                // and set the value to the combobox value
                foreach (DataGridViewRow item in DeviceAlarmGV.Rows)
                {
                    item.Cells[1].Value = item.Cells[2].Value;
                    item.Height = 30;

                }
                DeviceAlarmGV.Columns[0].Width = 125;
                DeviceAlarmGV.Columns[0].HeaderText = "Alarm ID";
                DeviceAlarmGV.Columns[1].Width = 200;
                DeviceAlarmGV.Columns[1].HeaderText = "Device Name";
                DeviceAlarmGV.Columns[3].Width = 150;
                DeviceAlarmGV.Columns[3].HeaderText = "Alarm Index";
                DeviceAlarmGV.Columns[4].Width = 150;
                DeviceAlarmGV.Columns[4].HeaderText = "Alarm Value";


                DeviceAlarmGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceAlarmGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceAlarmGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceAlarmGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceAlarmGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

                DeviceAlarmGV.AllowUserToAddRows = false;

            }
        }

        private void RefreshGridView()
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                DeviceAlarmGV.DataSource = null;
                DeviceAlarmGV.Rows.Clear();
                DeviceAlarmGV.Columns.Clear();

                Connection.Open();
                string query = "Select alarmID,deviceid,alarm_index,alarm_value from device_alarm";
                MySqlDataAdapter deviceresolutionadapter = new MySqlDataAdapter(query, Connection);
                DataSet deviceresolutiondata = new DataSet();
                deviceresolutionadapter.Fill(deviceresolutiondata, "device_alarm");
                tbldevicesalarm = new DataTable();
                tbldevicesalarm = deviceresolutiondata.Tables["device_alarm"];

                DeviceAlarmGV.DataSource = tbldevicesalarm;
                DeviceAlarmGV.Columns["alarmID"].ReadOnly = true;
                DeviceAlarmGV.Columns["deviceid"].ReadOnly = false;
                DeviceAlarmGV.Columns["alarm_index"].ReadOnly = false;
                DeviceAlarmGV.Columns["alarm_value"].ReadOnly = false;

                string querydevices = "Select deviceid,device_name from devices order by deviceid";

                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(querydevices, Connection);

                //units table dataset is defined   
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");

                //Data table for unitsofmesurement table is defined
                DataTable tbldevices = devicedata.Tables["devices"];

                DeviceAlarmGV.Columns[1].Visible = false;

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
                DeviceAlarmGV.Columns.Insert(1, devices);

                //loop thru the grids invsible column units of channel table
                // and set the value to the combobox value
                foreach (DataGridViewRow item in DeviceAlarmGV.Rows)
                {
                    item.Cells[1].Value = item.Cells[2].Value;
                    item.Height = 30;

                }
                DeviceAlarmGV.Columns[0].Width = 125;
                DeviceAlarmGV.Columns[0].HeaderText = "Alarm ID";
                DeviceAlarmGV.Columns[1].Width = 200;
                DeviceAlarmGV.Columns[1].HeaderText = "Device Name";
                DeviceAlarmGV.Columns[3].Width = 150;
                DeviceAlarmGV.Columns[3].HeaderText = "Alarm Index";
                DeviceAlarmGV.Columns[4].Width = 150;
                DeviceAlarmGV.Columns[4].HeaderText = "Alarm Value";


                DeviceAlarmGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceAlarmGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceAlarmGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceAlarmGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceAlarmGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

                DeviceAlarmGV.AllowUserToAddRows = false;

            }

        }

        private void DeviceAlarmGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cmbvalue = e.Control as ComboBox;
            if (DeviceAlarmGV.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
            {
                cmbvalue.SelectedIndexChanged += new EventHandler(deviceid_SelectedIndexChanged);
            }
        }
        private void deviceid_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbvalue = (ComboBox)sender;
            cmbglobal = cmbvalue;

            if (DeviceAlarmGV.CurrentCell.ColumnIndex == 1)
            {
                DeviceAlarmGV.CurrentRow.Cells[2].Value = cmbglobal.SelectedValue.ToString();
            }
        }


        private void DeviceAlarmGV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            cmbglobal.SelectedIndexChanged -= new EventHandler(deviceid_SelectedIndexChanged);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            DataTable tblchanges = new DataTable();
            tblchanges = tbldevicesalarm.GetChanges();
            int counter = 0;
            if (tblchanges != null)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]);
                    conn.Open();
                    MySqlCommand deviceUpdate = new MySqlCommand();

                    foreach (DataRow row in tblchanges.Rows)
                    {
                        if (row[0].ToString() != null)
                        {
                            //string rowvalues = row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString() + " " + row[4].ToString() + " " + row[7].ToString();
                            var results = DeviceAlarmGV.Rows.Cast<DataGridViewRow>()
                                          .FirstOrDefault(rvalue => rvalue.Cells[0].Value.ToString() == row[0].ToString());
                            String UpdateSQL = "Update device_alarm set deviceID ='" + results.Cells[2].Value.ToString() + "', " +
                                                "alarm_index =" + results.Cells[3].Value.ToString() +
                                                ", alarm_value = '" + results.Cells[4].Value.ToString() + "' where alarmID = " + row[0].ToString();

                            deviceUpdate.CommandType = CommandType.Text;
                            deviceUpdate.CommandText = UpdateSQL;
                            deviceUpdate.Connection = conn;
                            deviceUpdate.ExecuteNonQuery();
                            counter = counter + 1;
                        }

                    }
                    conn.Close();
                    RefreshGridView();
                    if (counter > 0)
                    {
                        lblStatus.Text = counter + " rows sucessfully updated";
                        counter = 0;
                    }

                }
                catch (Exception err)
                {
                    lblStatus.Text = "Error occured no rows updated" + err.Message;
                }
            }
            else
            {
                lblStatus.Text = "No rows updated";
                counter = 0;
            }
        }

        private void AddAlarm_Click(object sender, EventArgs e)
        {
            AddAlarmToDevcies alarmtodevice = new AddAlarmToDevcies(ref DeviceAlarmGV);
            alarmtodevice.ShowDialog();
        }
    }
}
