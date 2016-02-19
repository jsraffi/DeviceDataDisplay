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
    public partial class AddUnitsToDevice : Form
    {
        private DataGridView DeviceUnitsGVRef;
        public AddUnitsToDevice()
        {
            InitializeComponent();
        }
        public AddUnitsToDevice(ref DataGridView deviceunits)
        {
            DeviceUnitsGVRef = deviceunits;
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SavetoDB();
            
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
                    
                    string SQL = "Insert into device_units(deviceid,units_index,units_value)" +
                                  "Values(" + cmbDeviceSelection.SelectedValue + "," + txtIndexValue.Text +
                                  ",'" + txtUnitsValue.Text + "')";

                    MySqlCommand cmdadddevice = new MySqlCommand();
                    cmdadddevice.CommandType = CommandType.Text;
                    cmdadddevice.CommandText = SQL;
                    cmdadddevice.Connection = Connection;
                    Connection.Open();
                    cmdadddevice.ExecuteNonQuery();
                    lblDeviceUnitsStatus.Text = "Units added to database";
                    txtIndexValue.Text = "";
                    txtUnitsValue.Text = "";
                    return true;
                }
            }
            catch (Exception err)
            {
                lblDeviceUnitsStatus.Text = "Unable to add device" + err.Message;
                return false;
            }
        }
        private void AddUnitsToDevice_Load(object sender, EventArgs e)
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


        private Boolean validate_form()
        {
            int outvalue = 0;
            if (txtIndexValue.Text == "")
            {
                txtIndexValue.Focus();
                lblDeviceUnitsStatus.Text = "Index value is required";
                return false;
            }

            if (!(int.TryParse(txtIndexValue.Text, out outvalue)))
            {
                txtIndexValue.Focus();
                lblDeviceUnitsStatus.Text = "Index value is required and should be numeric";
                return false;
            }

            if (txtUnitsValue.Text == "")
            {
                txtUnitsValue.Focus();
                lblDeviceUnitsStatus.Text = "units value is required";
                return false;
            }
            
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            RefershGridView();
            this.Close();

        }
        private void RefershGridView()
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                DeviceUnitsGVRef.DataSource = null;
                DeviceUnitsGVRef.Rows.Clear();
                DeviceUnitsGVRef.Columns.Clear();
                Connection.Open();
                string query = "Select device_unitsid,deviceid,units_index,units_value from device_units";
                MySqlDataAdapter deviceunitsadapter = new MySqlDataAdapter(query, Connection);
                DataSet deviceunitsdata = new DataSet();
                deviceunitsadapter.Fill(deviceunitsdata, "device_units");
                DataTable tbldevicesunits = new DataTable();
                tbldevicesunits = deviceunitsdata.Tables["device_units"];

                DeviceUnitsGVRef.DataSource = tbldevicesunits;
                DeviceUnitsGVRef.Columns["device_unitsID"].ReadOnly = true;
                DeviceUnitsGVRef.Columns["deviceid"].ReadOnly = false;
                DeviceUnitsGVRef.Columns["units_index"].ReadOnly = false;
                DeviceUnitsGVRef.Columns["units_value"].ReadOnly = false;

                string querydevices = "Select deviceid,device_name from devices order by deviceid";

                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(querydevices, Connection);

                //units table dataset is defined   
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");

                //Data table for unitsofmesurement table is defined
                DataTable tbldevices = devicedata.Tables["devices"];

                DeviceUnitsGVRef.Columns[1].Visible = false;

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
                DeviceUnitsGVRef.Columns.Insert(1, devices);

                //loop thru the grids invsible column units of channel table
                // and set the value to the combobox value
                foreach (DataGridViewRow item in DeviceUnitsGVRef.Rows)
                {
                    item.Cells[1].Value = item.Cells[2].Value;
                    item.Height = 30;

                }
                DeviceUnitsGVRef.Columns[0].Width = 125;
                DeviceUnitsGVRef.Columns[0].HeaderText = "Units ID";
                DeviceUnitsGVRef.Columns[1].Width = 200;
                DeviceUnitsGVRef.Columns[1].HeaderText = "Device Name";
                DeviceUnitsGVRef.Columns[3].Width = 125;

                DeviceUnitsGVRef.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceUnitsGVRef.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceUnitsGVRef.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceUnitsGVRef.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                DeviceUnitsGVRef.AllowUserToAddRows = false;
            }

        }
    }
    }
