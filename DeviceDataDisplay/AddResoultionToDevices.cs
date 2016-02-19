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
    public partial class AddResoultionToDevices : Form
    {
        private DataGridView DeviceResolutionGVRef;
        public AddResoultionToDevices()
        {
            InitializeComponent();
        }
        public AddResoultionToDevices(ref DataGridView deviceresolution)
        {
            DeviceResolutionGVRef = deviceresolution;
            InitializeComponent();
        }


        private void AddResoultionToDevices_Load(object sender, EventArgs e)
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
                lblDeviceResStatus.Text = "Index value is required";
                return false;
            }

            if (!(int.TryParse(txtIndexValue.Text, out outvalue)))
            {
                txtIndexValue.Focus();
                lblDeviceResStatus.Text = "Index value is required and should be numeric";
                return false;
            }

            if (txtResolution.Text == "")
            {
                txtResolution.Focus();
                lblDeviceResStatus.Text = "units value is required";
                return false;
            }

            return true;
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

                    string SQL = "Insert into device_resolution(deviceid,resolution_index,resolution_value)" +
                                  "Values(" + cmbDeviceSelection.SelectedValue + "," + txtIndexValue.Text +
                                  "," + txtResolution.Text + ")";

                    MySqlCommand cmdadddevice = new MySqlCommand();
                    cmdadddevice.CommandType = CommandType.Text;
                    cmdadddevice.CommandText = SQL;
                    cmdadddevice.Connection = Connection;
                    Connection.Open();
                    cmdadddevice.ExecuteNonQuery();
                    lblDeviceResStatus.Text = "Resolution added to database";
                    txtIndexValue.Text = "";
                    txtResolution.Text = "";
                    return true;
                }
            }
            catch (Exception err)
            {
                lblDeviceResStatus.Text = "Unable to add device" + err.Message;
                return false;
            }
        }

        private void RefershGridView()
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                DeviceResolutionGVRef.DataSource = null;
                DeviceResolutionGVRef.Rows.Clear();
                DeviceResolutionGVRef.Columns.Clear();

                Connection.Open();
                string query = "Select resolutionID,deviceid,resolution_index,resolution_value from device_resolution";
                MySqlDataAdapter deviceresolutionadapter = new MySqlDataAdapter(query, Connection);
                DataSet deviceresolutiondata = new DataSet();
                deviceresolutionadapter.Fill(deviceresolutiondata, "device_resolution");
                DataTable tbldevicesres = new DataTable();
                tbldevicesres = deviceresolutiondata.Tables["device_resolution"];

                DeviceResolutionGVRef.DataSource = tbldevicesres;
                DeviceResolutionGVRef.Columns["resolutionID"].ReadOnly = true;
                DeviceResolutionGVRef.Columns["deviceid"].ReadOnly = false;
                DeviceResolutionGVRef.Columns["resolution_index"].ReadOnly = false;
                DeviceResolutionGVRef.Columns["resolution_value"].ReadOnly = false;

                string querydevices = "Select deviceid,device_name from devices order by deviceid";

                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(querydevices, Connection);

                //units table dataset is defined   
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");

                //Data table for unitsofmesurement table is defined
                DataTable tbldevices = devicedata.Tables["devices"];

                DeviceResolutionGVRef.Columns[1].Visible = false;

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
                DeviceResolutionGVRef.Columns.Insert(1, devices);

                //loop thru the grids invsible column units of channel table
                // and set the value to the combobox value
                foreach (DataGridViewRow item in DeviceResolutionGVRef.Rows)
                {
                    item.Cells[1].Value = item.Cells[2].Value;
                    item.Height = 30;

                }
                DeviceResolutionGVRef.Columns[0].Width = 125;
                DeviceResolutionGVRef.Columns[0].HeaderText = "Resolution ID";
                DeviceResolutionGVRef.Columns[1].Width = 200;
                DeviceResolutionGVRef.Columns[1].HeaderText = "Device Name";
                DeviceResolutionGVRef.Columns[3].Width = 150;
                DeviceResolutionGVRef.Columns[3].HeaderText = "Resolution Index";
                DeviceResolutionGVRef.Columns[4].Width = 200;
                DeviceResolutionGVRef.Columns[4].HeaderText = "Resolution Value";

                DeviceResolutionGVRef.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceResolutionGVRef.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceResolutionGVRef.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceResolutionGVRef.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                DeviceResolutionGVRef.AllowUserToAddRows = false;

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavetoDB();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            RefershGridView();
            this.Close();
        }
    }
}   
