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
    public partial class SetDeviceUnits : Form
    {
        private DataTable tbldevices;
        private ComboBox cmbglobal = new ComboBox();
        private MySqlDataAdapter deviceunitsadapter = new MySqlDataAdapter();

        public SetDeviceUnits()
        {
            InitializeComponent();
        }

        private void SetDeviceUnits_Load(object sender, EventArgs e)
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                Connection.Open();
                string query = "Select device_unitsid,deviceid,units_index,units_value from device_units";
                this.deviceunitsadapter.SelectCommand = new MySqlCommand(query, Connection);
                DataSet deviceunitsdata = new DataSet();
                deviceunitsadapter.Fill(deviceunitsdata, "device_units");
                this.tbldevices = new DataTable();
                this.tbldevices = deviceunitsdata.Tables["device_units"];

                DeviceUnits.DataSource = this.tbldevices;
                DeviceUnits.Columns["device_unitsid"].ReadOnly = true;
                DeviceUnits.Columns["deviceid"].ReadOnly = false;
                DeviceUnits.Columns["units_index"].ReadOnly = false;
                DeviceUnits.Columns["units_value"].ReadOnly = false;

                string querydevices = "Select deviceid,device_name from devices order by deviceid";

                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(querydevices, Connection);

                //units table dataset is defined   
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");

                //Data table for unitsofmesurement table is defined
                DataTable tbldevices = devicedata.Tables["devices"];

                DeviceUnits.Columns[1].Visible = false;

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
                DeviceUnits.Columns.Insert(1, devices);

                //loop thru the grids invsible column units of channel table
                // and set the value to the combobox value
                foreach (DataGridViewRow item in DeviceUnits.Rows)
                {
                    item.Cells[1].Value = item.Cells[2].Value;
                    item.Height = 30;

                }
                DeviceUnits.Columns[0].Width = 125;
                DeviceUnits.Columns[0].HeaderText = "Units ID";
                DeviceUnits.Columns[1].Width = 200;
                DeviceUnits.Columns[1].HeaderText = "Device Name";
                DeviceUnits.Columns[3].Width = 125;

                DeviceUnits.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceUnits.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceUnits.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceUnits.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                DeviceUnits.AllowUserToAddRows = false;

        }

        }

        private void DeviceUnits_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cmbvalue = e.Control as ComboBox;
            if (DeviceUnits.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
            {
                cmbvalue.SelectedIndexChanged += new EventHandler(deviceid_SelectedIndexChanged);
            }
        }

        private void deviceid_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbvalue = (ComboBox)sender;
            cmbglobal = cmbvalue;
            
            if (DeviceUnits.CurrentCell.ColumnIndex == 1)
            {
                DeviceUnits.CurrentRow.Cells[2].Value = cmbglobal.SelectedValue.ToString();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {

            DataTable tblchanges = new DataTable();
            tblchanges = tbldevices.GetChanges();
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
                            var results = DeviceUnits.Rows.Cast<DataGridViewRow>()
                                          .FirstOrDefault(rvalue => rvalue.Cells[0].Value.ToString() == row[0].ToString());

                            

                            String UpdateSQL = "Update device_units set deviceID ='" + results.Cells[2].Value.ToString() + "', " +
                                                "units_index =" + results.Cells[3].Value.ToString() +
                                                ", units_value ='" + results.Cells[4].Value.ToString() + "' where device_unitsID = " + row[0].ToString();

                            deviceUpdate.CommandType = CommandType.Text;
                            deviceUpdate.CommandText = UpdateSQL;
                            deviceUpdate.Connection = conn;


                            deviceUpdate.ExecuteNonQuery();
                            counter = counter + 1;

                        }

                    }

                    conn.Close();
                    RefershGridView();
                    if (counter > 0)
                    {
                        lblDeviceUnitsStatus.Text = counter + " rows sucessfully updated";
                        counter = 0;

                    }

                }
                catch (Exception err)
                {
                    lblDeviceUnitsStatus.Text = "Error occured no rows updated" + err.Message;


                }
            }
            else
            {
                lblDeviceUnitsStatus.Text = "No rows updated";
                counter = 0;
            }
        }
        private void RefershGridView()
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                DeviceUnits.DataSource = null;
                DeviceUnits.Rows.Clear();
                DeviceUnits.Columns.Clear();
                Connection.Open();
                string query = "Select device_unitsid,deviceid,units_index,units_value from device_units";
                this.deviceunitsadapter.SelectCommand = new MySqlCommand(query, Connection);
                DataSet deviceunitsdata = new DataSet();
                deviceunitsadapter.Fill(deviceunitsdata, "device_units");
                this.tbldevices = new DataTable();
                this.tbldevices = deviceunitsdata.Tables["device_units"];

                DeviceUnits.DataSource = this.tbldevices;
                DeviceUnits.Columns["device_unitsID"].ReadOnly = true;
                DeviceUnits.Columns["deviceid"].ReadOnly = false;
                DeviceUnits.Columns["units_index"].ReadOnly = false;
                DeviceUnits.Columns["units_value"].ReadOnly = false;

                string querydevices = "Select deviceid,device_name from devices order by deviceid";

                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(querydevices, Connection);

                //units table dataset is defined   
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");

                //Data table for unitsofmesurement table is defined
                DataTable tbldevices = devicedata.Tables["devices"];

                DeviceUnits.Columns[1].Visible = false;

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
                DeviceUnits.Columns.Insert(1, devices);

                //loop thru the grids invsible column units of channel table
                // and set the value to the combobox value
                foreach (DataGridViewRow item in DeviceUnits.Rows)
                {
                    item.Cells[1].Value = item.Cells[2].Value;
                    item.Height = 30;

                }
                DeviceUnits.Columns[0].Width = 125;
                DeviceUnits.Columns[0].HeaderText = "Units ID";
                DeviceUnits.Columns[1].Width = 200;
                DeviceUnits.Columns[1].HeaderText = "Device Name";
                DeviceUnits.Columns[3].Width = 125;

                DeviceUnits.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceUnits.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceUnits.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceUnits.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                DeviceUnits.AllowUserToAddRows = false;
            }

         }

        private void AddUnits_Click(object sender, EventArgs e)
        {
            AddUnitsToDevice unitstodevice = new AddUnitsToDevice(ref DeviceUnits);
            unitstodevice.ShowDialog();
        }

        private void DeviceUnits_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            cmbglobal.SelectedIndexChanged -= new EventHandler(deviceid_SelectedIndexChanged);
        }

        private void DeviceUnits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
 }
