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
    public partial class SetDeviceResolution : Form
    {
        private ComboBox cmbglobal = new ComboBox();
        private DataTable tbldevicesres;
        public SetDeviceResolution()
        {
            InitializeComponent();
        }

        private void SetDeviceResolution_Load(object sender, EventArgs e)
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                Connection.Open();
                string query = "Select resolutionID,deviceid,resolution_index,resolution_value from device_resolution";
                MySqlDataAdapter deviceresolutionadapter = new MySqlDataAdapter(query, Connection);
                DataSet deviceresolutiondata = new DataSet();
                deviceresolutionadapter.Fill(deviceresolutiondata, "device_resolution");
                tbldevicesres = new DataTable();
                tbldevicesres = deviceresolutiondata.Tables["device_resolution"];

                DeviceResolutionGV.DataSource = tbldevicesres;
                DeviceResolutionGV.Columns["resolutionID"].ReadOnly = true;
                DeviceResolutionGV.Columns["deviceid"].ReadOnly = false;
                DeviceResolutionGV.Columns["resolution_index"].ReadOnly = false;
                DeviceResolutionGV.Columns["resolution_value"].ReadOnly = false;

                string querydevices = "Select deviceid,device_name from devices order by deviceid";

                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(querydevices, Connection);

                //units table dataset is defined   
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");

                //Data table for unitsofmesurement table is defined
                DataTable tbldevices = devicedata.Tables["devices"];

                DeviceResolutionGV.Columns[1].Visible = false;

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
                DeviceResolutionGV.Columns.Insert(1, devices);

                //loop thru the grids invsible column units of channel table
                // and set the value to the combobox value
                foreach (DataGridViewRow item in DeviceResolutionGV.Rows)
                {
                    item.Cells[1].Value = item.Cells[2].Value;
                    item.Height = 30;

                }
                DeviceResolutionGV.Columns[0].Width = 125;
                DeviceResolutionGV.Columns[0].HeaderText = "Resolution ID";
                DeviceResolutionGV.Columns[1].Width = 200;
                DeviceResolutionGV.Columns[1].HeaderText = "Device Name";
                DeviceResolutionGV.Columns[3].Width = 150;
                DeviceResolutionGV.Columns[3].HeaderText = "Resolution Index";
                DeviceResolutionGV.Columns[4].Width = 200;
                DeviceResolutionGV.Columns[4].HeaderText = "Resolution Value";


                DeviceResolutionGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceResolutionGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceResolutionGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceResolutionGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceResolutionGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceResolutionGV.AllowUserToAddRows = false;

            }
        }

        private void DeviceResolutionGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cmbvalue = e.Control as ComboBox;
            if (DeviceResolutionGV.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
            {
                cmbvalue.SelectedIndexChanged += new EventHandler(deviceid_SelectedIndexChanged);
            }
        }

        private void deviceid_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbvalue = (ComboBox)sender;
            cmbglobal = cmbvalue;

            if (DeviceResolutionGV.CurrentCell.ColumnIndex == 1)
            {
                DeviceResolutionGV.CurrentRow.Cells[2].Value = cmbglobal.SelectedValue.ToString();
            }
        }


        private void DeviceResolutionGV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            cmbglobal.SelectedIndexChanged -= new EventHandler(deviceid_SelectedIndexChanged);
        }
        private void RefershGridView()
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                DeviceResolutionGV.DataSource = null;
                DeviceResolutionGV.Rows.Clear();
                DeviceResolutionGV.Columns.Clear();
                Connection.Open();
                string query = "Select resolutionID,deviceid,resolution_index,resolution_value from device_resolution";
                MySqlDataAdapter deviceresolutionadapter = new MySqlDataAdapter(query, Connection);
                DataSet deviceresolutiondata = new DataSet();
                deviceresolutionadapter.Fill(deviceresolutiondata, "device_resolution");
                tbldevicesres = new DataTable();
                tbldevicesres = deviceresolutiondata.Tables["device_resolution"];

                DeviceResolutionGV.DataSource = tbldevicesres;
                DeviceResolutionGV.Columns["resolutionID"].ReadOnly = true;
                DeviceResolutionGV.Columns["deviceid"].ReadOnly = false;
                DeviceResolutionGV.Columns["resolution_index"].ReadOnly = false;
                DeviceResolutionGV.Columns["resolution_value"].ReadOnly = false;

                string querydevices = "Select deviceid,device_name from devices order by deviceid";

                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(querydevices, Connection);

                //units table dataset is defined   
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");

                //Data table for unitsofmesurement table is defined
                DataTable tbldevices = devicedata.Tables["devices"];

                DeviceResolutionGV.Columns[1].Visible = false;

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
                DeviceResolutionGV.Columns.Insert(1, devices);

                //loop thru the grids invsible column units of channel table
                // and set the value to the combobox value
                foreach (DataGridViewRow item in DeviceResolutionGV.Rows)
                {
                    item.Cells[1].Value = item.Cells[2].Value;
                    item.Height = 30;

                }
                DeviceResolutionGV.Columns[0].Width = 125;
                DeviceResolutionGV.Columns[0].HeaderText = "Resolution ID";
                DeviceResolutionGV.Columns[1].Width = 200;
                DeviceResolutionGV.Columns[1].HeaderText = "Device Name";
                DeviceResolutionGV.Columns[3].Width = 150;
                DeviceResolutionGV.Columns[3].HeaderText = "Resolution Index";
                DeviceResolutionGV.Columns[4].Width = 200;
                DeviceResolutionGV.Columns[4].HeaderText = "Resolution Value";

                DeviceResolutionGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceResolutionGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceResolutionGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceResolutionGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceResolutionGV.AllowUserToAddRows = false;

            }

        }

        private void AddResolution_Click(object sender, EventArgs e)
        {
            AddResoultionToDevices resolutiontodevice = new AddResoultionToDevices(ref DeviceResolutionGV);
            resolutiontodevice.ShowDialog();
        }


        private void Update_Click(object sender, EventArgs e)
        {
            DataTable tblchanges = new DataTable();
            tblchanges = tbldevicesres.GetChanges();
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
                            var results = DeviceResolutionGV.Rows.Cast<DataGridViewRow>()
                                          .FirstOrDefault(rvalue => rvalue.Cells[0].Value.ToString() == row[0].ToString());
                            String UpdateSQL = "Update device_resolution set deviceID ='" + results.Cells[2].Value.ToString() + "', " +
                                                "resolution_index =" + results.Cells[3].Value.ToString() +
                                                ", resolution_value =" + results.Cells[4].Value.ToString() + " where resolutionID = " + row[0].ToString();

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

        private void DeviceResolutionGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

