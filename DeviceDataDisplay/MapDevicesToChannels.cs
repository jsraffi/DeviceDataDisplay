using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceDataDisplay
{
    public partial class MapDevicesToChannels : Form
    {
        private string lastselectedvalue;
        public MapDevicesToChannels()
        {
            InitializeComponent();
        }

        private void MapDevicesToChannels_Load(object sender, EventArgs e)
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                Connection.Open();
                string query = "Select Channel_no,channel_name,DeviceRefID from channels";
                MySqlDataAdapter channeladapter = new MySqlDataAdapter(query, Connection);
                DataSet channelsdata = new DataSet();
                channeladapter.Fill(channelsdata, "channels");

                //Datasource for dataviewgrid is set to channels dataset;
                //based on the query defined
                DeviceMapGV.DataSource = channelsdata.Tables["channels"];
                DeviceMapGV.Columns["Channel_no"].ReadOnly = true;
                DeviceMapGV.Columns["channel_name"].ReadOnly = true;
                DeviceMapGV.Columns["DeviceRefID"].ReadOnly = false;

                //query for units table is defined
                string querydevices = "Select deviceId, device_name from devices order by deviceid";
                
                //An sql adapter is opened
                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(querydevices, Connection);

                //units table dataset is defined   
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata,"devices");

                //Data table for unitsofmesurement table is defined
                DataTable tbldevices = devicedata.Tables["devices"];

                //ChannelGV datagrid units colum is hidden    
                DeviceMapGV.Columns[2].Visible = false;

                //Combo box for datagrid is created
                DataGridViewComboBoxCell bc = new DataGridViewComboBoxCell();
                List<devicemap> listofdevices  = new List<devicemap>();
                
                listofdevices = (from DataRow dr in tbldevices.Rows
                               select new devicemap
                               {
                                   deviceid = Convert.ToInt32(dr["deviceid"]),
                                   device_name = dr["device_name"].ToString(),
                                   
                               }).ToList();
                devicemap unselectedvalue = new devicemap();
                unselectedvalue.deviceid = 0;
                unselectedvalue.device_name = "Select this value to detach a device from channel";
                listofdevices.Add(unselectedvalue);
                //Combo source is set to datasource datatable of unitofmesurement table
                bc.DataSource = listofdevices;
                bc.DisplayMember = "device_name";// set  value to units column of unitofmesurement
                bc.ValueMember = "deviceid";// set index to unitid column of unitofmesurement
                
                //attach datagridcombo to a datagrid column
                DataGridViewColumn cc = new DataGridViewColumn(bc);
                cc.HeaderText = "Devices";
                cc.Name = "Devices";

                //add new column to grid;
                DeviceMapGV.Columns.Add(cc);

                //loop thru the grids invsible column units of channel table
                // and set the value to the combobox value
                foreach (DataGridViewRow item in DeviceMapGV.Rows)
                {
                    if(item.Cells[2].Value != null)
                    {
                        item.Cells[3].Value = item.Cells[2].Value;
                    }
                    item.Height = 30; 

                }
                DeviceMapGV.Columns[0].Width = 125;
                DeviceMapGV.Columns[1].Width = 200;
                DeviceMapGV.Columns[1].HeaderText = "Channels";
                DeviceMapGV.Columns[3].Width = 450;

                DeviceMapGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceMapGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceMapGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            DeviceMapGV.AllowUserToAddRows = false;

        }
        protected class devicemap
        {
            public int deviceid { get; set; }
            public string device_name { get; set; }
        }

        private void DeviceMapGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cmbdevices = e.Control as ComboBox;
            if (DeviceMapGV.CurrentCell.ColumnIndex == 3 && e.Control is ComboBox)
            {
                DataGridViewComboBoxCell col = (DataGridViewComboBoxCell)DeviceMapGV.CurrentRow.Cells[3];
                lastselectedvalue = col.Value.ToString();
                //MessageBox.Show(lastselectedvalue);
                cmbdevices.SelectedIndexChanged += new EventHandler(devices_SelectedIndexChanged);
            }
        }
        private void devices_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbdevices = (ComboBox)sender;
            string status = "";
            string channelNo = DeviceMapGV.CurrentRow.Cells[0].Value.ToString();
            try
            {
                if (cmbdevices.SelectedIndex >= 0)
                {
                    using (MySqlConnection conn = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
                    {
                        MySqlCommand cmddevicesUpdate = new MySqlCommand();
                        string deviceid = cmbdevices.SelectedValue.ToString();
                        if (deviceid == "0")
                        {
                            cmddevicesUpdate.CommandText = "Update channels set deviceRefID = 0 ,alarmswitch = 0 ,onlyminlevel = 0, onlymaxlevel = 0,alarmstatus = 0 where channel_no =" + channelNo + "";
                            cmddevicesUpdate.CommandType = CommandType.Text;
                            cmddevicesUpdate.Connection = conn;
                            conn.Open();
                            cmddevicesUpdate.ExecuteNonQuery();
                            
                            status = "No device is attached to channel " + channelNo;
                        }
                        else
                        {
                            string querydevicestatus = "Select channel_name from channels where devicerefid = " + deviceid;
                            conn.Open();
                            cmddevicesUpdate.CommandText = querydevicestatus;
                            cmddevicesUpdate.Connection = conn;
                            object channelname = cmddevicesUpdate.ExecuteScalar();
                            if (channelname != null)
                            {
                                status = "The device is already connected to channel " + channelname.ToString();
                                cmbdevices.SelectedValue = 0;
                            }
                            else
                            {
                                string queryalarm = "select alarm_start_address,alarm_status_start_address,min_level_address,max_level_address from devices where deviceid = " + deviceid.ToString();
                                cmddevicesUpdate.CommandText = queryalarm;
                                cmddevicesUpdate.CommandType = CommandType.Text;
                                cmddevicesUpdate.Connection = conn;
                                //object alarmon = cmddevicesUpdate.ExecuteScalar();
                                Dictionary<string,int> deviceoptionalsettings = new Dictionary<string, int>();
                                MySqlDataReader devicereader = cmddevicesUpdate.ExecuteReader();
                                if (devicereader.HasRows)
                                {
                                    while (devicereader.Read())
                                    {
                                        deviceoptionalsettings.Add("AlarmAddr", (devicereader.IsDBNull(0)) ? 0: devicereader.GetUInt16(0));
                                        deviceoptionalsettings.Add("AlarmStatusAddr", (devicereader.IsDBNull(1)) ? 0 : devicereader.GetUInt16(1));
                                        deviceoptionalsettings.Add("MinLevelAddr", (devicereader.IsDBNull(2)) ? 0 : devicereader.GetUInt16(2));
                                        deviceoptionalsettings.Add("MaxLevelAddr", (devicereader.IsDBNull(3)) ? 0 : devicereader.GetUInt16(3));
                                    }
                                }
                                devicereader.Close();
                                MySqlTransaction trans = conn.BeginTransaction();
                                try
                                {
                                    
                                    if (deviceoptionalsettings["AlarmAddr"] != 0)
                                    {
                                        cmddevicesUpdate.CommandText = "Update channels set alarmswitch = 1 where channel_no =" + channelNo ;
                                        cmddevicesUpdate.CommandType = CommandType.Text;
                                        cmddevicesUpdate.Connection = conn;
                                        cmddevicesUpdate.ExecuteNonQuery();

                                    }
                                    if (deviceoptionalsettings["AlarmStatusAddr"] != 0)
                                    {
                                        cmddevicesUpdate.CommandText = "Update channels set alarmstatus = 1 where channel_no =" + channelNo;
                                        cmddevicesUpdate.CommandType = CommandType.Text;
                                        cmddevicesUpdate.Connection = conn;
                                        cmddevicesUpdate.ExecuteNonQuery();

                                    }
                                    if (deviceoptionalsettings["MinLevelAddr"] != 0)
                                    {
                                        cmddevicesUpdate.CommandText = "Update channels set onlyminlevel = 1 where channel_no =" + channelNo;
                                        cmddevicesUpdate.CommandType = CommandType.Text;
                                        cmddevicesUpdate.Connection = conn;
                                        cmddevicesUpdate.ExecuteNonQuery();
                                    }

                                    if (deviceoptionalsettings["MaxLevelAddr"] != 0)
                                    {
                                        cmddevicesUpdate.CommandText = "Update channels set onlymaxlevel = 1 where channel_no =" + channelNo ;
                                        cmddevicesUpdate.CommandType = CommandType.Text;
                                        cmddevicesUpdate.Connection = conn;
                                        cmddevicesUpdate.ExecuteNonQuery();
                                    }
                                    cmddevicesUpdate.CommandText = "Update channels set deviceRefID =" + deviceid.ToString() + " where channel_no =" + channelNo + "";
                                    cmddevicesUpdate.CommandType = CommandType.Text;
                                    cmddevicesUpdate.Connection = conn;
                                    cmddevicesUpdate.ExecuteNonQuery();
                                    trans.Commit();
                                    status = "This Channel is connected to a device";
                                }
                                catch (Exception)
                                {   
                                    trans.Rollback();
                                    status = "Unable to connect the channel to device:DB Error";

                                }
                                 
                                
                            }
                        }
                    }
                }

                lblDeviceMapStatus.Text = status;
                cmbdevices.SelectedIndexChanged -= new EventHandler(devices_SelectedIndexChanged);
            }
            catch (Exception err)
            {
                lblDeviceMapStatus.Text = "Error " + err.Message;
                cmbdevices.SelectedIndexChanged -= new EventHandler(devices_SelectedIndexChanged);
            }
        }

        private void DeviceMapGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
